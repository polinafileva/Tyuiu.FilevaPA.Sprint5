namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Test;
using Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.Title = "Спринт #5 | Выполнила: Филева П. А. | ИСПБ-25-1";

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* Спринт #5                                                               *");
        Console.WriteLine("* Тема: Табулирование функции и запись в файл                            *");
        Console.WriteLine("* Задание #1                                                              *");
        Console.WriteLine("* Вариант #9                                                              *");
        Console.WriteLine("* Выполнила: Филева Полина Алексеевна | ИСПБ-25-1                        *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* УСЛОВИЕ:                                                                *");
        Console.WriteLine("* Дана функция F(x) = cos(2x) + sin(x)/(x + 2.5) + 2x. Произвести       *");
        Console.WriteLine("* табулирование на диапазоне [-5; 5] с шагом 1. Результат сохранить     *");
        Console.WriteLine("* в файл и вывести на консоль в таблицу. Округлить до двух знаков.      *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
        Console.WriteLine("***************************************************************************");

        int startValue = -5;
        int stopValue = 5;
        int step = 1;

        Console.WriteLine($"Диапазон: [{startValue}; {stopValue}]");
        Console.WriteLine($"Шаг: {step}");
        Console.WriteLine($"Функция: F(x) = cos(2x) + sin(x)/(x + 2.5) + 2x");

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
        Console.WriteLine("***************************************************************************");

        DataService ds = new DataService();
        string path = ds.SaveToFileTextData(startValue, stopValue);

        // Вывод таблицы на консоль
        Console.WriteLine("Таблица значений функции:");
        Console.WriteLine("------------------------");
        Console.WriteLine("   x   |   F(x)   ");
        Console.WriteLine("------------------------");

        for (int x = startValue; x <= stopValue; x++)
        {
            double y = CalculateFunction(x);
            Console.WriteLine($"  {x,3}  |  {y,7:F2}  ");
        }

        Console.WriteLine("------------------------");

        // Вывод информации о файле
        Console.WriteLine($"\nРезультат сохранен в файл: {path}");

        // Чтение и вывод содержимого файла
        Console.WriteLine("\nСодержимое файла:");
        string[] fileContent = File.ReadAllLines(path);
        foreach (string line in fileContent)
        {
            Console.WriteLine(line);
        }

        Console.ReadKey();
    }

    private static double CalculateFunction(int x)
    {
        try
        {
            double cos2x = Math.Cos(2 * x);
            double sinX = Math.Sin(x);
            double denominator = x + 2.5;

            if (Math.Abs(denominator) < 0.0001)
            {
                return 0;
            }

            double fraction = sinX / denominator;
            double y = cos2x + fraction + 2 * x;
            return Math.Round(y, 2);
        }
        catch
        {
            return 0;
        }
    }
}