namespace Tyuiu.FilevaPA.Sprint5.Task5.V9.Lib;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task5V9
{
    public double LoadFromDataFile(string path)
    {
        // Читаем все значения из файла
        double[] numbers = ReadValuesFromFile(path);

        // Находим максимальное целое число
        double maxInteger = FindMaxInteger(numbers);

        return maxInteger;
    }

    private double[] ReadValuesFromFile(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }

            string content = File.ReadAllText(path);
            string[] stringValues = content.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double[] numbers = new double[stringValues.Length];
            for (int i = 0; i < stringValues.Length; i++)
            {
                if (double.TryParse(stringValues[i], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double value))
                {
                    numbers[i] = Math.Round(value, 3); // Округляем вещественные до 3 знаков
                }
                else
                {
                    throw new FormatException($"Неверный формат данных: {stringValues[i]}");
                }
            }

            return numbers;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка чтения файла: {ex.Message}");
        }
    }

    private double FindMaxInteger(double[] numbers)
    {
        double maxInteger = double.MinValue;
        bool foundInteger = false;

        foreach (double number in numbers)
        {
            // Проверяем, является ли число целым
            if (Math.Abs(number % 1) < 0.0001) // Учитываем погрешность округления
            {
                if (!foundInteger || number > maxInteger)
                {
                    maxInteger = number;
                    foundInteger = true;
                }
            }
        }

        if (!foundInteger)
        {
            throw new InvalidOperationException("В файле нет целых чисел");
        }

        return maxInteger;
    }

    // Дополнительный метод для вывода всех чисел (для отладки)
    public string[] GetAllNumbers(string path)
    {
        double[] numbers = ReadValuesFromFile(path);
        return numbers.Select(n => n.ToString("F3")).ToArray();
    }
}
