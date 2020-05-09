using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;
using Lab10Library;

namespace Task12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лаб. 12. Решетняк");

            //Task12.1
            //===================================================================================================================================================
            Console.WriteLine("\nTask12.1\n");
            Console.WriteLine("Удалить из списка первый элемент с четным информационным полем. \n");
            int counter = 1;
            LinkedList<Person> list = new LinkedList<Person>();
            list.Add(new Worker("Fedor", "Solyanov", 22, "Fire"));
            list.Add(new Administer("Fire", "Loading", 29, "Legolas"));
            list.Add(new Engineer("Leonid", "Pirogov", 28, "Fire","Lego"));
            list.Add(new Worker("People", "Stronger", 34, "Fire"));
            Administer ADM = new Administer("Fire","Anakin",30,"Lego");
            list.Add(ADM);
            foreach (Person WRK in list)
            {
                Console.WriteLine(counter + " " + WRK.Show());
                counter++;
            }
            Console.WriteLine();
            Console.WriteLine("Удаление первого чётного элемента");
            Console.WriteLine("Удаленный элемент - " + list.FindEven(2).Data.Show() + "\n");
            list.Delete(list.FindEven(2).Data);
           // list.Delete(ADM);
            counter = 1;
            foreach (Person item in list)
            {
                Console.WriteLine(counter + " " + item.Show());
                counter++;
            }
            Console.WriteLine();
            list.Clear();
            if (list.Count == 0) Console.WriteLine("Однонаправленный список удалён");
            Console.WriteLine("Нажмите, чтобы продолжить");
            Console.ReadLine();

            //Task12.2
            //===================================================================================================================================================
            Console.WriteLine("Task12.2\n");
            Console.WriteLine("Добавить в список элементы с номерами 1, 3, 5 и т. д.\n");
          int counterDva = 1;
          DoubleList<Person> doubleList = new DoubleList<Person>();
          doubleList.Add(new Worker("AMD", "loser", 12, "Fire"));
          doubleList.Add(new Administer("fire", "lol", 24, "Loading"));
          Worker workWalk = new Worker("Anime", "LoL", 22, "TEST");
          doubleList.Add(workWalk);

          foreach (Person item in doubleList)
          {
              Console.WriteLine(counterDva + " " + item.Show());
              counterDva++;
          }
          counterDva = 1;

          Console.WriteLine();

          Console.WriteLine("Добавить в список элементы с номерами 1, 3, 5 и т. д.");
          foreach (Person item in doubleList.FindUnEven())
          {
              Console.WriteLine(counterDva + " " + item.Show());
              counterDva++;
          }
          doubleList.Clear();
          if(doubleList.count == 0) Console.WriteLine("Двунаправленный список удалён");
          Console.WriteLine("Нажмите, чтобы продолжить");
            Console.ReadLine();

          //Task12.2
          //===================================================================================================================================================

            Console.WriteLine("\nTask 12.3\n");

          Console.WriteLine("Оригинальное дерево:");
          Console.WriteLine("                                    5                             ");
          Console.WriteLine("                             /             \\                  ");
          Console.WriteLine("                         3                    8                         ");
          Console.WriteLine("                    /       \\              /  \\                  ");
          Console.WriteLine("                   1         4          7         9                   ");
          Console.WriteLine("                    \\                   /                ");
          Console.WriteLine("                     2                 6                ");


          Tree<Worker> intTree = new Tree<Worker>();
            intTree.Add(new Worker("Da","Net",5,"Fire"));
            intTree.Add(new Worker("Da", "Net", 3, "Fire"));
            intTree.Add(new Worker("Da", "Net", 8, "Fire"));
            intTree.Add(new Worker("Da", "Net", 7, "Fire"));
            intTree.Add(new Worker("Da", "Net", 4, "Fire"));
            intTree.Add(new Worker("Da", "Net", 1, "Fire"));
            intTree.Add(new Worker("Da", "Net", 2, "Fire"));
            intTree.Add(new Worker("Da", "Net", 6, "Fire"));
            intTree.Add(new Worker("Da", "Net", 9, "Fire"));

            Console.WriteLine("Префиксный");
            foreach (Worker IntTree in intTree.Preorder())
            {
                Console.WriteLine(IntTree.Show() + " / ");
            }
            Console.WriteLine("\nПостфиксный\n");
            foreach (Worker IntTree in intTree.Postorder())
            {
                Console.WriteLine(IntTree.Show() + " / ");
            }
            Console.WriteLine("\nИнфиксный\n");
            foreach (Worker IntTree in intTree.Inorder())
            {
                Console.WriteLine(IntTree.Show() + " / ");
            }
            Console.WriteLine("Длина дерева: " + Convert.ToString(intTree.MaxHeight(intTree.Root)));
            Console.WriteLine("Общее количество элементов: " + Convert.ToString(intTree.Count()));
            intTree.Clear();
            if(intTree.Count() == 0) Console.WriteLine("Дерево удалено");
            Console.ReadLine();
        }
    }
}
