using System;
using System.Collections;

namespace GarageNS
{
    public class Car
    {
        public string Vendor { get; set; }
        uint Speed { get; set; }
        public Car(string v, uint s)
        {
            Vendor = v;
            Speed = s;
        }
        public override string ToString()
        {
            return string.Format("vendor: {0}, speed : {1}", Vendor, Speed);
        }

    }
   public  class Garage: IEnumerable
    {

        private Car[] garage;
        public Garage(int size = 3)
        {
            garage = new Car[size > 0 ? size : 3];// [null][][]
        }
        public Car this[int ind]
        {
            get
            {
                if (ind < 0 || ind >= garage.Length) ind = 0;
                return garage[ind];
            }
            set
            {
                if (ind < 0 || ind >= garage.Length) return;

                garage[ind] = value;
            }
        }
        public int Size
        {
            get
            {
                return garage.Length;
            }
        }
        //public IEnumerator GetEnumerator()
        //{
        //    return garage.GetEnumerator();// викликали метод GetEnumerator(), визначений для масиву
        //}

        public IEnumerator GetEnumerator()
        {
            foreach (Car c in garage)
            {
                yield return c;// створили перелічувач, return - значення яке повертає перелічувач,
                // yield - повертає управління викликаючому методу, але стан викликаного метода зберігається і він продовжує своє виконання
            }
            //компілятор перетворює методи ітератора у закритий клас, що реалізує інтерфейси ІEnumerator або ІEnumerable
        }
    }
}
