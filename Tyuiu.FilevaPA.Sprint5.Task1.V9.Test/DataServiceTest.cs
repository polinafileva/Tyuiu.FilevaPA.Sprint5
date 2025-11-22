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

        // Проверка что файл создан
        Assert.IsTrue(File.Exists(path));

        // Проверка количества строк (11 строк: от -5 до 5 включительно)
        string[] lines = File.ReadAllLines(path);
        Assert.AreEqual(11, lines.Length);

        // Проверка что все значения являются числами
        foreach (string line in lines)
        {
            Assert.IsTrue(double.TryParse(line, out double result));
        }
    }
}

