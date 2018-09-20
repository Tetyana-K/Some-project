using System;
using System.Collections;
using System.Text;

namespace NamedIterator
{
    class Letter
    {
        char ch = 'A';
        int end; //кількість букв

        public Letter(int end)
        {
            this.end = end;
        }

        // ітератор, повертає end-букв
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.end; i++)
            {
                if (ch + i >  'Z') 
                    yield break; // Вихід з ітератора, якщо завершився алфавіт
                yield return (char)(ch + i); // інакше повертаємо букву
            }
        }

        // Створення іменованого ітератора
        public IEnumerable MyItr(int begin, int end)
        {
            for (int i = begin; i <= end; i++)
            {
                if (ch + i > 'Z') yield break; 
                yield return (char)(ch + i);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Default;
            Console.Write("Введіть кількість букв для виводу : "); 
            int i = int.Parse(Console.ReadLine());

            Letter lt = new Letter(i);
            Console.WriteLine("\nРезультат: \n");

            foreach (char c in lt)
                Console.Write(c + " ");

            Console.Write("\nВведіть ліву межу(число) : ");
            int left = int.Parse(Console.ReadLine());
            Console.Write("\nВведіть праву межу(число) : ");
            int right = int.Parse(Console.ReadLine());
            
            Console.WriteLine("\nРезультат: \n");

            foreach (char c in lt.MyItr(left, right))
                Console.Write(c + " ");

            Console.ReadLine();
        }
    }
}


 

