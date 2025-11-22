namespace Tyuiu.FilevaPA.Sprint5.Task2.V20;
using Tyuiu.FilevaPA.Sprint5.Task2.V20.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        DataService ds = new DataService();

        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                      *");
        Console.WriteLine("**************************************************************************");

        // Создаем массив 3x3
        int[,] array = new int[3, 3];

        Console.WriteLine("Введите 9 элементов массива 3x3:");

        // Заполнение массива с клавиатуры
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Элемент [{i},{j}]: ");
                array[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Вывод исходного массива
        Console.WriteLine("\nИсходный массив:");
        PrintArray(array);

        Console.WriteLine("**************************************************************************");
        Console.WriteLine("* РЕЗУЛЬТАТ:                                                            *");
        Console.WriteLine("**************************************************************************");

        // Преобразование массива
        int[,] transformedArray = ds.TransformArray(array);

        // Вывод преобразованного массива
        Console.WriteLine("Преобразованный массив:");
        PrintArray(transformedArray);

        // Сохранение в файл с использованием нового метода
        string filePath = ds.SaveToFileTextData(transformedArray);
        Console.WriteLine($"Результат сохранен в файл: {filePath}");

        Console.ReadKey();
    }

    static void PrintArray(int[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}