namespace Tyuiu.FilevaPA.Sprint5.Task6.V29;
using Tyuiu.FilevaPA.Sprint5.Task6.V29.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        DataService ds = new DataService();

        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                      *");
        Console.WriteLine("**************************************************************************");

        string inputPath = @"C:\DataSprint5\InPutDataFileTask6V29.txt";

        Console.WriteLine($"Файл: {inputPath}");
        Console.WriteLine($"Задача: Найти количество слов длиной 7 символов");
        Console.WriteLine();

        try
        {
            // Проверяем существование файла
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Файл {inputPath} не найден.");
                Console.WriteLine("Создайте папку C:\\DataSprint5\\ и скопируйте в неё файл InPutDataFileTask6V29.txt");
                return;
            }

            // Читаем и выводим содержимое файла
            string content = File.ReadAllText(inputPath);
            Console.WriteLine($"Содержимое файла: \"{content}\"");
            Console.WriteLine();

            // Выводим все слова для наглядности
            string[] allWords = ds.GetAllWords(inputPath);
            Console.WriteLine("Все слова в файле:");
            for (int i = 0; i < allWords.Length; i++)
            {
                Console.WriteLine($"{i + 1}. '{allWords[i]}' (длина: {allWords[i].Length})");
            }
            Console.WriteLine();

            // Используем основной метод LoadFromDataFile
            int result = ds.LoadFromDataFile(inputPath);

            Console.WriteLine("**************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                            *");
            Console.WriteLine("**************************************************************************");

            Console.WriteLine($"Количество слов длиной 7 символов: {result}");

            // Анализ данных
            Console.WriteLine("\nАнализ данных:");
            var wordsWithLength7 = allWords.Where(word => word.Length == 7).ToArray();
            if (wordsWithLength7.Length > 0)
            {
                Console.WriteLine($"Слова длиной 7 символов: {string.Join(", ", wordsWithLength7.Select(w => $"'{w}'"))}");
            }
            else
            {
                Console.WriteLine("Слов длиной 7 символов не найдено");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.ReadKey();
    }
}