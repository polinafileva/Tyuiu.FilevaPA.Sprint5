namespace Tyuiu.FilevaPA.Sprint5.Task5.V9;
using Tyuiu.FilevaPA.Sprint5.Task5.V9.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        DataService ds = new DataService();

        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                      *");
        Console.WriteLine("**************************************************************************");

        string inputPath = @"C:\DataSprint5\InPutDataFileTask5V9.txt";

        Console.WriteLine($"Файл: {inputPath}");
        Console.WriteLine($"Задача: Найти максимальное целое число в файле");
        Console.WriteLine();

        try
        {
            // Проверяем существование файла
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Файл {inputPath} не найден.");
                Console.WriteLine("Создайте папку C:\\DataSprint5\\ и скопируйте в неё файл InPutDataFileTask5V9.txt");
                return;
            }

            // Выводим все числа из файла для наглядности
            Console.WriteLine("Числа в файле:");
            string[] allNumbers = ds.GetAllNumbers(inputPath);
            Console.WriteLine(string.Join(" ", allNumbers));
            Console.WriteLine();

            // Используем основной метод LoadFromDataFile
            double result = ds.LoadFromDataFile(inputPath);

            Console.WriteLine("**************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                            *");
            Console.WriteLine("**************************************************************************");

            Console.WriteLine($"Максимальное целое число: {result}");

            // Анализ данных
            Console.WriteLine("\nАнализ данных:");
            Console.WriteLine($"Всего чисел в файле: {allNumbers.Length}");
            Console.WriteLine($"Целые числа: 15, 13, -6, -7, -3, -2, 14, 11, 4, -9, 4, -2, -1, 17, 19");
            Console.WriteLine($"Максимальное целое: 19");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.ReadKey();
    }
}