using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_assignment
{
    class numericformats
    {
        int intvalue;
        decimal decimalvalue;
        int hxvalue;


         public  void printnumber(int number)
        {

            intvalue = number;
            Console.WriteLine("GIVEN VALUE :" + intvalue.ToString("n1", CultureInfo.InvariantCulture));
        }

     

        public void printMoney(int number)
        {

            decimalvalue = number;
            Console.WriteLine("GIVEN AMOUNT :" + decimalvalue.ToString("C", CultureInfo.CurrentCulture));
        }

        public void printHexadecimal(int number)
        {
            hxvalue = number;
           
            Console.WriteLine("hexadecimal :" + hxvalue.ToString("x"));
        }
    }
}
