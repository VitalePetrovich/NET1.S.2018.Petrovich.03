using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static TasksDay03.Day03;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindNthRoot(-0.027, 3, 0.0001));
            Console.WriteLine(FindNextBiggerNumber(254));

            Console.ReadKey();
        }
    }
}
