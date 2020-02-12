using System;

namespace eventTest
{

    class TestClass
    {
        //이벤트용 델리케이트 선언
        public delegate void ClickEvent(object sender, EventArgs args);
        //이벤트 선언
        public event ClickEvent ExamEvent;

        //클릭 함수
        //실행 함수 - 2
        public void click() 
        {
            //이벤트 함수를 생성
            EventArgs args = new EventArgs();
            //이벤트를 호출
            ExamEvent(this, args);
        }
    }
    class Program : TestClass
    {
        static void Main(string[] args)
        {
            new Program();
        }
        public Program() 
        {
            //이벤트를 생성
            //실행순서 - 3
            this.ExamEvent += new ClickEvent(Program_ExamEvent);
            //클릭!
            //실행순서 - 1
            click();
        }
        //생성자에게 클릭을 누르면 이벤트 호출로 불린다. 
        void Program_ExamEvent(object sender, EventArgs args) 
        {
            Console.WriteLine("이벤트");
        }
    }
}
