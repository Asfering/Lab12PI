using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask12One;
using Lab10Library;
using Task12;

namespace TestTask12One
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LinkedListAddTestMethod()
        {
            LinkedList<Worker> list = new LinkedList<Worker>();
            list.Add(new Worker("da", "net", 12, "fire"));
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void LinkedListClearAllTestMethod()
        {
            LinkedList<Worker> list = new LinkedList<Worker>();
            list.Add(new Worker("da", "net", 12, "fire"));
            list.Clear();
            Assert.AreEqual(0,list.Count);
        }

        [TestMethod]
        public void LinkedListDeleteTestMethod()
        {
            Worker WRK = new Worker("da", "net", 12, "fire");
            Worker WRKSec = new Worker("net", "da", 22, "ice");
            Worker WRKThird = new Worker("Yes", "Ho",62,"Hot");
            LinkedList<Worker> list = new LinkedList<Worker>();
            list.Add(WRK);
            list.Add(WRKSec);
            list.Add(WRKThird);
            list.Delete(WRKSec);
            int i = 0;
            if (list.Contains(WRKSec)) i++;
            Assert.AreEqual(0,i);

        }

        [TestMethod]
        public void LinkedListAreEqualTestMethod()
        {
            //тест поиска 2-го элемента в однонаправленном списке
            Worker WRK = new Worker("da","net",12,"fire");
            Worker WRKSec = new Worker("net","da",22,"ice");
            LinkedList<Worker> list = new LinkedList<Worker>();
            list.Add(WRK);
            list.Add(WRKSec);
            Worker WRKfind = list.FindEven(2).Data;
            Assert.AreEqual(WRKSec,WRKfind);
        }

        [TestMethod]
        public void LinkedListAreNotEqualTestMethod()
        {
            //тест поиска 2-го элемента в однонаправленном списке
            Worker WRK = new Worker("da", "net", 12, "fire");
            Worker WRKSec = new Worker("net", "da", 22, "ice");
            LinkedList<Worker> list = new LinkedList<Worker>();
            list.Add(WRK);
            list.Add(WRKSec);
            Worker WRKfind = list.FindEven(1).Data;
            Assert.AreNotEqual(WRKSec, WRKfind);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void LinkedListExceptionEqualTestMethod()
        {
            //тест поиска 2-го элемента в однонаправленном списке
            Worker WRK = new Worker("da", "net", 12, "fire");
            Worker WRKSec = new Worker("net", "da", 22, "ice");
            LinkedList<Worker> list = new LinkedList<Worker>();
            list.Add(WRK);
            list.Add(WRKSec);
            Worker WRKfind = list.FindEven(10).Data;
        }

        [TestMethod]
        public void DoubleListAreEqualTestMethod()
        {
            Worker WRK = new Worker("da", "net", 12, "fire");
            Worker WRKSec = new Worker("net", "da", 22, "ice");
            Worker WRKThird = new Worker("aga", "no", 16, "hot");
            Worker WRKFour = new Worker("nea", "ofc", 29, "cold");
            Worker WRKFive = new Worker("nine", "ya", 90, "zero");
            Worker WRKSix = new Worker("night", "yes", 20, "temperature");

            DoubleList<Worker> dblTestList = new DoubleList<Worker>();
            dblTestList.Add(WRK);
            dblTestList.Add(WRKSec);
            dblTestList.Add(WRKThird);
            dblTestList.Add(WRKFour);
            dblTestList.Add(WRKFive);
            dblTestList.Add(WRKSix);
            int i = 1;
            foreach (Person item in dblTestList)
            {
                Console.WriteLine(i + item.Show());
                i++;
            }
            int j = 1;
            foreach (Person item in dblTestList.FindUnEven())
            {
                Console.WriteLine(j + item.Show());
                j++;
            }
            j--;
            Assert.AreEqual(9,j);
        }

        [TestMethod]
        public void DoubleListAddTestMethod()
        {
            DoubleList<Worker> list = new DoubleList<Worker>();
            list.Add(new Worker("da", "net", 12, "fire"));
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void DoubleListClearAllTestMethod()
        {
            DoubleList<Worker> list = new DoubleList<Worker>();
            list.Add(new Worker("da", "net", 12, "fire"));
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void DoubleListDeleteTestMethod()
        {
            Worker WRK = new Worker("da", "net", 12, "fire");
            Worker WRKSec = new Worker("net", "da", 22, "ice");
            Worker WRKThird = new Worker("Yes", "Ho", 62, "Hot");
            DoubleList<Worker> list = new DoubleList<Worker>();
            list.Add(WRK);
            list.Add(WRKSec);
            list.Add(WRKThird);
            list.Delete(WRKSec);
            int i = 0;
            if (list.Contains(WRKSec)) i++;
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void TreeAddTestMethod()
        {
            Tree<Worker> wrkTree = new Tree<Worker>();
            wrkTree.Add(new Worker("da","net",2,"fire"));
            wrkTree.Add(new Worker("Da", "Net", 4, "Fire"));
            wrkTree.Add(new Worker("Da", "Net", 1, "Fire"));
            wrkTree.Add(new Worker("Da", "Net", 3, "Fire"));
            Assert.IsNotNull(wrkTree);
        }

        [TestMethod]
        public void TreeLongTestMethod()
        {
            Tree<Worker> wrkTree = new Tree<Worker>();
            wrkTree.Add(new Worker("da", "net", 2, "fire"));
            wrkTree.Add(new Worker("Da", "Net", 4, "Fire"));
            wrkTree.Add(new Worker("Da", "Net", 1, "Fire"));
            wrkTree.Add(new Worker("Da", "Net", 3, "Fire"));
            int Long = wrkTree.MaxHeight(wrkTree.Root);
            Assert.AreEqual(3,Long);
        }

        [TestMethod]
        public void TreeClearTestMethod()
        {
            Tree<Worker> wrkTree = new Tree<Worker>();
            wrkTree.Add(new Worker("da", "net", 2, "fire"));
            wrkTree.Add(new Worker("Da", "Net", 4, "Fire"));
            wrkTree.Add(new Worker("Da", "Net", 1, "Fire"));
            wrkTree.Add(new Worker("Da", "Net", 3, "Fire"));
            wrkTree.Clear();
            Assert.AreEqual(0,wrkTree.CountAll);
        }


    }
}
