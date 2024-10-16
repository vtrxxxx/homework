using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace homework_lesson5
{
    internal class Play : IDisposable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        private bool disposed = false; 
        public Play(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
            Console.WriteLine($"П'єса '{Title}' створена!");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Назва: {Title}");
            Console.WriteLine($"Автор: {Author}");
            Console.WriteLine($"Жанр: {Genre}");
            Console.WriteLine($"Рік написання: {Year}");
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                Console.WriteLine($"Звільняються керовані ресурси для п'єси '{Title}'...");
            }
            Console.WriteLine($"Звільняються некеровані ресурси для п'єси '{Title}'...");
            disposed = true;
        }


        ~Play()
        {
            Console.WriteLine($"П'єса '{Title}' знищена!");
            Dispose(false);
        }
    }

    public class Shop : IDisposable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ShopType { get; set; }

        private bool disposed = false;

        public Shop(string name, string address, string shopType)
        {
            Name = name;
            Address = address;
            ShopType = shopType;
            Console.WriteLine($"Магазин '{Name}' створений!");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Назва магазину: {Name}");
            Console.WriteLine($"Адреса: {Address}");
            Console.WriteLine($"Тип магазину: {ShopType}");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                Console.WriteLine($"Звільняються керовані ресурси для магазину '{Name}'...");
            }
            Console.WriteLine($"Звільняються некеровані ресурси для магазину '{Name}'...");
            disposed = true;
        }

        ~Shop()
        {
            Dispose(false);
            Console.WriteLine($"Магазин '{Name}' знищений!");
        }
    }

}
