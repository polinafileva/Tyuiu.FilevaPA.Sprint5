namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;

using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task1V9
{
    public string SaveToFileTextData(int startValue, int stopValue)
    {

        string tempPath = Path.GetTempPath();
        string filePath = Path.Combine(tempPath, "OutPutFileTask1.txt");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int x = startValue; x <= stopValue; x++)
            {
                double fx = CalculateFunction(x);
                writer.Write($"{fx:F2}");
                if (x < stopValue)
                    writer.Write("\\n");
            }
        }

        return filePath;
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

            // Правильный расчет функции
            double sinX = Math.Sin(x);
            double cos2x = Math.Cos(2 * x);
            double result = sinX + (cos2x / denominator) - 1;

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

    public double[,] GetTabulation(int startValue, int stopValue)
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

        return result;
    }
}
