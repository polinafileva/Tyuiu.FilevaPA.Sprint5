namespace Tyuiu.FilevaPA.Sprint5.Task4.V10.Lib;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task4V10
{
    public double LoadFromDataFile(string path)
    {
        // Читаем значение x из файла
        double x = ReadValueFromFile(path);

        // Вычисляем результат по формуле: y = x³ * 1.2x + 2
        double result = Calculate(x);

        return result;
    }

    public double Calculate(double x)
    {
        try
        {
            // y = x³ * 1.2x + 2
            // Это можно записать как: y = 1.2 * x⁴ + 2
            double result = (1.2 * Math.Pow(x, 4)) + 2;

            // Проверка на особые случаи
            if (double.IsNaN(result) || double.IsInfinity(result))
            {
                return 0;
            }

            return Math.Round(result, 3);
        }
        catch
        {
            return 0;
        }
    }

    private double ReadValueFromFile(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }

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
        catch (Exception ex)
        {
            throw new Exception($"Ошибка чтения файла: {ex.Message}");
        }
    }

    public string SaveToFileTextData(string path)
    {
        double result = LoadFromDataFile(path);

        // Сохраняем результат в новый файл
        string tempPath = Path.GetTempPath();
        string outputPath = Path.Combine(tempPath, "OutPutFileTask4.txt");

        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            writer.WriteLine($"Вычисленное значение: {result:F3}");
        }

        return outputPath;
    }
}
