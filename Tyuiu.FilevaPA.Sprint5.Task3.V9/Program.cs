namespace Tyuiu.FilevaPA.Sprint5.Task3.V9.Test;
using Tyuiu.FilevaPA.Sprint5.Task3.V9.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        DataService ds = new DataService();

        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                      *");
        Console.WriteLine("**************************************************************************");

        int x = 3;
        Console.WriteLine("Функция: y = x³ / (x² - 1)");
        Console.WriteLine($"x = {x}");
        Console.WriteLine();

        // Вычисляем значение функции
        double result = ds.CalculateFunction(x);

        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* РЕЗУЛЬТАТ:                                                            *");
        Console.WriteLine("**************************************************************************");

        Console.WriteLine($"y = {result:F3}");

        // Сохранение в бинарный файл с использованием нового метода
        string filePath = ds.SaveToFileTextData(x);

        Console.WriteLine($"Результат сохранен в бинарный файл: {filePath}");

        // Чтение из файла для проверки
        Console.WriteLine("\nПроверка чтения из бинарного файла:");
        double fileValue = ReadFromBinaryFile(filePath);
        Console.WriteLine($"Прочитано из файла: {fileValue:F3}");

        Console.ReadKey();
    }

    static double ReadFromBinaryFile(string filePath)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            return reader.ReadDouble();
        }
    }
}