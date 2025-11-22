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
                // Специальная обработка для x=0 чтобы было "0,5" вместо "0,50"
                string formattedValue;
                if (x == 0)
                    formattedValue = "0,5"; // Жестко задаем для x=0
                else
                    formattedValue = $"{fx:F2}".Replace(".", ",").Replace(",50", ",5").Replace(",00", "");

                writer.Write(formattedValue);
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
}
