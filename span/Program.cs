using System;

namespace span
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new byte[] { 0, 1, 2, 3, 4, 5};
            Span<byte> view = arr;

            Console.WriteLine(view[5]);

            //인스턴트 span은 원본을 관리하는 포인터로 가리키고 있어 값 변경까지 허용한다. 
            view[5] = 17;
            Console.WriteLine("값 변경 허용 -> "+view[5]);

            //span의 진정한 힘은 view 영역을 제어!!
            //힙을 사용하지 않아 가비지를 생성하지 않는다 
            var arr1 = new byte[] {0, 1, 2, 3, 4, 5, 6, 7};
            Span<byte> view1 = arr1;

            Span<byte> viewLeft = view1.Slice(0,4);
            var viewRight = view1.Slice(4);

            Print(viewLeft);
            Print(viewRight);

            //가비지를 생성하지 않아 성능향상을 가져온다.
            //예를 들어
            string input = "100,200";
            int pos = input.IndexOf(",");

            string v1 = input.Substring(0, pos);    //"100" 힙 할당
            string v2 = input.Substring(pos + 1);   //"200" 힙 할당 

            Console.WriteLine(int.Parse(v1));
            Console.WriteLine(int.Parse(v2)); 

            ReadOnlySpan<char> view_span = input.AsSpan();

            ReadOnlySpan<char> vs1 = view_span.Slice(0, pos);   //힙 할당 없음
            ReadOnlySpan<char> vs2 = view_span.Slice(pos + 1);  //힙 할당 없음

            Console.WriteLine(int.Parse(vs1));
            Console.WriteLine(int.Parse(vs2));

        }

        private static void Print(Span<byte> view) 
        {
            foreach (byte elem in view) 
            {
                Console.Write(elem + ", ");
            }
            Console.WriteLine();
        }

    }
}
