using System;
using OwnSortedList.List;
using OwnSortedList.SortedList;

namespace ConsoleApp1
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
            alist.ConnectEvents(true);
            alist.Add(7);

            foreach (var item in alist)
                Console.Write(item + " ");
            Console.WriteLine();

            blist.Add("c");
            blist.Add("a");
            blist.ConnectEvents(false);
            blist.ConnectEvents(true);
            blist.Add("b");
            blist.Add("d");
            blist.ConnectEvents(false);
            blist.Add("f");
            blist.Add("e");
            blist.Add("h");
            blist.Add("g");

            foreach (var item in blist)
                Console.Write(item + " ");
            Console.WriteLine();

            asorted.Add(3);
            asorted.Add(1);
            asorted.Add(2);
            asorted.Add(4);
            asorted.Add(6);
            asorted.Add(5);
            asorted.Add(8);
            asorted.ConnectEvents(true);
            asorted.Add(7);

            foreach (var item in asorted)
                Console.Write(item + " ");
            Console.WriteLine();

            bsorted.Add("c");
            bsorted.Add("a");
            bsorted.Add("b");
            bsorted.Add("d");
            bsorted.Add("f");
            bsorted.Add("e");
            bsorted.Add("h");
            bsorted.ConnectEvents(true);
            bsorted.Add("g");

            foreach (var item in bsorted)
                Console.Write(item + " ");
            Console.WriteLine();

            var csorted = new OwnSortedList<string>();
            bsorted.Remove("d");
            bsorted.RemoveAt(2);
            foreach (var item in bsorted)
                Console.Write(item + " ");
            Console.WriteLine();
            Console.WriteLine(bsorted.IndexOf("e"));
            Console.WriteLine(bsorted.Contains("j"));
            bsorted.Clear();
            Console.WriteLine(bsorted.Count);

            alist.InsertAt(10, 5);
            Console.WriteLine(alist[5]);
            alist.SetAt(11, 5);
            Console.WriteLine(alist.GetAt(5));

            //blist[9];
            //blist.Add(null);
            //blist.InsertAt("hello",11);
            //blist.RemoveAt(11);

            /*
            foreach (var item in blist)
                blist.Add(item);
            */
        }
    }
}
