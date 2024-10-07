using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace homework_lesson3
{
    public class MyArray : IOutput, IMath, ISort
    {
        private int[] myArray = new int[5];

       public MyArray() 
       {
            myArray = new int[] { 0, 3, 2, 1, 5 };
        }

        public void Show()
        {
            Console.WriteLine(String.Join(", ", myArray));
        }
        public void Show(string info) 
        {
            Console.Write(String.Join(", ", myArray));

            Console.WriteLine($" => {info}");
        }

        public int Max()
        {
            return myArray.Max();
        }
        public int Min()
        {
            return myArray.Min();
        }
        public float Avg()
        {
            return (float)myArray.Sum() / myArray.Length; 
        }

        
        public bool Search(int valueToSearch)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] == valueToSearch)
                {
                    return true;
                }
            }
            return false;
        }

        public void SortAsc()
        {
            Array.Sort(myArray);
        }

        public void SortDesc()
        {
            Array.Sort(myArray);
            Array.Reverse(myArray);
        }

        public void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }

    }
}
