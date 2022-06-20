using System;
using Xunit;
using SortedList;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddSort()
        {
            var flag1 = true;
            var flag2 = true;
            var collection1 = new OwnSortedList<string>();
            collection1.Add("c");
            collection1.Add("a");
            collection1.Add("b");
            collection1.Add("d");

            var collection2 = new OwnSortedList<int>();
            collection2.Add(3);
            collection2.Add(1);
            collection2.Add(2);
            collection2.Add(4);

            var preitem1 = collection1[0];
            foreach(string item in collection1)
            {
                if (string.Compare(item, preitem1) < 0)
                {
                    flag1 = false;
                    break;
                }
                preitem1 = item;
            }

            var preitem2 = collection2[0];
            foreach (int item in collection2)
            {
                if (preitem2 > item)
                {
                    flag2 = false;
                    break;
                }
                preitem2 = item;
            }

            Assert.True(flag1);
            Assert.True(flag2);
        }

        [Fact]
        public void TestIndexOf()
        {
            var collection = BuildSimpleSortedList();
            string searchitem = "f";
            string misseditem = "m";
            var res1 = collection.IndexOf(searchitem);
            var res2 = collection.IndexOf(misseditem);

            int fact1 = 0;
            int fact2 = -1;
            int counter = 0;
            foreach (var item in collection)
            {
                if (item == searchitem)
                {
                    fact1 = counter;
                }
                if (item == misseditem)
                {
                    fact2 = counter;
                }
                counter++;
            }

            Assert.Equal(fact1, res1);
            Assert.Equal(fact2, res2);
        }

        [Fact]
        public void TestRemoveAt()
        {
            var fact1 = -1;
            var collection = BuildSimpleSortedList();
            string searchitem = "h";
            var pos1 = collection.IndexOf(searchitem);
            collection.RemoveAt(pos1);
            var res1 = collection.IndexOf(searchitem);
            Assert.Equal(fact1, res1);
        }

        [Fact]
        public void TestRemove()
        {
            var fact1 = true;
            var fact2 = false;

            string searchitem = "g";
            string misseditem = "m";

            var collection = BuildSimpleSortedList();

            var preindex1 = collection.IndexOf(searchitem);
            var preindex2 = collection.IndexOf(misseditem);

            var res1 = collection.Remove(searchitem);
            var res2 = collection.Remove(misseditem);

            var postindex1 = collection.IndexOf(searchitem);
            var postindex2 = collection.IndexOf(misseditem);

            Assert.Equal(fact1, res1);
            Assert.Equal(fact2, res2);
            Assert.NotEqual(preindex1, postindex1);
            Assert.Equal(preindex2, postindex2);
        }

        [Fact]
        public void TestContains()
        {
            var fact1 = true;
            var fact2 = false;

            var collection = BuildSimpleSortedList();

            var res1 = collection.Contains("a");
            collection.Remove("a");
            var res2 = collection.Contains("a");            

            Assert.Equal(fact1, res1);
            Assert.Equal(fact2, res2);
        }        

        [Fact]
        public void TestClear()
        {
            var fact1 = 0;

            var collection = BuildSimpleSortedList();

            collection.Clear();
            var res1 = collection.Count;

            Assert.Equal(fact1, res1);
        }

        [Fact]
        public void TestCopyTo()
        {
            var fact1 = true; 
            var collection = BuildSimpleSortedList();

            string[] array1 = new string[8];
            string[] array2 = new string[10];

            array2[0] = "m";
            array2[1] = "m";

            collection.CopyTo(array1);
            collection.CopyTo(array2, 2);

            int counter = 0;
            foreach(var item in collection)
            {
                if(item != array1[counter] && item != array2[counter+2])
                {
                    fact1 = false;
                    break;
                }    
                counter++;
            }

            Assert.True(fact1);
        }

        [Fact]
        public void TestTheRest()
        {
            var collection = BuildSimpleSortedList();

            var res1 = collection.ConnectEvents(true);
            var res2 = collection.ConnectEvents(false);

            Assert.True(res1);
            Assert.False(res2);

            Assert.False(collection.IsReadOnly);
        }

        OwnSortedList<string> BuildSimpleSortedList()
        {
            var collection = new OwnSortedList<string>();
            collection.Add("c");
            collection.Add("a");
            collection.Add("b");
            collection.Add("d");
            collection.Add("f");
            collection.Add("e");
            collection.Add("h");
            collection.Add("g");
            return collection;
        }
        OwnList<string> BuildSimpleList()
        {
            var collection = new OwnList<string>();
            collection.Add("c");
            collection.Add("a");
            collection.Add("b");
            collection.Add("d");
            collection.Add("f");
            collection.Add("e");
            collection.Add("h");
            collection.Add("g");
            return collection;
        }
    }
}
