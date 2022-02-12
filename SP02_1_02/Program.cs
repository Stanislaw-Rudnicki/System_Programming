// Создайте класс Bank в котором будут следующие свойства:
// int money, string name, int percent.
// Постройте класс так чтобы при изменении одного из свойств,
// класса создавался новый поток,
// который записывал данные о свойствах класса в текстовый файл на жестком диске.
// Класс должен инкапсулировать в себе всю логику многопоточности.

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Sp02_1_02
{
    class Menu
    {
        const ConsoleColor FOREGROUND = ConsoleColor.Gray;
        const ConsoleColor ITEMSELECT = ConsoleColor.White;
        const int MENULEFT = 20;
        const int MENUTOP = 4;
        static string[] menuItems;
        public static string[] MenuItems { set { menuItems = value; } }
        public static int Selected { get; private set; } = 0;
        static void PaintMenu()
        {
            Console.ForegroundColor = FOREGROUND;
            Console.Clear();
            Console.SetCursorPosition(MENULEFT, MENUTOP);
            Console.WriteLine("......MENU......\n");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.SetCursorPosition(MENULEFT, MENUTOP + i + 1);
                if (i == Selected)
                {
                    Console.ForegroundColor = ITEMSELECT;
                    Console.Write("=>");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(menuItems[i]);
                Console.ForegroundColor = FOREGROUND;
            }
        }
        public static void MenuSelect()
        {
            ConsoleKey c = ConsoleKey.DownArrow;
            while (true)
            {
                if (c == ConsoleKey.UpArrow || c == ConsoleKey.DownArrow)
                {
                    PaintMenu();
                }
                c = Console.ReadKey().Key;
                switch (c)
                {
                    case ConsoleKey.Escape: //Esc
                        Selected = -1;
                        return;
                    case ConsoleKey.DownArrow: //down
                        ++Selected;
                        if (Selected == menuItems.Length) Selected = 0;
                        break;
                    case ConsoleKey.UpArrow://up
                        if (Selected == 0) Selected = menuItems.Length;
                        --Selected;
                        break;
                    case ConsoleKey.Enter: //Enter
                        return;
                }
            }
        }
    }

    [Serializable]
    class Bank
    {
        private int _money;
        public int Money
        {
            get { return _money; }
            set
            {
                _money = value;
                SaveState();
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                SaveState();
            }
        }
        private int _percent;
        public int Percent
        {
            get { return _percent; }
            set
            {
                _percent = value;
                SaveState();
            }
        }
        public static string FNAME { get; } = "bankstate.bin" ;
        private void SaveState()
        {
            // Создание делегата, связанного с методом.
            ThreadStart threadstart = new ThreadStart(() =>
            {
                try
                {
                    using (Stream stream = File.Create(FNAME))
                    {
                        BinaryFormatter format = new BinaryFormatter();
                        format.Serialize(stream, this);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            // Создание объекта потока.
            Thread thread = new Thread(threadstart);
            thread.Start(); // Запуск работы потока.
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Bank bank = null;
            
            if (File.Exists(Bank.FNAME))
            {
                try
                {
                    using (Stream stream = File.OpenRead(Bank.FNAME))
                    {
                        BinaryFormatter format = new BinaryFormatter();
                        bank = (Bank)format.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                bank = new Bank
                {
                    Money = 0,
                    Name = "Petro Petrenko",
                    Percent = 5
                };
            }


            Menu.MenuItems = new string[] {
                "Показать состояние счета",
                "Снять наличные",
                "Пополнить счет",
                "Изменить имя",
                "Изменить процент",
                "Выход"
            };

            while (true)
            {
                Menu.MenuSelect();
                Console.Clear();
                if (Menu.Selected < 0) break;
                if (Menu.Selected == 0)
                {
                    Console.WriteLine($"Имя: {bank.Name}\nБаланс: {bank.Money}\nПроцент: {bank.Percent}");
                };
                if (Menu.Selected == 1)
                {
                    int sum = 0;
                    bool f = false;
                    while (!f || sum < 0)
                    {
                        Console.Write("Введите сумму: ");
                        f = int.TryParse(Console.ReadLine(), out sum);
                    }
                    bank.Money -= sum;
                    Console.WriteLine("OK");
                }
                if (Menu.Selected == 2)
                {
                    int sum = 0;
                    bool f = false;
                    while (!f || sum < 0)
                    {
                        Console.Write("Введите сумму: ");
                        f = int.TryParse(Console.ReadLine(), out sum);
                    }
                    bank.Money += sum;
                    Console.WriteLine("OK");
                };
                if (Menu.Selected == 3)
                {
                    Console.Write("Введите имя: ");
                    SendKeys.SendWait(bank.Name);
                    bank.Name = Console.ReadLine();
                    Console.WriteLine("OK");
                };
                if (Menu.Selected == 4)
                {
                    int sum = 0;
                    bool f = false;
                    while (!f || sum < 0)
                    {
                        Console.Write("Введите процент: ");
                        SendKeys.SendWait(bank.Percent.ToString());
                        f = int.TryParse(Console.ReadLine(), out sum);
                    }
                    bank.Percent = sum;
                    Console.WriteLine("OK");
                };
                if (Menu.Selected == 5)
                {
                    break;
                };
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\ndone\n");
                Console.ReadKey();
            }
        }
    }
}