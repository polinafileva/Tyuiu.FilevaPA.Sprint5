namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Test;
using Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;
using System.IO;
[TestClass]
public sealed class DataServiceTest
{
    [TestMethod]
    public void TestMethod1()
    {
        DataService ds = new DataService();

        int startValue = -5;
        int stopValue = 5;

        string resultPath = ds.SaveToFileTextData(startValue, stopValue);

        // Проверяем, что метод возвращает путь к файлу
        Assert.IsNotNull(resultPath);
        Assert.IsTrue(resultPath.Contains("OutPutFileTask1.txt"));

        // Проверяем, что файл создан
        Assert.IsTrue(File.Exists(resultPath));

        // Проверяем содержимое файла
        string content = File.ReadAllText(resultPath);
        Assert.IsNotNull(content);

        // Очистка
        if (File.Exists(resultPath))
        {
            File.Delete(resultPath);
        }
    }

    [TestMethod]
    public void ValidCalculateFunction()
    {
        DataService ds = new DataService();

        // Проверяем правильность расчета для нескольких точек
        // F(x) = sin(x) + cos(2x)/2 - 1

        // Для x = -5
        double result = ds.CalculateFunction(-5);
        double expected = Math.Round(Math.Sin(-5) + (Math.Cos(-10) / 2) - 1, 2);
        Assert.AreEqual(expected, result);

        // Для x = 0
        result = ds.CalculateFunction(0);
        expected = Math.Round(Math.Sin(0) + (Math.Cos(0) / 2) - 1, 2); // 0 + 0.5 - 1 = -0.5
        Assert.AreEqual(expected, result);

        // Для x = 5
        result = ds.CalculateFunction(5);
        expected = Math.Round(Math.Sin(5) + (Math.Cos(10) / 2) - 1, 2);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ValidGetTabulation()
    {
        DataService ds = new DataService();

        int startValue = -2;
        int stopValue = 2;

        double[,] result = ds.GetTabulation(startValue, stopValue);

        // Проверяем размерность результата
        Assert.AreEqual(5, result.GetLength(0)); // от -2 до 2 включительно = 5 значений
        Assert.AreEqual(2, result.GetLength(1)); // x и F(x)

        // Проверяем значения x
        Assert.AreEqual(-2, result[0, 0]);
        Assert.AreEqual(-1, result[1, 0]);
        Assert.AreEqual(0, result[2, 0]);
        Assert.AreEqual(1, result[3, 0]);
        Assert.AreEqual(2, result[4, 0]);
    }
}

