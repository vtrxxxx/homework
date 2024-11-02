using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

class BarberShop
{
    private int waiting = 0; 
    private int maxWaitingChairs; 
    private Queue<int> customerQueue = new Queue<int>(); 

    private Semaphore customers; 
    private Semaphore barbers = new Semaphore(1, 1); 
    private Semaphore mutex = new Semaphore(1, 1); 
    private Semaphore seatReady = new Semaphore(0, 1); 

    public BarberShop(int maxWaitingChairs)
    {
        this.maxWaitingChairs = maxWaitingChairs;
        this.customers = new Semaphore(0, maxWaitingChairs);
    }

    public void Barber()
    {
        while (true)
        {
            customers.WaitOne(); 
            mutex.WaitOne();

            int customerId = customerQueue.Dequeue(); 
            waiting--;

            mutex.Release(); 

            seatReady.WaitOne();
            Console.WriteLine($"Перукар починає стригти клієнта з ID: {customerId}");
            CutHair(customerId); 
            barbers.Release();
        }
    }

    public void Customer(int customerId)
    {
        mutex.WaitOne(); 
        if (waiting < maxWaitingChairs) 
        {
            waiting++;
            customerQueue.Enqueue(customerId); 
            Console.WriteLine($"Клієнт {customerId} очікує своєї черги.");
            customers.Release();

            mutex.Release(); 

            barbers.WaitOne();
            Console.WriteLine($"Клієнт {customerId} сідає для стрижки.");
            seatReady.Release(); 
        }
        else
        {
            Console.WriteLine($"Клієнт {customerId} залишив перукарню, бо немає вільних місць.");
            mutex.Release(); 
        }
    }

    private void CutHair(int customerId)
    {
        Console.WriteLine($"Перукар стриже клієнта з ID: {customerId}...");
        Thread.Sleep(2000); 
        Console.WriteLine($"Перукар закінчив стрижку клієнта з ID: {customerId}.");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        int maxWaitingChairs = 3; 
        int maxCustomers = 10;
        BarberShop barberShop = new BarberShop(maxWaitingChairs);
        
        Thread barberThread = new Thread(barberShop.Barber);
        barberThread.Start();

        Random rand = new Random();
        for (int i = 1; i <= maxCustomers; i++)
        {
            int customerId = i;
            Thread customerThread = new Thread(() => barberShop.Customer(customerId));
            customerThread.Start();
            Thread.Sleep(rand.Next(500, 1500)); 
        }
    }
}