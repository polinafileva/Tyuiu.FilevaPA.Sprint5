namespace Tyuiu.FilevaPA.Sprint5.Task5.V9.Test;
using Tyuiu.FilevaPA.Sprint5.Task5.V9.Lib;
using System.IO;
[TestClass]
public sealed class DataServiceTest
{
    [TestMethod]
    public void TestMethod1()
    {
        DataService ds = new DataService();

        // Создаем временный файл с тестовыми данными
        string tempPath = Path.GetTempPath();
        string testInputPath = Path.Combine(tempPath, "InPutDataFileTask5V9.txt");
        File.WriteAllText(testInputPath, "15.69 13.69 -6 -7 -6.64 -4.35 -0.82 -3 -2 14 11 4 -9 -1.59 4 -2.6 -1 17 19.51 19.01");

        // Вызываем основной метод
        double result = ds.LoadFromDataFile(testInputPath);

        // Проверяем результат - максимальное целое число должно быть 19
        double expected = 19;
        Assert.AreEqual(expected, result, 0.001);

        // Очистка
        if (File.Exists(testInputPath))
        {
            File.Delete(testInputPath);
        }
    }

    [TestMethod]
    public void ValidLoadFromDataFileWithDifferentData()
    {
        DataService ds = new DataService();

        // Тест с другими данными
        string tempPath = Path.GetTempPath();
        string testInputPath = Path.Combine(tempPath, "test_file.txt");
        File.WriteAllText(testInputPath, "5.5 10.2 3 8.7 15 2.1");

        double result = ds.LoadFromDataFile(testInputPath);

        // Максимальное целое число должно быть 15
        double expected = 15;
        Assert.AreEqual(expected, result, 0.001);

        // Очистка
        if (File.Exists(testInputPath))
        {
            File.Delete(testInputPath);
        }
    }

    [TestMethod]
    public void ValidLoadFromDataFileOnlyIntegers()
    {
        DataService ds = new DataService();

        // Тест только с целыми числами
        string tempPath = Path.GetTempPath();
        string testInputPath = Path.Combine(tempPath, "test_file.txt");
        File.WriteAllText(testInputPath, "1 5 3 8 2 10");

        double result = ds.LoadFromDataFile(testInputPath);

        // Максимальное целое число должно быть 10
        double expected = 10;
        Assert.AreEqual(expected, result, 0.001);

        // Очистка
        if (File.Exists(testInputPath))
        {
            File.Delete(testInputPath);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(FileNotFoundException))]
    public void InvalidLoadFromDataFileNotFound()
    {
        DataService ds = new DataService();
        ds.LoadFromDataFile("nonexistent_file.txt");
    }

    [TestMethod]
    public void ValidGetAllNumbers()
    {
        DataService ds = new DataService();

        // Тест метода GetAllNumbers
        string tempPath = Path.GetTempPath();
        string testInputPath = Path.Combine(tempPath, "test_file.txt");
        File.WriteAllText(testInputPath, "1.5 2.7 3.0");

        string[] result = ds.GetAllNumbers(testInputPath);

        Assert.AreEqual(3, result.Length);
        Assert.AreEqual("1.500", result[0]);
        Assert.AreEqual("2.700", result[1]);
        Assert.AreEqual("3.000", result[2]);

        // Очистка
        if (File.Exists(testInputPath))
        {
            File.Delete(testInputPath);
        }
    }
}
