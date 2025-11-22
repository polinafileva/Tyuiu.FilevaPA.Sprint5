namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Test;

using System.Globalization;
using Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;
internal class Program
{
    private static void Main(string[] args)

    {
        DataService ds = new DataService();

        Console.Title = "Спринт #5 | Выполнила: Филева Полина Алексеевна. | ИСПБ-25-1";
        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* Спринт #5                                                              *");
        Console.WriteLine("* Тема: Табулирование функции и запись в файл                           *");
        Console.WriteLine("* Задание #1                                                             *");
        Console.WriteLine("* Вариант #9                                                           *");
        Console.WriteLine("* Выполнила: Филева Полина Алексеевна | ИСПБ-25-1                       *");
        Console.WriteLine("**************************************************************************");

        Console.WriteLine("* УСЛОВИЕ:                                                                *");
        Console.WriteLine("* Дана функция: F(x) = sin(x) + cos(2x)/2 - 1 + 5x                        *");
        Console.WriteLine("* Произвести табулирование на диапазоне [-5; 5] с шагом 1.                *");
        Console.WriteLine("* При делении на ноль вернуть 0. Результат сохранить в файл и вывести    *");
        Console.WriteLine("* на консоль в таблицу. Округлить до двух знаков после запятой.          *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
        Console.WriteLine("***************************************************************************");

        int startValue = -5;
        int stopValue = 5;

        Console.WriteLine($"Начало диапазона: {startValue}");
        Console.WriteLine($"Конец диапазона: {stopValue}");
        Console.WriteLine($"Шаг: 1");
        Console.WriteLine($"Функция: F(x) = sin(x) + cos(2x)/2 - 1 + 5x");

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
        Console.WriteLine("***************************************************************************");

        // Вызываем метод SaveToFileTextData
        string resultPath = ds.SaveToFileTextData(startValue, stopValue);

        Console.WriteLine($"Файл сохранен: {resultPath}");
        Console.WriteLine();

        // Вывод таблицы на консоль
        DisplayResultsInConsole(startValue, stopValue);

        // Вывод содержимого файла
        Console.WriteLine("\nСодержимое файла:");
        Console.WriteLine("========================================");
        DisplayFileContents(resultPath);

        Console.WriteLine("\nНажмите любую клавишу для завершения...");
        Console.ReadKey();
    }

    static void DisplayResultsInConsole(int startValue, int stopValue)
    {
        Console.WriteLine("Таблица значений функции:");
        Console.WriteLine("┌───────┬────────────┐");
        Console.WriteLine("│   x   │    F(x)    │");
        Console.WriteLine("├───────┼────────────┤");

        for (int x = startValue; x <= stopValue; x++)
        {
            double result = CalculateFunctionForDisplay(x);
            Console.WriteLine($"│ {x,5} │ {result,10:F2} │");
        }

        Console.WriteLine("└───────┴────────────┘");
    }

    static void DisplayFileContents(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("Файл не найден!");
        }
    }

    private static double CalculateFunctionForDisplay(int x)
    {
        // Проверка деления на ноль
        if (Math.Abs(x) < double.Epsilon)
        {
            return 0;
        }

        return Math.Sin(x) + (Math.Cos(2 * x) / 2) - 1 + (5 * x);
    }
}
