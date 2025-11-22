namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Test;

using System.Globalization;
using Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;
internal class Program
{
    private static void Main(string[] args)

    {
        DataService ds = new DataService();

        Console.Title = "Спринт #5 | Выполнила: Филева П. А. | ИСПБ-25-1";
        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* Спринт #5                                                              *");
        Console.WriteLine("* Тема: Табулирование функции и запись в файл                           *");
        Console.WriteLine("* Задание #1                                                             *");
        Console.WriteLine("* Вариант #9                                                           *");
        Console.WriteLine("* Выполнила: Филева Полина Алексеевна | ИСПБ-25-1                       *");
        Console.WriteLine("**************************************************************************");

        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                       *");
        Console.WriteLine("**************************************************************************");

        int startValue = -5;
        int stopValue = 5;
        Console.WriteLine($"Начало диапазона: {startValue}");
        Console.WriteLine($"Конец диапазона: {stopValue}");
        Console.WriteLine($"Шаг: 1");
        Console.WriteLine($"Функция: F(x) = (2sin(x))/(3x+1.2) + cos(x) - 14x");

        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* РЕЗУЛЬТАТ:                                                             *");
        Console.WriteLine("**************************************************************************");

        string resultPath = ds.SaveToFileTextData(startValue, stopValue);
        Console.WriteLine("Файл сохранен: " + resultPath);
        Console.WriteLine();

        // Вывод таблицы на консоль
        Console.WriteLine("Таблица значений функции:");
        Console.WriteLine("┌─────┬──────────┐");
        Console.WriteLine("│  x  │   F(x)   │");
        Console.WriteLine("├─────┼──────────┤");

        string[] lines = File.ReadAllLines(resultPath);
        int x = startValue;
        foreach (string line in lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                double y = double.Parse(line, CultureInfo.InvariantCulture);
                Console.WriteLine($"│ {x,3} │ {y,8:F2} │");
                x++;
            }
        }

        Console.WriteLine("└─────┴──────────┘");

        // Дополнительная информация
        Console.WriteLine($"\nВсего значений: {lines.Length}");
        Console.WriteLine($"Диапазон: от {startValue} до {stopValue}");

        Console.ReadKey();
    }
}