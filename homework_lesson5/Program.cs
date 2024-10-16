using System.Text;

namespace homework_lesson5
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            using (Play play1 = new Play("Гамлет", "Вільям Шекспір", "Трагедія", 1600))
            {
                play1.DisplayInfo();
            }

            Console.WriteLine();
            Console.WriteLine();

            Shop shop1 = new Shop("Продуктовий Рай", "вул. Центральна, 10", "Продовольчий");
            shop1.DisplayInfo();
            GC.Collect();
            Console.ReadKey();




        }
    }
}
