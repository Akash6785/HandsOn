using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
   public class CalcMethods
    {
        int result = 0;
        public int Add(int first, int last)
        {
            result = first + last;
            return result;
        }
       

        public int Sub(int number1, int number2)
        {

           result = number1-number2;
            return (result);
        }

        public int Mul(int number1, int number2)
        {
            result = number1 * number2;
            return (result);
        }

        public int Div(int number1, int number2)
        {
            if (number2 == 0)
            {
                throw new ArgumentException();
            }
            result = number1 / number2;
            return (result);
        }

      
        public int Result { get; }
        public void AllClear()
        {
            result = 0;
        }


    }
}


