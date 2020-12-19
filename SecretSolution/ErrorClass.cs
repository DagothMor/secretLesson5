using System.Security.Cryptography;
using System.Web.Security;


/// Используя Random.Next для генерации нескольких случайных чисел для пароля, метод возвращает 1 и то же число при постоянных его вызовах,на самом деле каждый экземпляр вызванный пустым контруктором, при одинаковом начальным состоянием(текущая дата и время) будет по своей сути одинаков по отношению к другим.
string GeneratePassword()
{

    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine(GenerateDigit());
    }
    ...
static int GeneratePassword()
    {
        Random rng = new Random();
        // Предположим, что здесь много логики
        return rng.Next(10);
    }
}