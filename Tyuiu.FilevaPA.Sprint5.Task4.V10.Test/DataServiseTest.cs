namespace Tyuiu.FilevaPA.Sprint5.Task4.V10.Test;
using Tyuiu.FilevaPA.Sprint5.Task4.V10.Lib;
using System.IO;
[TestClass]
public sealed class DataServiseTest
{
    [TestMethod]
    public void TestMethod1()
    {
        DataService ds = new DataService();

        // Создаем временный файл с данными 2.74
        string tempPath = Path.GetTempPath();
        string testInputPath = Path.Combine(tempPath, "InPutDataFileTask4V10.txt");
        File.WriteAllText(testInputPath, "2.74");

        // Вызываем основной метод
        double result = ds.LoadFromDataFile(testInputPath);

        // Проверяем результат
        // Для x = 2.74: y = 2.74³ * 1.2 * 2.74 + 2 = 69.631
        double expected = 69.631;
        Assert.AreEqual(expected, result, 0.001);

        // Очистка
        if (File.Exists(testInputPath))
        {
            File.Delete(testInputPath);
        }
    }

    [TestMethod]
    public void ValidLoadFromDataFileWithDifferentValues()
    {
        DataService ds = new DataService();

        // Тест с другим значением
        string tempPath = Path.GetTempPath();
        string testInputPath = Path.Combine(tempPath, "test_file.txt");
        File.WriteAllText(testInputPath, "3.0");

        double result = ds.LoadFromDataFile(testInputPath);

        // Для x = 3.0: y = 3³ * 1.2 * 3 + 2 = 27 * 3.6 + 2 = 99.2
        double expected = 99.2;
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
    public void ValidCalculate()
    {
        DataService ds = new DataService();

        // Прямой тест метода Calculate
        double result = ds.Calculate(2.74);
        double expected = 69.631;
        Assert.AreEqual(expected, result, 0.001);
    }

    [TestMethod]
    public void ValidSaveToFileTextData()
    {
        DataService ds = new DataService();

        // Создаем временный файл с данными
        string tempPath = Path.GetTempPath();
        string testInputPath = Path.Combine(tempPath, "InPutDataFileTask4V10.txt");
        File.WriteAllText(testInputPath, "2.74");

        string resultPath = ds.SaveToFileTextData(testInputPath);

        // Проверяем, что файл создан
        Assert.IsTrue(File.Exists(resultPath));

        // Проверяем содержимое
        string content = File.ReadAllText(resultPath);
        Assert.IsTrue(content.Contains("69.631"));

        // Очистка
        if (File.Exists(testInputPath))
        {
            File.Delete(testInputPath);
        }
        if (File.Exists(resultPath))
        {
            File.Delete(resultPath);
        }
    }
}
