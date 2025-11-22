namespace Tyuiu.FilevaPA.Sprint5.Task2.V20.Lib;
using tyuiu.cources.programming.interfaces.Sprint5;
public class DataService : ISprint5Task2V20
{
    public string SaveToFileTextData(int[,] matrix)
    {
        string tempPath = Path.GetTempPath();
        string filePath = Path.Combine(tempPath, "OutPutFileTask2.csv");

        // Преобразуем массив перед сохранением
        int[,] transformedMatrix = TransformArray(matrix);

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            int rows = transformedMatrix.GetLength(0);
            int cols = transformedMatrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Записываем преобразованное значение в файл
                    writer.Write(transformedMatrix[i, j]);
                    if (j < cols - 1)
                        writer.Write(";");
                }
                writer.WriteLine();
            }
        }

        return filePath;
    }

    public int[,] TransformArray(int[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Положительные -> 1, отрицательные -> 0
                result[i, j] = (array[i, j] > 0) ? 1 : 0;
            }
        }

        return result;
    }
}
