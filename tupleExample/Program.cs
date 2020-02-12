using System;

namespace tupleExample
{

    public class IntResult 
    {
        public bool parse { get; set; }
        public int Number{ get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //튜플이란, 유한 개의 원소로 이뤄진 정렬된 리스트를 의미 
            //메서드의 인자 또는 반환에 대해 다중값을 한번에 전달할 수 있음

            Program pg = new Program();

            //tryparse를 사용하여 형변환
            tryparse("15a");
            
            IntResult result = pg.ParseInteger("15a");

            Console.WriteLine(result.parse);
            Console.WriteLine(result.Number);

            //튜플 사용 
            Tuple<bool, int> result1 = pg.TupParseInteger("15");

            Console.WriteLine(result1.Item1);
            Console.WriteLine(result1.Item2);



        }

        IntResult ParseInteger(string text) {
            IntResult result = new IntResult();

            try
            {
                result.Number = int.Parse(text);
                result.parse = true;
            }
            catch  
            {
                result.parse = false;
            }

            return result;
        }

        Tuple<bool, int> TupParseInteger(string text)
        {
            int Number = 0;
            bool result = false;

            try
            {
                Number = int.Parse(text);
                result = true;
            }
            catch
            {
                result = false;
            }

            return Tuple.Create(result, Number);
        }

        static void tryparse(string num) {

            if (int.TryParse(num, out int result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("안됨");
            }
        }


    }
}
