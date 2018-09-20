using System;

namespace DelegateAsParameter
{
    
    class Program
    {
        delegate void Transformer(ref int value);
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 3, 11, -7, 2, 5 };
            Print(arr);

            Console.WriteLine("\nChangeArray(arr, Inc);");
            ChangeArray(arr, Inc);
            Print(arr);

            Console.WriteLine("\nChangeArray(arr, Mult2);");
            ChangeArray(arr, Mult2);
            Print(arr);

            Console.WriteLine("\nChangeArray(arr,  (ref int x) => x = x * x);");
            ChangeArray(arr, (ref int x) => x = x * x);// використали лямбда -функцію
            Print(arr);

            Console.WriteLine("\nChangeArray(arr,  (ref int x) => x = d++);");
            int d = 0;
            ChangeArray(arr, (ref int x) =>
                { x = d++; } // захоплення зовнішнньої для лямбди змінної d. Таке лямбда називають - замиканням.
            );

            Print(arr);

            Console.WriteLine("\nChangeArray replaces elements with factorials");
            ChangeArray(arr, (ref int x) => { 
                int f = 1;
                for(int i = 2; i <=x; ++i)
                f = f * i;
                x  = f; });
            /*
            int f = 1, i = 1;
            ChangeArray(arr, (ref int x) =>
            {
               
                    f = f * i++;
                    x = f;
            });*/
            Print(arr);

        }
     static void ChangeArray(int []arr, Transformer t)
        {
            for (int i = 0; i < arr.Length; ++i )
                t(ref arr[i]);

          
        }
        static void Inc(ref int value)
        {
            value++;
        }
       static void Mult2(ref int value)
        {
            value *= 2;
        }
        public static void Print(int[] arr)
        {
            foreach (int e in arr)
                Console.Write("{0,7}", e);
            Console.WriteLine();
        }

    }
}
