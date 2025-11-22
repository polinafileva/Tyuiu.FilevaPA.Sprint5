namespace Tyuiu.FilevaPA.Sprint5.Task7.V10.Lib;

using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task7V10
{
    public string LoadDataAndSave(string path)
    {
        // Читаем строку из файла
        string content = ReadFromFile(path);

        // Заменяем заглавные латинские буквы на строчные
        string transformedContent = TransformContent(content);

        // Сохраняем результат в файл
        string outputPath = SaveToFile(transformedContent);

        return outputPath;
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

    private string TransformContent(string content)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in content)
        {
            // Если символ - заглавная латинская буква, заменяем на строчную
            if (c >= 'A' && c <= 'Z')
            {
                result.Append(char.ToLower(c));
            }
            else
            {
                result.Append(c); // Оставляем остальные символы без изменений
            }
        }

        return result.ToString();
    }

    private string SaveToFile(string content)
    {
        string tempPath = Path.GetTempPath();
        string outputPath = Path.Combine(tempPath, "OutPutDataFileTask7V10.txt");

        using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
        {
            writer.Write(content);
        }

        return outputPath;
    }

    // Дополнительный метод для получения исходного содержимого
    public string GetOriginalContent(string path)
    {
        return ReadFromFile(path);
    }

    // Дополнительный метод для получения преобразованного содержимого
    public string GetTransformedContent(string path)
    {
        string content = ReadFromFile(path);
        return TransformContent(content);
    }
}
