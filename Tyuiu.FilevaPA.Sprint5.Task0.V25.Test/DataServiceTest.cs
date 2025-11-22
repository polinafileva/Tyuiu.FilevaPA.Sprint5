namespace Tyuiu.FilevaPA.Sprint5.Task0.V25.Test;
using Tyuiu.FilevaPA.Sprint5.Task0.V25.Lib;
[TestClass]
public sealed class DataServiceTest
{
    [TestMethod]
    public void TestMethod1()
    {
        DataService ds = new DataService();

        int x = 3;
        string path = ds.SaveToFileTextData(x);

        // Проверяем что файл создан
        Assert.IsTrue(File.Exists(path));

        // Читаем результат из файла
        string result;
        using (StreamReader reader = new StreamReader(path))
        {
            result = reader.ReadLine();
        }

        // Проверяем корректность вычислений
        // При x = 3: (3*81 + 1) / 27 = (243 + 1) / 27 = 244 / 27 ≈ 9.037
        double expected = 9.037;
        double actual = double.Parse(result);

        Assert.AreEqual(expected, actual, 0.001);
    }

    [TestMethod]
    public void ValidCalculation()
    {
        DataService ds = new DataService();

        int x = 3;
        string path = ds.SaveToFileTextData(x);

        // Проверяем вычисления вручную
        double numerator = 3 * Math.Pow(3, 4) + 1; // 3*81 + 1 = 243 + 1 = 244
        double denominator = Math.Pow(3, 3);       // 27
        double expected = Math.Round(numerator / denominator, 3); // 244/27 ≈ 9.037

        string result;
        using (StreamReader reader = new StreamReader(path))
        {
            result = reader.ReadLine();
        }

        double actual = double.Parse(result);
        Assert.AreEqual(expected, actual);
    }
}
