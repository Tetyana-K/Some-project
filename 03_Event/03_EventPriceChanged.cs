using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events
{
    delegate void PriceChangedHandler();
    class Product
    {
        public  event PriceChangedHandler PriceChanged; 
        float price;
        public Product(string n, float p)
        {
            Name =  n ?? "Noname";
            price = p > 0 ? p : 1;
        }
        public string Name { get; set; }
        public float Price
        {
            get { return price; }
            set 
            {
                if (price != value)
                {
                    if (PriceChanged != null)
                        PriceChanged();
                }
                price = value;
                
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product a = new Product("water", 10.5f);
            a.PriceChanged += delegate //додали в обробники події  анонімний метод - обробник
            {
                Console.WriteLine("Price was changed!");
            };
            a.PriceChanged += ClassHandler.WasChanged;//додали ще один обробник з класу ClassHandler
            a.Price = 12;
            
        }
    }
    class ClassHandler
    {
        static public  void WasChanged()
        {
            Console.WriteLine(".....Price was changed!......");

        }
    }

}
