namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;

using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task1V9
{
    public string SaveToFileTextData(int startValue, int stopValue)
    {
        string path = $"OutPutFileTask1.txt";

        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine("x\t\tF(x)");
            writer.WriteLine("-------------------");

            for (int x = startValue; x <= stopValue; x++)
            {
                double fx = CalculateFunction(x);
                writer.WriteLine($"{x}\t\t{fx:F2}");
            }
        }

        return Path.GetFullPath(path);
    }

    public double CalculateFunction(double x)
    {
        try
        {
            // F(x) = sin(x) + cos(2x)/2 - 1
            double denominator = 2; // знаменатель

            // Проверка деления на ноль
            if (Math.Abs(denominator) < double.Epsilon)
            {
                return 0;
            }

            double result = Math.Sin(x) + (Math.Cos(2 * x) / denominator) - 1;

            // Проверка на особые случаи
            if (double.IsNaN(result) || double.IsInfinity(result))
            {
                return 0;
            }

            return Math.Round(result, 2);
        }
        catch
        {
            return 0;
        }
    }

    public double[,] CalculateTabulation(int startValue, int stopValue)
    {
        int count = stopValue - startValue + 1;
        double[,] result = new double[count, 2];
        int index = 0;

        for (int x = startValue; x <= stopValue; x++)
        {
            double fx = CalculateFunction(x);
            result[index, 0] = x;
            result[index, 1] = fx;
            index++;
        }
        // Создание пути к файлу
        string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask1.txt");

        // Запись результата в файл
        File.WriteAllText(path, y.ToString());

        return result;
    }
}
