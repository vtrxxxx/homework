using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_lesson2
{
    public class Money
    {
        private int _intPart;
        private int _coinPart;

        private int IntPart
        {
            get { return _intPart; }

            set
            {
                if (value >= 0)
                {
                    _intPart = value;
                }
            }
        }

        private int CoinPart
        {
            get { return _coinPart; }

            set
            {
                if (0 < value && value < 100)
                {
                    _coinPart = value;
                }
            }

        }

        public void ShowSum()
        {
            Console.WriteLine($"{_intPart} dollars {_coinPart} coins");
        }

        internal void SetSum(int intPart, int coinPart)
        {
            if (intPart == 0 && coinPart == 0)
            {
                Console.WriteLine("The sum cannot be zero.");
            }
            else
            {               
                IntPart = intPart;
                CoinPart = coinPart;
            }
        }

        public void SubstractMoney(int intToSubtract, int centsToSubtract)
        {

            int totalCents = (_intPart * 100 + _coinPart) - (intToSubtract * 100 + centsToSubtract);
            if (totalCents < 0)
            {
                Console.WriteLine("Cannot subtract more than the current amount.");

                return;
            }

            _intPart = totalCents / 100;
            _coinPart = totalCents % 100;
        }
    }

    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public Money MoneySum { get; set; }
        internal int DiscountInt { get; set; }
        internal int DiscountCoin { get; set; }

        public Product(string name, Money moneySum)
        {
            Name = name;
            MoneySum = moneySum;
        }

        public void SetDiscount(int discountInt, int discountCoin)
        {
            DiscountInt = discountInt;
            DiscountCoin = discountCoin;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Product Name: {Name}");
            Console.Write($"Price: ");
            MoneySum.ShowSum();
        }

        public void ApplyDiscount()
        {
            
            if (DiscountInt == 0 && DiscountCoin == 0)
            {
                Console.WriteLine("Discount hasn't been applied.");
            }
            else
            {
                
                MoneySum.SubstractMoney(DiscountInt, DiscountCoin);
            }
        }
    }

    public static class TaskTest1
    {
        public static void StartTest()
        {
            Money money = new Money();
            money.SetSum(200, 50);

            Product product = new Product("PS5", money);

            product.ShowInfo();
            Console.WriteLine();

            product.SetDiscount(20, 75);
            product.ApplyDiscount();
            Console.WriteLine($"After applying discount: {product.DiscountInt},{product.DiscountCoin}$");
            Console.WriteLine();
            product.ShowInfo();


        }
    }
}
