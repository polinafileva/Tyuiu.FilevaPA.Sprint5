namespace Tyuiu.FilevaPA.Sprint5.Task6.V29.Test;
using Tyuiu.FilevaPA.Sprint5.Task6.V29.Lib;
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
        string testInputPath = Path.Combine(tempPath, "InPutDataFileTask6V29.txt");
        File.WriteAllText(testInputPath, "Это просто пятница или четверг или строчка из букв");

        // Вызываем основной метод
        int result = ds.LoadFromDataFile(testInputPath);

        // Проверяем результат
        // Слова длиной 7 символов: "пятница" (7), "строчка" (7)
        int expected = 2;
        Assert.AreEqual(expected, result);

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
        File.WriteAllText(testInputPath, "программирование компьютер алгоритм данные система");

        int result = ds.LoadFromDataFile(testInputPath);

        // Слова длиной 7 символов: "алгоритм" (8), "данные" (6), "система" (7)
        int expected = 1;
        Assert.AreEqual(expected, result);

        // Очистка
        if (File.Exists(testInputPath))
        {
            File.Delete(testInputPath);
        }
    }

    [TestMethod]
    public void ValidLoadFromDataFileNoWordsWithLength7()
    {
        DataService ds = new DataService();

        // Тест без слов длиной 7 символов
        string tempPath = Path.GetTempPath();
        string testInputPath = Path.Combine(tempPath, "test_file.txt");
        File.WriteAllText(testInputPath, "мама папа дом кот собака");

        int result = ds.LoadFromDataFile(testInputPath);

        // Все слова короче 7 символов
        int expected = 0;
        Assert.AreEqual(expected, result);

        // Очистка
        if (File.Exists(testInputPath))
        {
            File.Delete(testInputPath);
        }
    }

    [TestMethod]
    public void ValidLoadFromDataFileWithPunctuation()
    {
        DataService ds = new DataService();

        // Тест со знаками препинания
        string tempPath = Path.GetTempPath();
        string testInputPath = Path.Combine(tempPath, "test_file.txt");
        File.WriteAllText(testInputPath, "Привет, мир! Как дела? Хорошо.");

        int result = ds.LoadFromDataFile(testInputPath);

        // Слова: "Привет" (6), "мир" (3), "Как" (3), "дела" (4), "Хорошо" (6)
        int expected = 0;
        Assert.AreEqual(expected, result);

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
    public void ValidGetAllWords()
    {
        DataService ds = new DataService();

        // Тест метода GetAllWords
        string tempPath = Path.GetTempPath();
        string testInputPath = Path.Combine(tempPath, "test_file.txt");
        File.WriteAllText(testInputPath, "Это тестовая строка");

        string[] result = ds.GetAllWords(testInputPath);

        Assert.AreEqual(3, result.Length);
        Assert.AreEqual("Это", result[0]);
        Assert.AreEqual("тестовая", result[1]);
        Assert.AreEqual("строка", result[2]);

        // Очистка
        if (File.Exists(testInputPath))
        {
            File.Delete(testInputPath);
        }
    }
}
