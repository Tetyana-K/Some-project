using System.Collections;
using System.Text;

namespace ArrInteger
{
    class MyArray : IEnumerable//IEnumerator//,
    {
        int[] arr;

        public int Size
        {
            get
            {
                return arr.Length;
            }
        }
        public MyArray(int size)
        {
            arr = new int[size];
        }
        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            for (int i = 0; i < Size; ++i)
                result.AppendFormat("{0,5}", arr[i]);
            return result.ToString();
        }
        //public IEnumerator GetEnumerator()
        //{
        //    return arr.GetEnumerator();
        //}
         //public IEnumerator GetEnumerator()
         // {
         //     foreach(int elem in arr)
         //         yield return elem ;
         // }
          
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(this);
        }
       public  class MyEnumerator : IEnumerator // створили свій клас перелічувача
        {
            MyArray myarray; //посилання на масив
            int current = -1; // позиція елемента
            public MyEnumerator(MyArray myarr)
            {
                myarray = myarr;
                this.Reset();
            }

            public void Reset()
            {
               
               current = -1;
            }
            public bool MoveNext()
            {
               ++current;
                return current < myarray.Size;

            }
            public object Current
            {
                get
                {
                    return myarray.arr[current];
                }
            }
        }
    }
}
