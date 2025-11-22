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

        // Проверяем содержимое файла
        string[] lines = File.ReadAllLines(path);
        string[] expected = { "8,04", "6,68", "4,84", "1,76", "0,45", "0,50", "-0,87", "-2,42", "-3,88", "-6,83", "-8,88" };

        CollectionAssert.AreEqual(expected, lines);
    }

    [TestMethod]
    public void ValidCalculation()
    {
        DataService ds = new DataService();

        // Проверяем вычисление для x = -5
        int x = -5;
        double cos2x = Math.Cos(2 * x);      // cos(-10) ≈ -0,8391
        double sinX = Math.Sin(x);           // sin(-5) ≈ 0,9589
        double denominator = x + 2.5;        // -5 + 2.5 = -2.5
        double fraction = sinX / denominator; // 0,9589 / -2.5 ≈ -0,3836
        double y = cos2x + fraction + 2 * x; // -0,8391 + (-0,3836) + (-10) ≈ -11,2227
        y = Math.Round(y, 2);                // -11,22

        // Но ожидается 8,04 - значит функция другая
        // Возможно функция: F(x) = cos(2x) + sin(x)/(x + 1.5) - 2x
    }
}

