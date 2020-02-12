using System;

namespace delegateTest
{
    //델리게이트 만듦
    delegate int CalcDelegate(int x, int y);
    //범용적인 델리게이트 만듦
    delegate T CalcDelegateGen<T>(T x, T y);
    class Program
    {
      
        static int Add(int x, int y ) { return x + y;}
        static int Sub(int x, int y) { return x - y;}
        public static void PrintCons(int a, int b, CalcDelegate c) { Console.WriteLine(c(a, b)); }
        public static void PrintConsGen<T>(T a, T b, CalcDelegateGen<T> c) { Console.WriteLine(c(a, b)); }
        static void Main(string[] args)
        {
            //델리게이트 선언
            //델리게이트의 파라미터는 붙일 메소드의 파라미터와 동일하게 한다. 
            CalcDelegate abc = new CalcDelegate(Add);
            Console.WriteLine(abc(4, 3)); //7

            //델리게이트에 다른 메소드도 붙일 수 있어
            abc = Sub;
            Console.WriteLine(abc(4, 3)); //1
         

            //콜백메서드와 활용해보자 
            //PrintCons <- 콜백메서드가 됨(Plus, Minus라는 메소드를 PrintCons에서 호출하니까)
            CalcDelegate Plus = new CalcDelegate(Add);
            CalcDelegate Minus = new CalcDelegate(Sub);
            PrintCons(3, 4, Plus);
            PrintCons(3, 4, Minus);

            //범용성을 추가하여 활용
            CalcDelegateGen<int> Plus_int = new CalcDelegateGen<int>(Add);
            PrintConsGen(3, 4, Plus_int);
            Console.ReadLine();
        }
     
       
    }
}
