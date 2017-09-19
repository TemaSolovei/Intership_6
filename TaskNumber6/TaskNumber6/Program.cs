using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNumber6
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1, a2, a3, num; // a1 - первый элемент последовательности, a2 - второй, a3 - третий, num - количество элементов последовательности

            IO.Input(out a1, out a2, out a3, out num);

        }
    }

    class IO
    {
        public static void Input(out int a1, out int a2, out int a3, out int num)
        {
            GreenStripe(1);
            Console.WriteLine("Ввод начальных значений \n Не забывайте, что числа должны быть целыми");
            GreenStripe(1);

            ParseInt("Введите первый элемент последовательности: ", out a1);
            ParseInt("Введите второй элемент последовательности: ", out a2);
            ParseInt("Введите третий элемент последовательности: ", out a3);
            ParseInt("Введите количество элементов последовательности: ", out num);
            GreenStripe(1);
        }

        static void GreenStripe(int height) // Рисует в консоли зелёную строку шириной height
        {
            Console.BackgroundColor = ConsoleColor.Green;

            for (int i = 0; i < height; i++)
            {
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        static void ParseInt(string message, out int outInt) // Выводит в консоль сообщение message и парсит введённое значение в int
        {
            bool intIsOk; // Проверка на успешность парса

            Console.Write(message);
            do
            {
                intIsOk = Int32.TryParse(Console.ReadLine(), out outInt);
                if (!intIsOk) Console.WriteLine("Введённое значение не является числом, попробуйте ещё раз");
            } while (intIsOk);
        }


        static void Output()
        {

        }
    }
}

