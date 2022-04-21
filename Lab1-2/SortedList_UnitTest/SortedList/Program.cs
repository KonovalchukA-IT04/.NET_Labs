using System;

namespace SortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var alist = new OwnList<int>();

            var blist = new OwnList<string>();

            var asorted = new OwnSortedList<int>();

            var bsorted = new OwnSortedList<string>();


            alist.Add(3);
            alist.Add(1);
            alist.Add(2);
            alist.Add(4);
            alist.Add(6);
            alist.Add(5);
            alist.Add(8);
            alist.Add(7);
            alist.ConnectEvents(true);
            
            blist.Add("c");
            blist.Add("a");
            blist.Add("b");
            blist.Add("d");
            blist.Add("f");
            blist.Add("e");
            blist.Add("h");
            blist.Add("g");
            blist.ConnectEvents(true);

            asorted.Add(3);
            asorted.Add(1);
            asorted.Add(2);
            asorted.Add(4);
            asorted.Add(6);
            asorted.Add(5);
            asorted.Add(8);
            asorted.Add(7);
            asorted.ConnectEvents(true);

            bsorted.Add("c");
            bsorted.Add("a");
            bsorted.Add("b");
            bsorted.Add("d");
            bsorted.Add("f");
            bsorted.Add("e");
            bsorted.Add("h");
            bsorted.Add("g");
            bsorted.ConnectEvents(true);

            foreach (var item in alist)
                Console.Write(item + " ");
            Console.WriteLine();

            int[] array = new int[10];
            alist.CopyTo(array, 1);
            foreach (var item in array)
                Console.Write(item + " ");
            Console.WriteLine();
        }
    }
}
