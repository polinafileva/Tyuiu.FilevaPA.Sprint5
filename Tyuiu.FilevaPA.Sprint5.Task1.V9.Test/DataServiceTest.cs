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

        // Проверяем для x = -5
        double result = ds.CalculateFunction(-5);
        // F(-5) = sin(-5) + cos(-10)/2 - 1.5*(-5)
        // sin(-5) ≈ 0.958, cos(-10) ≈ -0.839
        // 0.958 + (-0.839)/2 - (-7.5) = 0.958 - 0.4195 + 7.5 ≈ 8.0385 ≈ 8.04
        double expected = 8.04;
        Assert.AreEqual(expected, result, 0.01);

        // Проверяем для x = 0
        result = ds.CalculateFunction(0);
        // F(0) = sin(0) + cos(0)/2 - 1.5*0 = 0 + 0.5 - 0 = 0.5
        expected = 0.5;
        Assert.AreEqual(expected, result, 0.01);

        // Проверяем для x = 5
        result = ds.CalculateFunction(5);
        // F(5) = sin(5) + cos(10)/2 - 1.5*5
        // sin(5) ≈ -0.958, cos(10) ≈ -0.839
        // -0.958 + (-0.839)/2 - 7.5 = -0.958 - 0.4195 - 7.5 ≈ -8.8775 ≈ -8.88
        expected = -8.88;
        Assert.AreEqual(expected, result, 0.01);
    }
}

