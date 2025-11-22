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

        // Проверяем точное содержимое файла
        string content = File.ReadAllText(resultPath);
        string expected = "8,04\\n6,68\\n4,84\\n1,76\\n0,45\\n0,5\\n-0,87\\n-2,42\\n-3,88\\n-6,83\\n-8,88";
        Assert.AreEqual(expected, content);

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

        // Проверяем корректность расчета функции
        double result = ds.CalculateFunction(-5);
        double expected = 8.04;
        Assert.AreEqual(expected, result, 0.01);
    }
}

