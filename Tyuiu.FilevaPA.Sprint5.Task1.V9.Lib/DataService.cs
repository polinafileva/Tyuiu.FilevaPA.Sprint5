namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;

using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task1V9
{
    public string SaveToFileTextData(int startValue, int stopValue)
    {
        string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask1.txt");

        StringBuilder sb = new StringBuilder();

        for (int x = startValue; x <= stopValue; x++)
        {
            double result = CalculateFunction(x);
            sb.AppendLine($"{Math.Round(result, 2)}");
        }

        File.WriteAllText(path, sb.ToString());
        return path;
    }

    private double CalculateFunction(int x)
    {
        double denominator = 3 * x + 1.2;

        // Проверка деления на ноль
        if (Math.Abs(denominator) < 0.0001)
        {
            return 0;
        }

        // F(x) = (2sin(x))/(3x+1.2) + cos(x) - 7x * 2
        double part1 = (2 * Math.Sin(x)) / denominator;
        double part2 = Math.Cos(x);
        double part3 = 14 * x;

        return part1 + part2 - part3;
    }
}
