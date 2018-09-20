using System;




namespace EventHandlerNS
{
  //  delegate void PriceChangedHandler();
    class Product
    {
        public event EventHandler PriceChanged;
        float price;
        public Product(string n, float p)
        {
            Name = n  ??  "Noname";
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
                    price = value;
                    OnPriceChanged(EventArgs.Empty);
                }
                
            }
        }
        protected  void OnPriceChanged(EventArgs e)
        {
            if (PriceChanged != null) 
                PriceChanged(this, e);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product a = new Product("water", 10.5f);
            a.PriceChanged += Product_PriceChanged;
            a.PriceChanged += delegate
            {
                Console.WriteLine("Price was changed!");
            };
           
           
            a.Price = 12;

        }


        static void Product_PriceChanged(object sender, EventArgs e)
        {
            Console.WriteLine("*************Price was changed***********!");
        }
}
}
