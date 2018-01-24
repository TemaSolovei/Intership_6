using System;

namespace Intership_5
{
    class Program
    {
        public static double a1, a2, a3; // Начальные элементы последовательности

        static void Main(string[] args)
        {
            int N; // Количество вычисленных элементов последовательности
            bool check = true; // Проверка чётных элементов на возрастание

            N = checkInt("Введите количество элементов последовательности, которые необходимо вычислить: ");
            double[] mas = new double[N + 3];

            a1 = checkDouble("Введите первый элемент последовательности: ");
            a2 = checkDouble("Введите второй элемент последовательности: ");
            a3 = checkDouble("Введите третий элемент последовательности: ");

            mas[0] = a1;
            mas[1] = a2;
            mas[2] = a3;

            for (int i = 0; i < 3; i++)
            {
                Console.Write("{0}-ый элемент последовательности: ", i+1);
                Console.WriteLine(mas[i]);
            }

            for (int i = 0; i < N; i++)
            {
                mas[i + 3] = Func(i + 3);
                Console.Write("{0}-ый элемент последовательности: ", i + 4);
                Console.WriteLine(mas[i+3]);

                if ((((i + 3) % 2) == 1) && check == true)
                {
                    if (!(mas[i + 1] < mas[i + 3])) check = false;
                }
            }

            if (check == true) Console.WriteLine("Чётные элементы образуют возрастающую последовательность");
            else Console.WriteLine("Чётные элементы не образуют возрастающую последовательность");
        }

        static double Func(int n)
        {
            switch (n)
            {
                case 1:
                    return a1;
                    
                case 2:
                    return a2;

                case 3:
                    return a3;

                default:
                    return 13 * Func(n - 1) - 10 * Func(n - 2) + Func(n - 3);
            }
        }

        static int checkInt(string message)
        {
            int result; // result - проверенная переменная
            bool ok; // Проверка ввода

            do
            {
                Console.Write(message);
                ok = int.TryParse(Console.ReadLine(), out result);
                if (result <= 0) Console.WriteLine("Ошибка! Количество элементов должно быть больше 0!");
            } while ((!ok) || (result <= 0));

            return result;
        }

        static double checkDouble(string message)
        {
            double result; // result - проверенная переменная
            bool ok; // Проверка ввода

            do
            {
                Console.Write(message);
                ok = double.TryParse(Console.ReadLine(), out result);
                if (!ok) Console.WriteLine("Ошибка ввода, введите вещественное число!");
            } while (!ok);

            return result;
        }
    }
}
