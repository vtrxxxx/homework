using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson4_HomeWork
{
    internal class Employee
    {
        private decimal salary;

        public decimal Salary
        {
            get { return salary;}
            set 
            {
                if (value >= 0)
                    salary = value;
            }
        }

        public Employee( decimal salary)
        {
            this.Salary = salary;
        }

        public static Employee operator +(Employee emp, decimal amount)
        {
            emp.Salary += amount;
            return emp;
        }

        public static Employee operator -(Employee emp, decimal amount)
        {
            emp.Salary -= amount;
            return emp;
        }

        public static bool operator ==(Employee emp1, Employee emp2)
        {
            return emp1.Salary == emp2.Salary;
        }

        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return emp1.Salary != emp2.Salary;
        }

        public static bool operator <(Employee emp1, Employee emp2)
        {
            return emp1.Salary < emp2.Salary;
        }

        public static bool operator >(Employee emp1, Employee emp2)
        {
            return emp1.Salary > emp2.Salary;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Employee))
                return false;
            return this.Salary == ((Employee)obj).Salary ;
        }


        public override int GetHashCode()
        {
            return this.Salary.GetHashCode();
        }

    }

    public class City
    {
        private int population;

        public int Population
        {
            get { return population; }
            set
            {
                if (value >= 0)
                    population = value;
            }
        }

        public City( int population)
        {
            this.Population = population;
        }

        public static City operator +(City city, int populationIncrease)
        {
            city.Population += populationIncrease;
            return city;
        }

        public static City operator -(City city, int populationDecrease)
        {
            city.Population -= populationDecrease;
            return city;
        }

        public static bool operator ==(City city1, City city2)
        {
            return city1.Population == city2.Population;
        }

        public static bool operator !=(City city1, City city2)
        {
            return city1.Population != city2.Population;
        }

        public static bool operator <(City city1, City city2)
        {
            return city1.Population < city2.Population;
        }

        public static bool operator >(City city1, City city2)
        {
            return city1.Population > city2.Population;
        }

        public override bool Equals(object ?obj)
        {
            if (obj == null || !(obj is City))
                return false;
            return this.Population == ((City)obj).Population;
        }

        public override int GetHashCode()
        {
            return this.Population.GetHashCode();
        }

    }

    public class CreditCard
    {
        private int cvc;
        private decimal balance;

        public int Cvc { get { return cvc; } set { cvc = value; } }
        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                    balance = value;
            }
        }
        public CreditCard(int cvc, decimal balance)
        {
            this.Cvc = cvc;
            this.Balance = balance;
        }

        public static CreditCard operator + (CreditCard card , decimal amount)
        {
            card.Balance += amount;
            return card;
        }

        public static CreditCard operator -(CreditCard card, decimal amount)
        {
            card.Balance -= amount;
            return card;
        }

        public static bool operator ==(CreditCard card1, CreditCard card2)
        {
            return card1.Cvc == card2.Cvc;
        }

        public static bool operator !=(CreditCard card1, CreditCard card2)
        {
            return card1.Cvc != card2.Cvc;
        }

        public static bool operator <(CreditCard card1, CreditCard card2)
        {
            return card1.Balance < card2.Balance;
        }
        public static bool operator >(CreditCard card1, CreditCard card2)
        {
            return card1.Balance > card2.Balance;
        }

        public override bool Equals(object? obj)
        {
           if (obj == null || !(obj is CreditCard)) return false;

            return this.Cvc == ((CreditCard)obj).Cvc && this.Balance == ((CreditCard)obj).Balance;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Cvc, this.Balance);
        }
    }


}
