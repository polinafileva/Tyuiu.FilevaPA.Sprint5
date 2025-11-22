namespace Tyuiu.FilevaPA.Sprint5.Task4.V10.Test;
using Tyuiu.FilevaPA.Sprint5.Task4.V10.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        DataService ds = new DataService();

        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                      *");
        Console.WriteLine("**************************************************************************");

        string inputPath = "InPutDataFileTask4V10.txt";

        Console.WriteLine($"Формула: y = x³ * 1.2x + 2");
        Console.WriteLine($"Входной файл: {inputPath}");
        Console.WriteLine();

        try
        {
            // Проверяем существование файла
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Файл {inputPath} не найден в текущей директории.");
                Console.WriteLine($"Текущая директория: {Directory.GetCurrentDirectory()}");
                return;
            }

            // Используем основной метод LoadFromDataFile
            double result = ds.LoadFromDataFile(inputPath);

            // Читаем исходное значение x для вывода
            double x = ReadValueFromFile(inputPath);
            Console.WriteLine($"Прочитано из файла: x = {x}");

            Console.WriteLine("**************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                            *");
            Console.WriteLine("**************************************************************************");

            Console.WriteLine($"y = {result:F3}");

            // Сохранение в файл (если нужно)
            string outputPath = ds.SaveToFileTextData(inputPath);
            Console.WriteLine($"Результат сохранен в файл: {outputPath}");

            // Выводим содержимое выходного файла
            Console.WriteLine("\nСодержимое выходного файла:");
            string outputContent = File.ReadAllText(outputPath);
            Console.WriteLine(outputContent);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.ReadKey();
    }

    static double ReadValueFromFile(string path)
    {
        string content = File.ReadAllText(path);
        if (double.TryParse(content, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double value))
        {
            return value;
        }
        else
        {
            throw new FormatException("Неверный формат данных в файле");
        }
    }
}