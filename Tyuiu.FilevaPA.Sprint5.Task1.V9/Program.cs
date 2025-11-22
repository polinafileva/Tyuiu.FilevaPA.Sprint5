namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Test;

using System.Globalization;
using Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;
internal class Program
{
    private static void Main(string[] args)

    {
        DataService ds = new DataService();

        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                      *");
        Console.WriteLine("**************************************************************************");

        int startValue = -5;
        int stopValue = 5;

        Console.WriteLine("Функция: F(x) = sin(x) + cos(2x)/2 - 1.5x");
        Console.WriteLine($"Диапазон: [{startValue}; {stopValue}]");
        Console.WriteLine($"Шаг: 1");
        Console.WriteLine();

        // Получаем табулирование для вывода в консоль
        double[,] tabulation = ds.GetTabulation(startValue, stopValue);

        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* РЕЗУЛЬТАТ:                                                            *");
        Console.WriteLine("**************************************************************************");

        // Вывод в консоль в виде таблицы
        Console.WriteLine("x\t\tF(x)");
        Console.WriteLine("-------------------");

        for (int i = 0; i < tabulation.GetLength(0); i++)
        {
            Console.WriteLine($"{tabulation[i, 0]}\t\t{tabulation[i, 1]:F2}");
        }

        // Сохранение в файл
        string filePath = ds.SaveToFileTextData(startValue, stopValue);

        Console.WriteLine();
        Console.WriteLine($"Результат сохранен в файл: {filePath}");

        Console.ReadKey();
    }
}
