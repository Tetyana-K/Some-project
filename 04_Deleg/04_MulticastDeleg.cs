using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multicasting_delegate
{
    public delegate void MultiDeleg(double first, double second);
    class Calc
    {
        double number;
        public Calc(double num)
        {
            number = num;
        }
        public static void Add(double a, double b)
        {
            Console.WriteLine("{0} + {1}  = {2}", a, b,  a + b);
        }
        public static void Sub(double a, double b)
        {
            Console.WriteLine("{0} - {1}  = {2}", a, b, a - b);

        }
        public void Mult(double a, double b)
        {
            Console.WriteLine("{0}  + {1} * {2}  = {3}", number,  a, b, number += a * b);

        }
        public override string ToString()
        {
            return number.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MultiDeleg md =  Calc.Add;
          
            md += Calc.Sub;
            Console.WriteLine(md.Method);

            md += Calc.Add;
            Console.WriteLine(md.Method + "\n" + md.Target);
            
            Calc calc = new Calc(100);
            md += calc.Mult;

            Console.WriteLine("{0} {1}", md.Method/*.Name*/, md.Target);
            md(11, 3);
            Console.WriteLine("calc : {0}", calc);

            md -= Calc.Add;
            md -= Calc.Add;
           
            Console.WriteLine("\nAfter md -= Calc.Add;");
            md(15, 2);
            Console.WriteLine("{0} {1}\n", md.Method, md.Target);

            Console.WriteLine("\nNOW List of delegate methods:");
           Delegate[] arrDel = md.GetInvocationList();
           foreach (Delegate d in arrDel)
           {
                Console.WriteLine("Method.Name : {0}; Target : {1}", d.Method.Name, d.Target);
           }

          // MultiDeleg z = (MultiDeleg)Delegate.Combine(md, md);
           //z(1, 2);
        }
    }
}
