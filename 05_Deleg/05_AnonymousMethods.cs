using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousMethods
{
    class Program
    {
        delegate int CalcDeleg(int a);
        delegate double CalcAverageDeleg(params int[] a);
        delegate int Transformer(ref int a);
        static void Main(string[] args)
        {
            CalcDeleg sqr = delegate(int x) { return x * x; }; // анонімний метод
            Console.WriteLine("sqr(11) : {0}", sqr(11));

            CalcDeleg cube = delegate(int x) { return sqr(x) * x; };
            Console.WriteLine("cube(5) : {0}", cube(5));

            int number = 10;
            CalcDeleg summ = delegate(int x) { return number + x; }; //захоплення змінної number
            ++number; // number = 11
            Console.WriteLine("\navg(5) : {0}", summ(5)); // 11  + 5

            CalcDeleg r = delegate { return number; }; // якщо параметр неважливий(не використовується) - можна опустити
            Console.WriteLine(r(12345)); // 11 



            CalcAverageDeleg s = delegate(int[] a)
            {
                double avg = 0;
                for (int i = 0; i < a.Length; ++i)
                    avg += a[i];
                return avg / a.Length;
            };
            Console.WriteLine("Average(2, 2, 5, 4) : {0}", s(2, 3, 5, 4));


            Transformer t =   (ref int a) => --a ; // записали лямбду у екземпляр делегата
            Console.WriteLine("{0} {1}", t(ref number), number );
        }
    }
}
