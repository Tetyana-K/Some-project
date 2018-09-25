using System;
using System.Collections;

using GarageNS;
namespace Enumerator_and__Enumerable
{
    
    class Program
    {
        static void Main(string[] args)
        {           

            string str = "IEnumerable";
           
            // Перелічення - послідовність значень, що допускає однонапрямлений курсор(ітератор) для читання.
            // Обєкт - перелічувач реалізує інтерфейс  System.Collections.IEnumerator або System.Collections.IEnumerator<T>

            //Перелічувальний обєкт реалізує інтерфейс ІEnumerable або метод GetEnumerator(), що повертає перелічувач
            foreach (char c in str) // обхід перелічувального обєкта(тут - рядка) за допомогою foreach
                Console.Write(c + "-");
            Console.WriteLine();


            //низькорівневий обхід рядка без foreach
            var enumerator = str.GetEnumerator(); //IEnumerator<char> enumerator = str.GetEnumerator(); - отримали перелічувач для рядка
            // str.GetEnumerator() - повертає обєкт-курсор(перелічувач) для  рядка класу string 
            while (enumerator.MoveNext()) // доки можна переміщатися по послідовності далі(не досягли кінця послідовності)
            {
                char elem = enumerator.Current; // elem = значення потоного елемента(на який посилається курсор-перелічувасч)
                Console.Write(elem + "\t");
            }
            Console.WriteLine("\n");
            //!!!перелічувальний обєкт або реалізує інтерфейс IEnumerable(IEnumerable<T>) або містить метод GetEnumerator(), щоповертає перелічувач

            int[] arr = { 1, 10, 23, 56 };
            IEnumerator enInt = arr.GetEnumerator();
            while (enInt.MoveNext())
            {
                Console.Write("{0}\t", enInt.Current);
            }

            Console.WriteLine("\n");

            Garage g = new Garage(2);
            g[0] = new Car("Audi", 155);
            g[1] = new Car("Honda", 160);

            Console.WriteLine("\tUsing for and indexator");
            for (int i = 0; i < g.Size; ++i)
                Console.WriteLine(g[i]);

            Console.WriteLine("\n\tUsing GetEnumerator()");
            IEnumerator enCars = g.GetEnumerator();
            while (enCars.MoveNext())
            {
                Console.Write("{0}\n", enCars.Current);
            }
            Console.WriteLine("\n\tUsing foreach");
            
            foreach (var car in g) // foreach потребує перелічувача
            {
                Console.Write("{0}\n", car);
 
            }
            //Car car_ = new Car();
        }
    }
}
