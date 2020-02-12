using System;
using System.Threading;

namespace test
{

    class TestClass
    {
        //이벤트용 델리게이트 선언
        public delegate void ClickEvent(object sender, EventArgs args);
        //이벤트 선언
        public event ClickEvent ExamEvent;
        //클릭 함수
        public void click() 
        {
            //이벤트 함수를 생성
            EventArgs args = new EventArgs();
            ExamEvent(this, args);
        }

    }
    class Program : TestClass
    {
        static void Main(string[] args)
        {
            new Program();
        }

        Thread _thread;
        string inputData;
        public Program() 
        {
            this.ExamEvent += new ClickEvent(Program_ExamEvent);
            //스레드 가동!!
            _thread = new Thread(new ThreadStart(ExThread_Method));
            _thread.Start();

            //무한루프
            //사용자로부터 exit 입력받으면 종료한다. 
            while (true) 
            {
                inputData = Console.ReadLine();
                if (inputData == "exit") 
                {
                    _thread.Abort();
                    break;
                }
                Console.WriteLine("\n\nProgram's processing is ished...\nPress any key...");
                Console.ReadLine();
              
            }


        }
        public void ExThread_Method() 
        {
            while (true) 
            {
                //사용자로부터 on 메세지를 맏으면 click()을 발생시킴
                if (inputData == "on") 
                {
                    click();
                }
                Thread.Sleep(1000);
            }
        }

        void Program_ExamEvent(object sender, EventArgs args) 
        {
            Console.WriteLine("이벤트 발생!");
        }

    }
}
