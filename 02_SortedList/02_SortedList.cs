using System;
using System.Collections;
//using System.Collections.Generic;


namespace SortedListEx
{
     class Program
    {
        static void Main(string[] args)
        {
            SortedList sl = new SortedList(); //  колекція може містити пари (ключ, значення),  допускає однорідні пари
            sl.Add(5, "C#");
            sl.Add(2, "Java");
            sl.Add(3, "Python");
            sl.Add(1, "SQL");
            sl[6] = "C"; //  // [] доступ по ключу  до значення (set, get)
            sl[4] = "JScript";
            sl[7] = "PHP";
            sl[8] = "Rails";
            sl[6] = "C++";
            sl[10] = null;
            // sl[12.5] = "SomeLang"; // exception


                       

            PrintKeys(sl);
            PrintValues(sl);
            PrintSL(sl);
            Console.WriteLine("\nsl.ContainsKey(5) : {0}", sl.ContainsKey(5));
            Console.WriteLine("sl.ContainsValue(\"Java\") : {0}", sl.ContainsValue("Java"));

            int i = sl.IndexOfKey(5);
            Console.WriteLine("\ni = sl.IndexOfKey(5) : {0}", i);
            i = sl.IndexOfValue("SQL");
            Console.WriteLine("i = sl.IndexOfValue('SQL') : {0}", i);

            int key;
            Console.WriteLine("\nInput key(integer):");
            key = int.Parse(Console.ReadLine());
            sl[key] = "Go";
            sl[key * 2] = "VB.NET";
            sl.RemoveAt(1); // delete pair by index from SortedList
            sl.Remove(10); // delete  pair by key from SortedList
            PrintSL(sl);

            // DictionaryEntry - структура, визначає пару(ключ, значення)
            
            foreach (DictionaryEntry pair in sl)
                Console.WriteLine("key: {0}, value: {1}", pair.Key, pair.Value);


        }

        static void PrintKeys(SortedList list)
        {
            foreach (var key in list.GetKeyList())
                Console.Write("{0,10}", key);
            Console.WriteLine("\n");
        }

        static void PrintValues(SortedList list)
        {
            foreach (var val in list.GetValueList())
                Console.Write("{0,10}", val);
            Console.WriteLine("\n");
        }

        static void PrintSL(SortedList list)
        {
            for (int i = 0; i < list.Count; ++i)
                Console.WriteLine("{0} {1}", list.GetKey(i), list[list.GetKey(i)]);//list.GetByIndex(i));
            Console.WriteLine("\n");
            
        }
    }
}
