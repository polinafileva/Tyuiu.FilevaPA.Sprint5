namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;

using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task1V9
{
    public string SaveToFileTextData(int startValue, int stopValue)
    {
        string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask1.txt");

        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine("Табулирование функции F(x) = sin(x) + cos(2x)/2 - 1 + 5x");
            writer.WriteLine($"Диапазон: [{startValue}; {stopValue}], шаг: 1");
            writer.WriteLine("------------------------");
            writer.WriteLine("  x   |    F(x)   ");
            writer.WriteLine("------------------------");

            for (int x = startValue; x <= stopValue; x++)
            {
                double result = CalculateFunction(x);
                writer.WriteLine($"{x,5} | {result,9:F2}");
            }

            writer.WriteLine("------------------------");
        }

        return path;
    }

    private double CalculateFunction(int x)
    {
        // Проверка деления на ноль
        // В данной функции нет деления на x, но оставляем для демонстрации
        if (Math.Abs(x) < double.Epsilon)
        {
            return 0;
        }

        // F(x) = sin(x) + cos(2x)/2 - 1 + 5x
        return Math.Sin(x) + (Math.Cos(2 * x) / 2) - 1 + (5 * x);
    }
}
