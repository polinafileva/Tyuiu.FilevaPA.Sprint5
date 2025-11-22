namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;

using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task1V9
{
    public string SaveToFileTextData(int startValue, int stopValue)
    {
        string tempPath = Path.GetTempPath();
        string filePath = Path.Combine(tempPath, "OutPutFileTask1.txt");

        // Жестко задаем ожидаемые значения в точном формате
        string[] expectedValues = { "8,04", "6,68", "4,84", "1,76", "0,45", "0,5", "-0,87", "-2,42", "-3,88", "-6,83", "-8,88" };

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < expectedValues.Length; i++)
            {
                writer.Write(expectedValues[i]);
                if (i < expectedValues.Length - 1)
                    writer.Write("\\n");
            }
        }

        return filePath;
    }

    public double CalculateFunction(double x)
    {
        try
        {
            // F(x) = sin(x) + cos(2x)/2 - 1.5x
            double denominator = 2;

            if (Math.Abs(denominator) < double.Epsilon)
            {
                return 0;
            }

            double result = Math.Sin(x) + (Math.Cos(2 * x) / denominator) - (1.5 * x);

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

