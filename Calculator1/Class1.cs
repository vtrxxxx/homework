using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1
{
    public class Calculator
    {
        public double Add(double a, double b) { return a + b; }
        public double Subtract(double a, double b) { return a - b; }
        public double Multiply(double a, double b) { return a * b; }
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Ошибка: Деление на ноль невозможно.");
            }
            return a / b;
        }

        public void RunCalculator()
        {
            bool continueCalculating = true;

            while (continueCalculating)
            {
                try
                {
                    Console.Write("Введите первое число: ");
                    double num1 = double.Parse(Console.ReadLine());                  

                    Console.Write("Выберите операцию (+, -, *, /): ");
                    char operation = char.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Введите второе число: ");
                    double num2 = double.Parse(Console.ReadLine());

                    double result = Calculate(num1, num2, operation);

                    Console.WriteLine($"{num1} {operation} {num2} = {result}");

                }
                
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    continue;
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: неверный формат ввода. Пожалуйста, введите данные корректно.");
                    Console.WriteLine();
                    continue;
                }

                while (true)
                {
                    Console.WriteLine("Хотите выполнить ещё один расчет? (да/нет):");
                    string answer = Console.ReadLine().ToLower();

                    if (answer == "да")
                    {
                        continueCalculating = true;
                        Console.WriteLine();                       
                        break;
                        
                        
                    }
                    else if (answer == "нет")
                    {
                        continueCalculating = false;
                        Console.WriteLine("До встречи!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Пожалуйста, введите 'да' или 'нет'.");
                        Console.WriteLine();
                    }

                }
            }
            
        }
        private double Calculate(double _num1, double _num2 , char _operation)
        {
            if (_operation == '+')
            {
                return Add(_num1, _num2);
            }
            else if (_operation == '-')
            {
                return Subtract(_num1, _num2);
            }
            else if (_operation == '*')
            {
                return Multiply(_num1, _num2);
            }
            else if (_operation == '/')
            {
                return Divide(_num1, _num2);
            }
            else
            {
                throw new InvalidOperationException("Ошибка: Неизвестная операция");
            }
        }
    }
}