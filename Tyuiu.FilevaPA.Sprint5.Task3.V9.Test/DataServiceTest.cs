namespace Tyuiu.FilevaPA.Sprint5.Task3.V9.Test;
    using Tyuiu.FilevaPA.Sprint5.Task3.V9.Lib;
using System.IO;

    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void TestMethod1()
    {
        DataService ds = new DataService();

        int x = 3;

        string resultPath = ds.SaveToFileTextData(x);

        // Проверяем, что метод возвращает путь к файлу
        Assert.IsNotNull(resultPath);
        Assert.IsTrue(resultPath.Contains("OutPutFileTask3.bin"));

        // Проверяем, что файл создан
        Assert.IsTrue(File.Exists(resultPath));

        // Проверяем содержимое файла
        double fileValue = ReadFromBinaryFile(resultPath);
        double expected = ds.CalculateFunction(x);
        Assert.AreEqual(expected, fileValue, 0.001);

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

        // Проверяем для x = 3
        double result = ds.CalculateFunction(3);
        // y = 3³ / (3² - 1) = 27 / (9 - 1) = 27 / 8 = 3.375
        double expected = 3.375;
        Assert.AreEqual(expected, result, 0.001);

        // Проверяем для x = 2
        result = ds.CalculateFunction(2);
        // y = 2³ / (2² - 1) = 8 / (4 - 1) = 8 / 3 ≈ 2.667
        expected = 2.667;
        Assert.AreEqual(expected, result, 0.001);

        // Проверяем для x = 1 (деление на ноль)
        result = ds.CalculateFunction(1);
        // y = 1³ / (1² - 1) = 1 / 0 = должна вернуть 0
        Assert.AreEqual(0, result, 0.001);
    }

    [TestMethod]
    public void ValidDivisionByZero()
    {
        DataService ds = new DataService();

        // Проверяем обработку деления на ноль для x = 1
        double result = ds.CalculateFunction(1);
        Assert.AreEqual(0, result, 0.001);

        // Проверяем обработку деления на ноль для x = -1
        result = ds.CalculateFunction(-1);
        Assert.AreEqual(0, result, 0.001);
    }

    private double ReadFromBinaryFile(string filePath)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            return reader.ReadDouble();
        }
    }
    }

