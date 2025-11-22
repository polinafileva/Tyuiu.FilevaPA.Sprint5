namespace Tyuiu.FilevaPA.Sprint5.Task0.V25.Lib;

using tyuiu.cources.programming.interfaces.Sprint5;


public class DataService : ISprint5Task0V25
{
    public string SaveToFileTextData(int x)
    {
        // Вычисление значения функции
        double numerator = 3 * Math.Pow(x, 4) + 1;
        double denominator = Math.Pow(x, 3);
        double y = numerator / denominator;

        // Округление до трех знаков после запятой
        y = Math.Round(y, 3);

        // Создание пути к файлу
        string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask0.txt");

        // Запись результата в файл
        File.WriteAllText(path, y.ToString());


        return path;
    }
}

