using System;
using System.Collections.Generic;


namespace Iterators
{
    class Program
    {
        static void Main(string[] args)
        {
            // ітератор - створює перелічувач(для циклу foreach)
            // ітератор- метод, властивість чи індексатор, містить оператор yield
            foreach (var number in PairNumbers(10))
            {
                Console.Write("{0,5}", number);
            }
            Console.WriteLine("\n");

            foreach (var d in Days())
            {
                Console.Write("{0,10}", d);
            }
            Console.WriteLine("\n");

            foreach(int num in PairAndDivToSeven(PairNumbers(100))) // композиція ітераторів
            {
                Console.Write("{0,5}", num);
            }
            Console.WriteLine();

        }

        //ітератор може повертати System.Collections.IEnumerable, System.Collections.IEnumerable<>(простіші у використанні)
        // System.Collections.IEnumerator або  System.Collections.IEnumerator<>
        static IEnumerable<int> PairNumbers(int n)  
        {
            yield return 2;
            yield return 4;
            for (int i = 6; i < n; i += 2)
            {
                yield return i;
            }
        }
        static IEnumerable<string> Days()
        {
            string []days = {"sunday", "monday", "tuesday","wednesday",  "thursday", "friday", "saturday"};
            foreach(string day in days)
                 yield return day;
        }
        static IEnumerable<int> PairAndDivToSeven(IEnumerable<int> pairs)  //параметром методу  може бути  ітератор
        {
            foreach (int num in pairs)
            {
                if (num % 7 == 0)
                    yield return num;
            }
        }
    }
}
