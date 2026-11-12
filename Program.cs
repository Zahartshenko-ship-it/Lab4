using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "=== ЛАБОРАТОРНАЯ РАБОТА №4 ===");
                Console.WriteLine("1. Задание 1");
                Console.WriteLine("2. Задание 2");
                Console.WriteLine("3. Задание 3");
                Console.WriteLine("4. Задание 4");
                Console.WriteLine("4. Задание 5");
                Console.WriteLine("6. Задание 6");
                Console.WriteLine("0. Выход");
                Console.WriteLine(
                    "==============================");

                int choice = ReadInteger(
                    "Выберите пункт меню: ");

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        RunTask1();
                        break;
                    case 2:
                        RunTask2();
                        break;
                    case 3:
                        RunTask3();
                        break;
                    case 4:
                        RunTask4();
                        break;
                    case 5:
                        RunTask5();
                        break;
                    case 6:
                        RunTask6();
                        break;
                    case 0:
                        isRunning = false;
                        Console.WriteLine(
                            "Завершение работы программы...");
                        break;

                    default:
                        Console.WriteLine(
                            "Некорректный пункт меню. " +
                            "Попробуйте снова.");
                        break;
                }
            }
        }

        private static void RunTask1()
        {
            Console.WriteLine(
                "--- Задание 1. Вариант 4 ---");

            List<int> list = ReadIntegerList();

            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            Console.WriteLine("\nИсходный список:");
            PrintList(list);

            int targetElement = ReadInteger(
                "Введите значение элемента E: ");

            ListTask.RemoveElementAfterTarget(
                list, targetElement);

            Console.WriteLine(
                "\nРезультат после удаления элементов:");
            PrintList(list);
        }

        private static void RunTask2()
        {
            Console.WriteLine(
                "--- Задание 2. Вариант 4 ---");

            LinkedList<int> linkedList = ReadLinkedList();

            if (linkedList.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            Console.WriteLine("\nИсходный связный список:");
            PrintLinkedList(linkedList);

            bool hasEqual = ListTask
                .HasElementEqualToNextCircular(linkedList);

            Console.WriteLine();

            if (hasEqual)
            {
                Console.WriteLine(
                    "Результат: В списке ЕСТЬ элемент, " +
                    "равный следующему за ним (по кругу).");
            }
            else
            {
                Console.WriteLine(
                    "Результат: В списке НЕТ элементов, " +
                    "равных следующим за ними (по кругу).");
            }
        }

        private static void RunTask3()
        {
            Console.WriteLine(
                "--- Задание 3. Вариант 4 ---");
            Console.WriteLine("Здесь вам нужно ввести коды стран, "+
            "код страны может быть от 1 до 100");

            int touristCount = ReadInteger(
                "Введите количество туристов (n): ");

            while (touristCount <= 0)
            {
                Console.WriteLine("Количество должно быть больше нуля.");
                touristCount = ReadInteger(
                    "Введите количество туристов (n): ");
            }

            List<HashSet<int>> tourists = new List<HashSet<int>>();

            for (int i = 0; i < touristCount; i++)
            {
                Console.WriteLine($"\nТурист №{i + 1}:");
                HashSet<int> countries = ReadIntegerHashSet(
                    "Введите коды стран, которые посетил турист "+
                    "(через энтер, для завершения введите -1): ");
                tourists.Add(countries);
            }

            ListTask.AnalyzeTourismChoices(
                tourists, 
                touristCount, 
                out HashSet<int> visitedByAll, 
                out HashSet<int> visitedBySome, 
                out HashSet<int> visitedByNone);

            Console.WriteLine("\n--- РЕЗУЛЬТАТЫ АНАЛИЗА ---");
            
            Console.Write("Страны, которые посетили ВСЕ туристы: ");
            PrintHashSet(visitedByAll);

            Console.Write("Страны, которые посетили НЕКОТОРЫЕ туристы: ");
            PrintHashSet(visitedBySome);

            Console.Write("Страны, которые НЕ ПОСЕТИЛ никто: ");
            PrintHashSet(visitedByNone);
        }

        private static void RunTask4()
        {
            Console.WriteLine(
                "--- Задание 4. Вариант 4 ---");

            Console.WriteLine("Введите текст на русском языке:");
            string text = Console.ReadLine() ?? string.Empty;

            ListTask.AnalyzeTextGluhie(text, out SortedSet<int> result);

            Console.WriteLine("\n--- РЕЗУЛЬТАТ АНАЛИЗА ---");
            Console.Write("Глухие согласные, "+
            "которые не входят ровно в одно слово: ");

            if (result.Count == 0)
            {
                Console.WriteLine("(нет таких букв)");
            }
            else
            {
                foreach (int charCode in result)
                {
                    Console.Write($"{(char)charCode} ");
                }
                Console.WriteLine();
            }
        }

        private static void RunTask5()
        {
            Console.WriteLine(
                "--- Задание 5. Вариант 4 (Абитуриенты из файла) ---");

            string fileName = "applicants.txt";

            CreateApplicantsFile();

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Ошибка: файл с данными не найден!");
                return;
            }

            string[] lines = File.ReadAllLines(fileName);

            SortedDictionary<string, string> failed;
            ListTask.AnalyzeApplicants(lines, out failed);

            Console.WriteLine(
                "\n--- АБИТУРИЕНТЫ, ПОТЕРПЕВШИЕ НЕУДАЧУ ---");

            if (failed.Count == 0)
            {
                Console.WriteLine("(нет таких абитуриентов)");
            }
            else
            {
                foreach (var pair in failed)
                {
                    Console.WriteLine(pair.Value);
                }
            }
        }

        private static void RunTask6()
        {
            Console.WriteLine(
                "--- Задание 6. Вариант 4 ---");

            double a = ReadPositiveDouble(
                "Введите длину катета a (> 0): ");
            double b = ReadPositiveDouble(
                "Введите длину катета b (> 0): ");

            try
            {
                RightTriangle triangle = new RightTriangle(a, b);

                Console.WriteLine("\nСозданный объект:");
                Console.WriteLine(triangle.ToString());
                Console.WriteLine(
                    $"Вычисленная площадь: {triangle.CalculateArea():F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void CreateApplicantsFile()
        {
            string fileName = "applicants.txt";
            Console.WriteLine(
                "--- Заполнение текстового файла для Задания 5 ---");

            int n = ReadInteger(
                "Введите количество абитуриентов (N): ");

            while (n <= 0 || n > 500)
            {
                Console.WriteLine(
                    "Количество должно быть от 1 до 500.");
                n = ReadInteger(
                    "Введите количество абитуриентов (N): ");
            }

            string[] lines = new string[n];
            int i = 0;
            string inputLine;
            string[] parts;
            int score1;
            int score2;
            bool isValid;

            Console.WriteLine(
                "Введите строки в формате " +
                "<Фамилия> <Имя> <Балл1> <Балл2>:");

            while (i < n)
            {
                Console.Write($"Абитуриент {i + 1}: ");
                inputLine = Console.ReadLine() ?? string.Empty;
                isValid = true;

                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    Console.WriteLine("Ошибка: строка пуста!");
                    isValid = false;
                }
                else
                {
                    parts = inputLine.Split(
                        new char[] { ' ' }, 
                        StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 4)
                    {
                        Console.WriteLine(
                            "Ошибка: нужно ввести ровно 4 элемента: " +
                            "Фамилия Имя Балл1 Балл2");
                        isValid = false;
                    }
                    else if (parts[0].Length > 20 || parts[1].Length > 15)
                    {
                        Console.WriteLine(
                            "Ошибка: фамилия не должна превышать 20 символов, " +
                            "а имя — 15 символов!");
                        isValid = false;
                    }
                    else if (!int.TryParse(parts[2], out score1) 
                            || !int.TryParse(parts[3], out score2))
                    {
                        Console.WriteLine(
                            "Ошибка: баллы должны быть целыми числами!");
                        isValid = false;
                    }
                    else if (score1 < 0 || score1 > 100 
                            || score2 < 0 || score2 > 100)
                    {
                        Console.WriteLine(
                            "Ошибка: баллы должны быть в диапазоне от 0 до 100!");
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    lines[i] = inputLine;
                    i++;
                }
                else
                {
                    Console.WriteLine(
                        "Повторите ввод для этого абитуриента.\n");
                }
            }

            System.IO.File.WriteAllLines(fileName, lines);
            Console.WriteLine(
                $"\nФайл '{fileName}' успешно создан и заполнен!\n");
        }

        private static double ReadPositiveDouble(string prompt)
        {
            double value;
            bool isValid = false;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? string.Empty;

                if (double.TryParse(input, out value) && value > 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine(
                        "Ошибка: введите положительное вещественное число.");
                }
            }
            while (!isValid);

            return value;
        }

        private static HashSet<int> ReadIntegerHashSet(string prompt)
        {
            HashSet<int> result = new HashSet<int>();
            Console.WriteLine(prompt);
            
            bool capturing = true;
            while (capturing)
            {
                int code = ReadInteger("Код страны [1..100] " +
                "(или -1 для завершения): ");
                if (code == -1)
                {
                    capturing = false;
                }
                else if (code >= 1 && code <= 100)
                {
                    result.Add(code);
                }
                else
                {
                    Console.WriteLine(
                        "Некорректный код! "+
                        "Страна должна быть в диапазоне от 1 до 100.");
                }
            }

            return result;
        }

        private static void PrintHashSet(HashSet<int> set)
        {
            if (set.Count == 0)
            {
                Console.WriteLine("(нет таких стран)");
                return;
            }

            foreach (int item in set)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        private static List<int> ReadIntegerList()
        {
            List<int> resultList = new List<int>();

            int count = ReadInteger(
                "Введите количество элементов в списке: ");

            while (count <= 0)
            {
                Console.WriteLine(
                    "Количество должно быть больше нуля.");
                count = ReadInteger(
                    "Введите количество элементов в списке: ");
            }

            for (int i = 0; i < count; i++)
            {
                int element = ReadInteger(
                    $"Введите элемент {i + 1}: ");
                resultList.Add(element);
            }

            return resultList;
        }

        private static LinkedList<int> ReadLinkedList()
        {
            LinkedList<int> resultList = new LinkedList<int>();

            int count = ReadInteger(
                "Введите количество элементов в списке: ");

            while (count <= 0)
            {
                Console.WriteLine(
                    "Количество должно быть больше нуля.");
                count = ReadInteger(
                    "Введите количество элементов в списке: ");
            }

            for (int i = 0; i < count; i++)
            {
                int element = ReadInteger(
                    $"Введите элемент {i + 1}: ");
                resultList.AddLast(element);
            }

            return resultList;
        }

        private static int ReadInteger(string prompt)
        {
            int number;
            bool isValid = false;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                isValid = int.TryParse(input, out number);

                if (!isValid)
                {
                    Console.WriteLine(
                        "Ошибка. Введено не целое число.");
                }
            }
            while (!isValid);

            return number;
        }

        private static void PrintList(List<int> list)
        {
            foreach (int item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        private static void PrintLinkedList(
            LinkedList<int> list)
        {
            foreach (int item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}