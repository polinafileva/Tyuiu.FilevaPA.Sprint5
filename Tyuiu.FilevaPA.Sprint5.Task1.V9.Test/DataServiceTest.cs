namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Test;
using Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;
[TestClass]
public sealed class DataServiceTest
{
    [TestMethod]
    public void TestMethod1()
    {
        DataService ds = new DataService();

        int startValue = -2;
        int stopValue = 2;

        string resultPath = ds.SaveToFileTextData(startValue, stopValue);

        // Проверяем, что метод возвращает путь к файлу
        Assert.IsNotNull(resultPath);
        Assert.IsTrue(resultPath.Contains("OutPutFileTask1.txt"));

        // Проверяем, что файл создан
        Assert.IsTrue(File.Exists(resultPath));

        // Проверяем содержимое файла
        string[] lines = File.ReadAllLines(resultPath);
        Assert.IsTrue(lines.Length >= 5); // заголовок + 5 строк данных

        // Проверяем заголовок
        Assert.AreEqual("x\t\tF(x)", lines[0]);

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

        // Тест для x = 0
        double x = 0;
        double result = ds.CalculateFunction(x);
        double expected = Math.Round(Math.Sin(0) + (Math.Cos(0) / 2) - 1, 2); // 0 + 0.5 - 1 = -0.5
        Assert.AreEqual(expected, result);

        // Тест для x = 1
        x = 1;
        result = ds.CalculateFunction(x);
        expected = Math.Round(Math.Sin(1) + (Math.Cos(2) / 2) - 1, 2);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ValidCalculateTabulation()
    {
        DataService ds = new DataService();

        int startValue = -1;
        int stopValue = 1;

        double[,] result = ds.CalculateTabulation(startValue, stopValue);

        // Проверяем размерность результата
        Assert.AreEqual(3, result.GetLength(0)); // от -1 до 1 включительно = 3 значения
        Assert.AreEqual(2, result.GetLength(1)); // x и F(x)

        // Проверяем значения x
        Assert.AreEqual(-1, result[0, 0]);
        Assert.AreEqual(0, result[1, 0]);
        Assert.AreEqual(1, result[2, 0]);
    }
}

