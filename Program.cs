using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list1 = new MyList<int>();
            MyList<int> list2 = new MyList<int>();

            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);

            Console.WriteLine(list1.ToString());
            Console.WriteLine(list1.GetAt(4));
            list1.SetAt(6, 4);
            Console.WriteLine(list1.ToString());
            list1.InsertAt(5, 4);
            Console.WriteLine(list1.ToString());
            list1.DeleteAt(5);
            Console.WriteLine(list1.ToString());
            Console.WriteLine(list1.Contains(6));
            Console.WriteLine(list1.Contains(5));

            list2.Add(6);
            list2.Add(7);
            list2.Add(8);
            list2.Add(9);
            list2.Add(10);

            list1.ListsCombined(list2);
            Console.WriteLine(list1.ToString());
            Console.WriteLine(list1.Size);
            list1.Clear();
            Console.WriteLine(list1.IsEmpty);
            Console.WriteLine(list1.Size);

            ///list1.SetAt(100, 100);
        }
    }
}
