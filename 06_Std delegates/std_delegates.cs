using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std_delegates_
{
    class std_delegates
    {
        public   static void PrintSquare(int a)
        {
            Console.WriteLine("Square({0}) = {1}", a, a * a);
        }
        public   static void PrintCube(int a)
        {
            Console.WriteLine("Cube({0}) = {1}", a, a * a * a);
        }
        public static void PrintValue<T>( T a)
        {
            Console.WriteLine("Value =  {0}", a);

        }
        public static int NumDigits(string s)
        {
            return s.Count(c => char.IsDigit(c));
        }
        public static int NumVowels(string s)
        {
            return s.Count(c => c == 'o' || c=='a' ||c == 'e');
        }
        static void Main(string[] args)
        {
            Action<int>  action = PrintSquare;
            action(3);

            Action<int>[] arrAct = { PrintValue<int>, PrintCube };
            foreach(var f in arrAct )
                    f(5);

            //Func<T1, out T2>
            //Func<string, int> func = NumDigits; 
           
            Func<string, int>[] func = { NumDigits, NumVowels };
            foreach (var f in func)
                Console.WriteLine(f("Good evening!"));

            Func<int, int, double> avg = (x, y) => (x + y) / 2.0;
            Console.WriteLine(avg(2, 3));
        }
      
    }
}

