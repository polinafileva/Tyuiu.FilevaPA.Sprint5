namespace Tyuiu.FilevaPA.Sprint5.Task7.V10.Test;
using Tyuiu.FilevaPA.Sprint5.Task7.V10.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        DataService ds = new DataService();

        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                      *");
        Console.WriteLine("**************************************************************************");

        string inputPath = @"C:\DataSprint5\InPutDataFileTask7V10.txt";

        Console.WriteLine($"Файл: {inputPath}");
        Console.WriteLine($"Задача: Заменить все заглавные латинские буквы на строчные");
        Console.WriteLine();

        try
        {
            // Проверяем существование файла
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Файл {inputPath} не найден.");
                Console.WriteLine("Создайте папку C:\\DataSprint5\\ и скопируйте в неё файл InPutDataFileTask7V10.txt");
                return;
            }

            // Получаем исходное содержимое
            string originalContent = ds.GetOriginalContent(inputPath);
            Console.WriteLine($"Исходное содержимое: \"{originalContent}\"");
            Console.WriteLine();

            // Получаем преобразованное содержимое
            string transformedContent = ds.GetTransformedContent(inputPath);
            Console.WriteLine($"Преобразованное содержимое: \"{transformedContent}\"");
            Console.WriteLine();

            // Используем основной метод LoadDataAndSave
            string outputPath = ds.LoadDataAndSave(inputPath);

            Console.WriteLine("**************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                            *");
            Console.WriteLine("**************************************************************************");

            Console.WriteLine($"Результат сохранен в файл: {outputPath}");

            // Выводим содержимое выходного файла
            Console.WriteLine("\nСодержимое выходного файла:");
            string outputContent = File.ReadAllText(outputPath);
            Console.WriteLine($"\"{outputContent}\"");

            // Анализ преобразования
            Console.WriteLine("\nАнализ преобразования:");
            Console.WriteLine("Заглавные латинские буквы, которые были заменены:");
            foreach (char c in originalContent)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    Console.WriteLine($"'{c}' -> '{char.ToLower(c)}'");
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.ReadKey();
    }
}