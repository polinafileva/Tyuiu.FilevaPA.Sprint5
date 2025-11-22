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
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                      *");
        Console.WriteLine("**************************************************************************");

        int startValue = -5;
        int stopValue = 5;

        Console.WriteLine("Функция: F(x) = sin(x) + cos(2x)/2 - 1");
        Console.WriteLine($"Диапазон: [{startValue}; {stopValue}]");
        Console.WriteLine($"Шаг: 1");
        Console.WriteLine();

        // Вычисляем табулирование для вывода в консоль
        double[,] tabulation = ds.CalculateTabulation(startValue, stopValue);

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

        // Сохранение в файл с использованием нового метода
        string filePath = ds.SaveToFileTextData(startValue, stopValue);

        Console.WriteLine();
        Console.WriteLine($"Результат сохранен в файл: {filePath}");

        Console.ReadKey();
    }
}
