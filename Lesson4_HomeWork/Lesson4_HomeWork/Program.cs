namespace Lesson4_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тестирование класса Employee");
            Employee emp1 = new Employee(5000);
            Employee emp2 = new Employee(5500);
            Employee emp3 = new Employee(5000);

            Console.WriteLine($"emp1 == emp2: {emp1 == emp2}"); 
            Console.WriteLine($"emp1 == emp3: {emp1 == emp3}"); 
            Console.WriteLine($"emp1 != emp2: {emp1 != emp2}");

            Console.WriteLine($"emp1.Equals(emp2): {emp1.Equals(emp2)}");
            Console.WriteLine($"emp1.Equals(emp3): {emp1.Equals(emp3)}");

            emp1 += 500;
            Console.WriteLine($"Зарплата emp1 после увеличения: {emp1.Salary}"); 
            emp1 -= 1000;
            Console.WriteLine($"Зарплата emp1 после уменьшения: {emp1.Salary}"); 

            Console.WriteLine($"emp1 > emp2: {emp1 > emp2}"); 
            Console.WriteLine($"emp1 < emp2: {emp1 < emp2}");  

            Console.WriteLine("\nТестирование класса City");
           
            City city1 = new City(2800000);
            City city2 = new City(720000);
            City city3 = new City(2800000);

            Console.WriteLine($"city1 == city2: {city1 == city2}"); 
            Console.WriteLine($"city1 == city3: {city1 == city3}"); 
            Console.WriteLine($"city1 != city2: {city1 != city2}"); 

            Console.WriteLine($"city1.Equals(city2): {city1.Equals(city2)}"); 
            Console.WriteLine($"city1.Equals(city3): {city1.Equals(city3)}"); 

            city1 += 50000;
            Console.WriteLine($"Население city1 после увеличения: {city1.Population}"); 
            city1 -= 100000;
            Console.WriteLine($"Население city1 после уменьшения: {city1.Population}");

            Console.WriteLine($"city1 > city2: {city1 > city2}"); 
            Console.WriteLine($"city1 < city2: {city1 < city2}"); 

            Console.WriteLine("\nТестирование класса CreditCard");

            CreditCard card1 = new CreditCard(123, 1000m);
            CreditCard card2 = new CreditCard(456, 1500m);
            CreditCard card3 = new CreditCard(123, 1000m);

            Console.WriteLine($"card1 == card2: {card1 == card2}"); 
            Console.WriteLine($"card1 == card3: {card1 == card3}"); 
            Console.WriteLine($"card1 != card2: {card1 != card2}");

            Console.WriteLine($"card1.Equals(card2): {card1.Equals(card2)}"); 
            Console.WriteLine($"card1.Equals(card3): {card1.Equals(card3)}");

            card1 += 200m;
            Console.WriteLine($"Баланс card1 после увеличения: {card1.Balance}");
            card1 -= 300m;
            Console.WriteLine($"Баланс card1 после уменьшения: {card1.Balance}");

            Console.WriteLine($"card1 > card2: {card1 > card2}");
            Console.WriteLine($"card1 < card2: {card1 < card2}");

            Console.ReadLine(); 

        }
    }
}
