namespace homework_lesson3
{
    internal class Program
    {
        static void Main(string[] args)
        { 
             MyArray Array = new MyArray();
            Array.Show();
            Array.Show("Massage");
            Console.WriteLine(Array.Search(2));
            Console.WriteLine(Array.Max());
            Console.WriteLine(Array.Min());
            Console.WriteLine(Array.Avg());
            Array.SortAsc();
            Array.Show();
            Array.SortDesc();
            Array.Show();
            Array.SortByParam(true);
            Array.Show();
            Array.SortByParam(false);
            Array.Show();

            Console.ReadKey();


        }
    }
}
