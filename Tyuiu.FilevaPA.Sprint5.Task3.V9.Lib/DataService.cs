namespace Tyuiu.FilevaPA.Sprint5.Task3.V9.Lib;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task3V9
{
    public string SaveToFileTextData(int x)
    {
        string tempPath = Path.GetTempPath();
        string filePath = Path.Combine(tempPath, "OutPutFileTask3.bin");

        double result = CalculateFunction(x);

        // Сохраняем в бинарный файл
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            writer.Write(result);
        }

        return filePath;
    }

    public double CalculateFunction(int x)
    {
        try
        {
            // y = x³ / (x² - 1)
            double numerator = Math.Pow(x, 3); // x³
            double denominator = Math.Pow(x, 2) - 1; // x² - 1

            // Проверка деления на ноль
            if (Math.Abs(denominator) < double.Epsilon)
            {
                return 0;
            }

            double result = numerator / denominator;

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
}
