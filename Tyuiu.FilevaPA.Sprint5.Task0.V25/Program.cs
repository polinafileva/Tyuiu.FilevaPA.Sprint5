namespace Tyuiu.FilevaPA.Sprint5.Task0.V25.Test;
using Tyuiu.FilevaPA.Sprint5.Task0.V25.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.Title = "Спринт #5 | Выполнила: Филева П. А. | ИСПБ-25-1";

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* Спринт #5                                                               *");
        Console.WriteLine("* Тема: Класс File. Запись данных в текстовый файл                       *");
        Console.WriteLine("* Задание #0                                                              *");
        Console.WriteLine("* Вариант #25                                                             *");
        Console.WriteLine("* Выполнила: Филева Полина Алексеевна | ИСПБ-25-1                        *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* УСЛОВИЕ:                                                                *");
        Console.WriteLine("* Дано выражение вычислить его значение при x = 3, результат сохранить   *");
        Console.WriteLine("* в текстовый файл OutPutFileTask0.txt и вывести на консоль.             *");
        Console.WriteLine("* Округлить до трёх знаков после запятой.                                *");
        Console.WriteLine("* y(x) = (3x⁴ + 1) / x³                                                  *");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
        Console.WriteLine("***************************************************************************");

        int x = 3;
        Console.WriteLine($"x = {x}");
        Console.WriteLine($"Функция: y(x) = (3x⁴ + 1) / x³");

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
        Console.WriteLine("***************************************************************************");

        DataService ds = new DataService();
        string path = ds.SaveToFileTextData(x);

        // Чтение результата из файла и вывод на консоль
        string result;
        using (StreamReader reader = new StreamReader(path))
        {
            result = reader.ReadLine();
        }

        Console.WriteLine($"Значение функции при x = {x}: {result}");
        Console.WriteLine($"Результат сохранен в файл: {path}");

        // Детальный расчет
        Console.WriteLine("\nДетальный расчет:");
        double x4 = Math.Pow(x, 4);
        double x3 = Math.Pow(x, 3);
        double numerator = 3 * x4 + 1;
        double denominator = x3;
        double y = numerator / denominator;

        Console.WriteLine($"x⁴ = {x}⁴ = {x4}");
        Console.WriteLine($"x³ = {x}³ = {x3}");
        Console.WriteLine($"3x⁴ + 1 = 3 * {x4} + 1 = {numerator}");
        Console.WriteLine($"(3x⁴ + 1) / x³ = {numerator} / {x3} = {y}");
        Console.WriteLine($"Округлено до 3 знаков: {Math.Round(y, 3)}");

        Console.ReadKey();
    }
}