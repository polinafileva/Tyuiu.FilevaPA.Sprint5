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
        Assert.IsTrue(lines.Length >= 5);

        // Очистка
        if (File.Exists(resultPath))
        {
            File.Delete(resultPath);
        }
    }
}

