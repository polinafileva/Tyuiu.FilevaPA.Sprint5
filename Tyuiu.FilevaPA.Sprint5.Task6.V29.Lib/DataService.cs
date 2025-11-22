namespace Tyuiu.FilevaPA.Sprint5.Task6.V29.Lib;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task6V29
{
    public int LoadFromDataFile(string path)
    {
        // Читаем строку из файла
        string content = ReadFromFile(path);

        // Находим количество слов длиной 7 символов
        int count = CountWordsWithLength(content, 7);

        return count;
    }

    private string ReadFromFile(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }

            string content = File.ReadAllText(path);
            return content;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка чтения файла: {ex.Message}");
        }
    }

    private int CountWordsWithLength(string text, int length)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;

        // Разделяем текст на слова, игнорируя пробелы и знаки препинания
        char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '-', '\t', '\n', '\r' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        // Считаем слова нужной длины
        int count = words.Count(word => word.Length == length);

        return count;
    }

    // Дополнительный метод для отладки - получить все слова
    public string[] GetAllWords(string path)
    {
        string content = ReadFromFile(path);
        char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '-', '\t', '\n', '\r' };
        return content.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    }
}
