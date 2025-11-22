namespace Tyuiu.FilevaPA.Sprint5.Task7.V10.Test;
using Tyuiu.FilevaPA.Sprint5.Task7.V10.Lib;
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
        string testInputPath = Path.Combine(tempPath, "InPutDataFileTask7V10.txt");
        File.WriteAllText(testInputPath, "Hello, Мир! Это Is My First Program.");

        // Вызываем основной метод
        string resultPath = ds.LoadDataAndSave(testInputPath);

        // Проверяем, что метод возвращает путь к файлу
        Assert.IsNotNull(resultPath);
        Assert.IsTrue(resultPath.Contains("OutPutDataFileTask7V10.txt"));

        // Проверяем, что файл создан
        Assert.IsTrue(File.Exists(resultPath));

        // Проверяем содержимое файла
        string outputContent = File.ReadAllText(resultPath);
        string expected = "hello, Мир! Это is my first program.";
        Assert.AreEqual(expected, outputContent);

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

    [TestMethod]
    public void ValidTransformContent()
    {
        DataService ds = new DataService();

        // Прямой тест преобразования
        string input = "ABCdef АБВГД 123 !@# XYZ";
        string result = ds.GetTransformedContent(CreateTestFile(input));

        string expected = "abcdef АБВГД 123 !@# xyz";
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ValidTransformContentOnlyLowercase()
    {
        DataService ds = new DataService();

        // Тест со строчными буквами (не должны изменяться)
        string input = "hello world привет мир";
        string result = ds.GetTransformedContent(CreateTestFile(input));

        string expected = "hello world привет мир";
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ValidTransformContentOnlyUppercase()
    {
        DataService ds = new DataService();

        // Тест только с заглавными латинскими буквами
        string input = "HELLO WORLD";
        string result = ds.GetTransformedContent(CreateTestFile(input));

        string expected = "hello world";
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ValidTransformContentMixed()
    {
        DataService ds = new DataService();

        // Тест со смешанными символами
        string input = "Hello, World! 123 ABC abc АБВ";
        string result = ds.GetTransformedContent(CreateTestFile(input));

        string expected = "hello, world! 123 abc abc АБВ";
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [ExpectedException(typeof(FileNotFoundException))]
    public void InvalidLoadDataAndSaveNotFound()
    {
        DataService ds = new DataService();
        ds.LoadDataAndSave("nonexistent_file.txt");
    }

    private string CreateTestFile(string content)
    {
        string tempPath = Path.GetTempPath();
        string testInputPath = Path.Combine(tempPath, "test_file.txt");
        File.WriteAllText(testInputPath, content);
        return testInputPath;
    }
}
