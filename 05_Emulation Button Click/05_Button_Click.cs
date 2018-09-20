using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Button_Click
{
    class Button
    {
        public event EventHandler Click; //1 - event
        public void ClickMe()
        {
            OnClick(new EventArgs()); //  3 call dispatcher
        }

        protected void OnClick(EventArgs e) // 2 - dispatcher
        {
            if(Click != null)
                Click(this, e);
        }
    }
    class Button_Click
    {
        static void Main(string[] args)
        {
            Button button = new Button();
            button.Click += Button_Click.Button1_Click;
            button.ClickMe();

        }

        public static void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("It is Button1 click handler");
        }

    }
}
