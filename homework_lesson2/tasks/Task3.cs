using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_lesson2
{
    public struct DecimalNumber
    {
        private int _value;

        public DecimalNumber(int value)
        {
            _value = value;
        }

        public string ToBinary()
        {
            return Convert.ToString(_value, 2);
        }

        public string ToOctal()
        {
            return Convert.ToString(_value, 8);
        }

        public string ToHexadecimal()
        {
            return Convert.ToString(_value, 16).ToUpper();
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public void Show()
        {
            Console.WriteLine($"Decimal: {_value}");
            Console.WriteLine($"Binary: {ToBinary()}");
            Console.WriteLine($"Octal: {ToOctal()}");
            Console.WriteLine($"Hexadecimal: {ToHexadecimal()}");
        }
    }

    public static class TaskTest3
    {
        public static void StartTest()
        {
            DecimalNumber decimalNumber = new DecimalNumber(228);

            decimalNumber.Show();



        }
    }
}
