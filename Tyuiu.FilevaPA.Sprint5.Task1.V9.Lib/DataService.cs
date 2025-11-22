namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task1V9
{
    public string SaveToFileTextData(int startValue, int stopValue)
    {
        // Создание пути к файлу
        string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask1.txt");

        using (StreamWriter writer = new StreamWriter(path))
        {
            // Табулирование функции
            for (int x = startValue; x <= stopValue; x++)
            {
                double y = CalculateFunction(x);
                writer.WriteLine(y.ToString("F2"));
            }
        }

        return path;
    }

    private double CalculateFunction(int x)
    {
        try
        {
            // Вычисление значения функции F(x) = cos(2x) + (sin(x))/(x + 2.5) + 2x
            double cos2x = Math.Cos(2 * x);
            double sinX = Math.Sin(x);
            double denominator = x + 2.5;

            // Проверка деления на ноль
            if (Math.Abs(denominator) < 0.0001)
            {
                return 0;
            }

            double fraction = sinX / denominator;
            double y = cos2x + fraction + 2 * x;

            // Округление до двух знаков после запятой
            return Math.Round(y, 2);
        }
        catch
        {
            // В случае ошибки возвращаем 0
            return 0;
        }
    }
}
