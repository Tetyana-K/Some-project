using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events
{
        delegate void MyDelegate();	// делегат, який може містити ф-ї, що нічого не приймають і нічого не повертають

        class Eventer
        {
            public event MyDelegate SomethingHappen;	// подія SomethingHappen є екземпляром делегата MyDelegate

            public void DoSometing(int val)
            {
                Console.WriteLine(" public DoSometing( {0} )", val);
                if (val > 13 || val < 5)	// умова виникнення події
                {
                    Console.WriteLine("\tSomethingHappen!");
                    OnSomethingHappen();						// ініціюємо подію
                }

            }// public DoSometing( int val )


            private void OnSomethingHappen()		// метод, який ініціює подію
            {
                if (SomethingHappen != null)	// якщо є підписані обробники
                {
                    SomethingHappen();
                }
            }


        }// class Eventer


        class ClassOne
        {
            public static void Handler()
            {
                Console.WriteLine("\t It is public static void Handler() from class ClassOne ");
            }

        }// class ClassOne


        class ClassTwo
        {
            public string Name { set; get; }

            public void Handler()
            {
                Console.WriteLine("\t It is public void Handler() from {0} of class ClassTwo ", this.Name);
            }
        }// class ClassTwo


        class Program
        {
            public static void Main()
            {
                Console.Clear();

                Eventer eventer = new Eventer();
                ClassTwo two = new ClassTwo();
                ClassTwo two1 = new ClassTwo();
                two.Name = "Instance 1";
                two1.Name = "Instance second";

                Random rnd = new Random();

                for (int i = 0; i < 5; i++)
                {
                    eventer.DoSometing(rnd.Next(-11, 22));
                }

                Console.WriteLine("\n\n__________ ClassOne.Handler ___________");

                // підписуємо на подію обробник ClassOne.Handler
                eventer.SomethingHappen += ClassOne.Handler;

                for (int i = 0; i < 5; i++)
                {
                    eventer.DoSometing(rnd.Next(-11, 22));
                }

                Console.WriteLine("\n\n__________ ClassOne.Handler & two1.Handler & two2.Handler ___________");
                // підписуємо на подію обробники
                eventer.SomethingHappen += two.Handler;
                eventer.SomethingHappen += two1.Handler;

                for (int i = 0; i < 5; i++)
                {
                    eventer.DoSometing(rnd.Next(-11, 22));
                }

                Console.WriteLine("\n\n__________ only ClassOne.Handler && two1.Handler ___________");

                // підписуємо на подію обробники
                eventer.SomethingHappen -= two.Handler;
                eventer.SomethingHappen -= ClassOne.Handler;

                for (int i = 0; i < 5; i++)
                {
                    eventer.DoSometing(rnd.Next(-11, 22));
                }

                Console.WriteLine("\n\n__________ Anonimous Method ___________");
                eventer.SomethingHappen += delegate()
                {
                    Console.WriteLine("\t It is Anonimous Method !!!!! ");
                };

                for (int i = 0; i < 5; i++)
                {
                    eventer.DoSometing(rnd.Next(-11, 22));
                }


            }// public static void Main()

        }// class Program




    }// namespace 

