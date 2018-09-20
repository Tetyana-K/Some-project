using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_ev
{
    class MyArgs : EventArgs
    {
        string message;
        public MyArgs(string message)
        {
            this.message = message;
        }
        public string Message 
        { 
            get { return message; }
        }
    }
    class Clock
    {
        public event EventHandler<MyArgs> midnight;
        uint hour = 0;
        public Clock(uint hour = 0)
        {
            this.Hour = hour;
        }
        public uint Hour
        {
            get { return hour; }
            set { hour = value < 24 ? value : 0;}
        }
        public void Tick()
        {
            ++hour;
            if(hour == 24)
            {
                hour = 0;
                OnMidNight(new MyArgs("MidNight!\n"));
            }
        }
        protected virtual void OnMidNight(MyArgs eargs)
        {
            if (midnight != null)
                midnight(this, eargs);
        }
    }
    class MyEventArgs
    {
        static void Main(string[] args)
        {

            Clock clock = new Clock(20);
            clock.midnight += OnCatchMidnigh; 
            
            do
            {
                clock.Tick();
                Console.WriteLine(clock.Hour);
                System.Threading.Thread.Sleep(200);
            }while (!Console.KeyAvailable);;
        }

        static void OnCatchMidnigh(object sender, MyArgs eargs )
        {
            Console.WriteLine("Attention! " + eargs.Message);
        }
    }
}
