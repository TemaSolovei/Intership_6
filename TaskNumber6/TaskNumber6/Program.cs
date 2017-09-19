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
            Calculate.Solve();
        }
    }

    class IO
    {
        public static void Input(out int a1, out int a2, out int a3, out int num)
        {
            CyanStripe(1, Console.WindowWidth);
            Console.WriteLine("Ввод начальных значений \n Не забывайте, что числа должны быть целыми");
            CyanStripe(1, Console.WindowWidth);

            ParseInt("Введите первый элемент последовательности: ", out a1);
            ParseInt("Введите второй элемент последовательности: ", out a2);
            ParseInt("Введите третий элемент последовательности: ", out a3);
            ParseInt("Введите количество элементов последовательности: ", out num);
            CyanStripe(1, Console.WindowWidth);
        }

        static void CyanStripe(int height, int length) // Рисует в консоли Cyan строку шириной height и длиной length-1 (без переноса на следующую строку
        {
            Console.BackgroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length-1; j++)
                {
                    Console.Write(" ");
                }
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
            } while (!intIsOk);
        }

        public static void Output(int[] mas) // Вывод последовательности
        {
            CyanStripe(1, Console.WindowWidth);
            Console.WriteLine("Вывод последовательности из " + mas.Length + " элементов");
            CyanStripe(1, Console.WindowWidth);

            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }

            Console.WriteLine();

            if (Calculate.Check(mas)) Console.WriteLine("Подпоследовательность из чётных элементов вышеуказаной последовательности является возрастающей");
            else Console.WriteLine("Подпоследовательность из чётных элементов вышеуказаной последовательности не является возрастающей");
        }
    }

    class Calculate
    {
        static int[] CreateMas(int a1, int a2, int a3, int num)
        {
            int[] mas = new int[num]; // Инициализация массива

            mas[0] = a1;
            mas[1] = a2;
            mas[2] = a3;

            for (int i = 3; i < num; i++)
            {
                mas[i] = 13 * mas[i - 1] - 10 * mas[i - 2] + mas[i - 3];
            }

            return mas;
        }

        public static bool Check(int[] mas)
        {
            bool result = false; // Результат проверки на возрастание чётных элементов последовательности

            for (int i = 1; i < mas.Length/2; i++)
            {
                if (mas[i * 2] > mas[(i * 2) - 2]) result = true;
                else
                {
                    result = false;
                    break;;
                }
            }

            return result;
        }

        public static void Solve()
        {
            int a1, a2, a3, num; // a1 - первый элемент последовательности, a2 - второй, a3 - третий, num - количество элементов последовательности

            IO.Input(out a1, out a2, out a3, out num); // Ввод исходных данных
            int[] elementMas = CreateMas(a1, a2, a3, num); // Создание массива с num элементов, исходя из условий
            IO.Output(elementMas); // Вывод последовательности и результата о том, возрастает ли последовательность из чётных элементов
        }
    }
}

