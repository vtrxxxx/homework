using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_lesson3
{
    internal interface ISort
    {
        void SortAsc(); 
        void SortDesc(); 
        void SortByParam(bool isAsc);
        
    }
}
