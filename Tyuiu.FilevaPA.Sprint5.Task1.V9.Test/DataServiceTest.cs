namespace Tyuiu.FilevaPA.Sprint5.Task1.V9.Test;
using Tyuiu.FilevaPA.Sprint5.Task1.V9.Lib;
[TestClass]
public sealed class DataServiceTest
{
    [TestMethod]
    public void TestMethod1()
    {
        DataService ds = new DataService();

        int startValue = -5;
        int stopValue = 5;
        string path = ds.SaveToFileTextData(startValue, stopValue);

        // Проверяем что файл создан
        Assert.IsTrue(File.Exists(path));

        // Проверяем количество строк в файле
        string[] lines = File.ReadAllLines(path);
        int expectedLines = stopValue - startValue + 1; // 11 строк
        Assert.AreEqual(expectedLines, lines.Length);
    }

    [TestMethod]
    public void ValidFileContentFormat()
    {
        DataService ds = new DataService();

        int startValue = -2;
        int stopValue = 2;
        string path = ds.SaveToFileTextData(startValue, stopValue);

        string[] lines = File.ReadAllLines(path);

        // Проверяем формат чисел (должны быть с двумя знаками после запятой)
        foreach (string line in lines)
        {
            Assert.IsTrue(double.TryParse(line, out double result));
            // Проверяем что число округлено до двух знаков
            string[] parts = line.Split('.');
            if (parts.Length > 1)
            {
                Assert.IsTrue(parts[1].Length <= 2);
            }
        }
    }
}
