using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_assignment
{
    class Program
    {
        public delegate void  num(int m);
        static void Main  (string [] args)
        {
            int number;
            Console.WriteLine("ENTER THE NUMBER");
            number = int.Parse(Console.ReadLine());
            numericformats n = new numericformats();
            
             num nm= n.printnumber;
             nm+=n.printMoney;
            nm+=n. printHexadecimal;
            nm(number);
        }
    }
}
