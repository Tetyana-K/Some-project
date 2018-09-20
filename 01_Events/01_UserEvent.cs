using System;

namespace Events
{
    delegate void UI();// делегат, який може посилатися на методи, що нічого не приймають і нічого не повертають

    class MyEvent// Publisher, Broadcaster - Видавець події(й)
    {

        public event UI UserEvent;// Оголосили подію типу делегата UI, 
      // тут вказання event посилює безпеку коду, мета події - не допустити взаємодії піж підписувачами
        //  тобто 1) допускається використаня операцій += та -= 
        // 2) не допускається = (заміна ), =  null(видалення всіх підписувачів)

      
        public void OnUserEvent() //метод для ініціювання(запуску, виклику) події,   Raise event
        {
            if(UserEvent != null)
                UserEvent(); //виклик делегата
        }
    }

    class UserInfo
    {
        string uiName, uiFamily;
        int uiAge;
      

        public UserInfo(string Name, string Family, int Age)
        {
            this.uiName = Name;
            this.uiFamily = Family;
            this.uiAge = Age;
           
        }

        public string Name { set { uiName = value; } get { return uiName; } }
        public string Family { set { uiFamily = value; } get { return uiFamily; } }
        public int Age { set { uiAge = value; } get { return uiAge; } }


        public void UserInfoHandler() // EventHandler - Обробник події
        {
            Console.WriteLine("\nEvent was initiated!");
            Console.WriteLine("\tName: {0}\n\tSurname: {1}\n\tAge: {2}", uiName, Family, Age);
        }
    }

    class Program
    {
        static void Main()
        {
            MyEvent evt = new MyEvent();
            UserInfo user1 = new UserInfo( Family: "A", Age: 25, Name: "Oleg"), // ініціалізація через задання пармаетрів конструткора у дов порядку
                user2 = new UserInfo("Ann", "D", 22) ;

           
            evt.UserEvent += user1.UserInfoHandler; // додаємо обробник події
            evt.UserEvent += user2.UserInfoHandler; // додаємо обробник події
            evt.UserEvent += () => Console.WriteLine("\nSomething happened!"); // додаємо обробник події -лямбду 
            //evt.UserEvent -= user2.UserInfoHandler;
            
            evt.OnUserEvent();
            //evt.UserEvent = user2.UserInfoHandler; //компілюється без event
            //evt.UserEvent = null; //компілюється без event

            Console.ReadLine();
        }
    }
}