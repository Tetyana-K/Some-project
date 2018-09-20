using System;

namespace ArrInteger
{
    class Program
    {
        static void Main(string[] args)
        {
           
            MyArray A = new MyArray(5);
            A[0] = 12;
            A[1] = 15;
            A[A.Size - 1] = 78;
            Console.WriteLine(A);

            foreach (var el in A)
            {
                Console.WriteLine(el);
            }
           
        }
    }
}
