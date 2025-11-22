namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;

using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task1V9
{
    public string SaveToFileTextData(int startValue, int stopValue)
    {
        
        string path = "OutPutFileTask1.txt"; // Будет создан в bin/Debug/net8.0/

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
            double denominator = 2;

            if (Math.Abs(denominator) < double.Epsilon)
            {
                return 0;
            }

            double result = Math.Sin(x) + (Math.Cos(2 * x) / denominator) - 1;

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
}
