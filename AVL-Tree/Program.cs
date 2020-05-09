using System;
using System.Collections.ObjectModel;
using System.Linq;
using Lab10Library;

namespace AVL_Tree
{
    class Program
    {
        public static BinaryTree<Worker> intTree;
        public static BinaryTree<Worker> intTreeSurfaceClone;
        public static BinaryTree<Worker> intTreeCopyClone;
        static void Main(string[] args)
        {
            CollectionTree();
            Console.WriteLine("Lab12, part 2");
            
            int Choice = 0;
            while (Choice != 9)
            {
                StartMenu();
                Choice = PersonArray.InputNumber("", 1, 9);
                Switch(Choice);
            }
        }

        public static void CollectionTree()
        {
            intTree = new BinaryTree<Worker>
            {
                new Worker("Da", "Net", 5, "Fire"),
                new Worker("Da", "Net", 3, "Fire"),
                new Worker("Da", "Net", 8, "Fire"),
                new Worker("Da", "Net", 7, "Fire"),
                new Worker("Da", "Net", 4, "Fire"),
                new Worker("Da", "Net", 1, "Fire"),
                new Worker("Da", "Net", 2, "Fire"),
                new Worker("Da", "Net", 6, "Fire"),
                new Worker("Da", "Net", 9, "Fire")
            };
        }

        static void Switch(int choice)
        {
            
                switch (choice)
                {
                    case 1:
                        Console.Write("Имя - ");
                        string fName = Console.ReadLine();
                        Console.Write("Фамилия - ");
                        string fFamily = Console.ReadLine();
                        Console.Write("Возраст - ");
                        int fAge = PersonArray.InputNumber("", 0, 99);
                        Console.Write("Наименование места работы - ");
                        string fNameWorkShop = Console.ReadLine();
                        intTree.Add(new Worker(fName, fFamily, fAge, fNameWorkShop));
                        break;
                    case 2:
                        foreach (Worker WorkShow in intTree)
                        {
                            Console.Write("\n" + WorkShow.Show() + " / ");
                        }
                        Console.WriteLine();
                        break;
                    case 3: 
                        Console.Write("Имя - ");
                        string fRemName = Console.ReadLine();
                        Console.Write("Фамилия - ");
                        string fRemFamily = Console.ReadLine();
                        Console.Write("Возраст - ");
                        int fRemAge = PersonArray.InputNumber("", 0, 99);
                        Console.Write("Наименование места работы - ");
                        string fRemNameWorkShop = Console.ReadLine();
                        intTree.Remove(new Worker(fRemName, fRemFamily, fRemAge, fRemNameWorkShop));
                        break;
                    case 4:
                        Console.WriteLine("\nКоличество элементов коллекции - " + intTree.Count() + "\n");
                        break;
                    case 5:
                        Console.Write("Имя - ");
                        string fFindName = Console.ReadLine();
                        Console.Write("Фамилия - ");
                        string fFindFamily = Console.ReadLine();
                        Console.Write("Возраст - ");
                        int fFindAge = PersonArray.InputNumber("", 0, 99);
                        Console.Write("Наименование места работы - ");
                        string fFindNameWorkShop = Console.ReadLine();
                        Worker Wrk = new Worker(fFindName,fFindFamily,fFindAge,fFindNameWorkShop);
                        if (intTree.Contains(Wrk)) Console.WriteLine($"Элемент {Wrk.Show()} найден");
                        else Console.WriteLine("Элемент не найден");
                    break;
                    case 6:
                        intTreeSurfaceClone = (BinaryTree<Worker>)intTree.Clone();
                        Console.WriteLine("Результат клонирования:");
                        foreach (Worker WorkShow in intTreeSurfaceClone)
                        {
                            Console.Write("\n" + WorkShow.Show() + " / ");
                        }
                        Console.WriteLine();
                    break;
                    case 7:
                        for (int i = 0; i < intTree.Count() ; i++)
                    {
                        //xz
                    }
                    Console.WriteLine("Результат копирования:");
                    foreach (Worker WorkShow in intTree)
                    {
                        Console.Write("\n" + WorkShow.Show() + " / ");
                    }
                    Console.WriteLine();
                    break;
                case 8:
                    intTree.Clear();
                    Console.WriteLine("Коллекция удалена!");
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                
            }
        }


        static void StartMenu()
        {
            Console.WriteLine("Меню:\n1. Добавить элементы в коллекцию\n2. Показать коллекцию\n3. Удалить элементы из коллекции\n4. Показать общее количество элементов коллекции\n5. Поиск элементов по значению\n6. Клонирование коллекции\n7. Поверхностное копирование коллекции\n8. Удалить из памяти коллекцию\n9. Выход");
        }
    }
}
