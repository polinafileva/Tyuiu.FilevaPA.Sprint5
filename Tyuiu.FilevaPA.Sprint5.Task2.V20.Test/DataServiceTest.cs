namespace Tyuiu.FilevaPA.Sprint5.Task2.V20.Test;
using Tyuiu.FilevaPA.Sprint5.Task2.V20.Lib;
using System.IO;
[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        DataService ds = new DataService();

        int[,] inputArray = {
                { 5, -5, -1 },
                { -4, 2, -4 },
                { -7, 1, 4 }
            };

        string filePath = ds.SaveToFileTextData(inputArray);

        // Проверяем, что файл создан
        Assert.IsTrue(File.Exists(filePath));
        Assert.IsTrue(filePath.Contains("OutPutFileTask2.csv"));

        // Проверяем содержимое файла - должно быть преобразованное
        string[] lines = File.ReadAllLines(filePath);
        Assert.AreEqual(3, lines.Length);

        // Проверяем, что сохранились преобразованные значения
        Assert.AreEqual("1;0;0", lines[0]);  // 5->1, -5->0, -1->0
        Assert.AreEqual("0;1;0", lines[1]);  // -4->0, 2->1, -4->0
        Assert.AreEqual("0;1;1", lines[2]);  // -7->0, 1->1, 4->1

        // Очистка
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    [TestMethod]
    public void ValidTransformArray()
    {
        DataService ds = new DataService();

        int[,] inputArray = {
                { 5, -5, -1 },
                { -4, 2, -4 },
                { -7, 1, 4 }
            };

        int[,] result = ds.TransformArray(inputArray);

        // Проверяем преобразование
        Assert.AreEqual(1, result[0, 0]);  // 5 -> 1
        Assert.AreEqual(0, result[0, 1]);  // -5 -> 0
        Assert.AreEqual(0, result[0, 2]);  // -1 -> 0
        Assert.AreEqual(0, result[1, 0]);  // -4 -> 0
        Assert.AreEqual(1, result[1, 1]);  // 2 -> 1
        Assert.AreEqual(0, result[1, 2]);  // -4 -> 0
        Assert.AreEqual(0, result[2, 0]);  // -7 -> 0
        Assert.AreEqual(1, result[2, 1]);  // 1 -> 1
        Assert.AreEqual(1, result[2, 2]);  // 4 -> 1
    }
}
