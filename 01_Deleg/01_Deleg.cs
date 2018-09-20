using System;

using System.Text;

namespace Deleg
{
    delegate double DelCalc(double first, double second); // тип делегата, такого типу делегати можуть посилатися на метод з відповідною сигнатурою
    class Calc
    {
       double   number;

       internal Calc(double num)
        {
            number = num;
            
        }
       internal static double Add(double a, double b)
        {
            return a + b;
        }
       internal static double Sub(double a, double b)
        {
            return a - b;
        }
       internal double Mult(double a, double b)
        {
            return number = a * b;
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
            DelCalc d1 = Calc.Add; //створили екзмепляр делегата, який посилається на стат.метод Calc.Add
            Console.WriteLine("d1 = Calc.Add; d1(2, 3) : {0}", d1(2, 3));  //виклик методу через делегат
            Console.WriteLine("Method.Name : {0}\nTarget : {1}", d1.Method.Name, d1.Target); //інформація про метод(екз MethodInfo), інформація про обєкт(object)- тут null


            d1 = Calc.Sub; //тут d1 посилається на стат.метод Calc.Add
            Console.WriteLine("\nd1 = Calc.Sub; d1(2, 3) : {0}", d1(2, 3));
            Console.WriteLine("\nd1.Invoke(20, 15); : {0}", d1.Invoke(20, 15));//виклик методу через делегат
            Console.WriteLine("Method.Name : {0}\nTarget : {1}", d1.Method.Name, d1.Target);//Target = null, метод статичний


            Calc calc = new Calc(10);
            d1 = calc.Mult;
            Console.WriteLine("\nd1 = Calc.Mult; d1(3, 4) : {0}", d1( 3, 4));
            Console.WriteLine("Method.Name : {0}\nTarget : {1}", d1.Method.Name, d1.Target);// Target = calc

            Console.WriteLine("\nd1 = Calc.Mult; d1(2, 5) : {0}", d1(21, 5));
            Console.WriteLine("Method : {0}\nTarget : {1}", d1.Method, d1.Target);
         

            Console.WriteLine("\ncalc : {0}" , calc);

            DelCalc d2 = new DelCalc(Calc.Add); //створили екзмепляр делегата
            Console.WriteLine("\nDelCalc d2 = new DelCalc(Calc.Add);\nd2(340, 120) : {0}", d2(340, 120));
            Console.WriteLine("\nd2.Invoke(100, 111) : {0}\n", d2.Invoke(100, 111));
            

        }
    }
}
