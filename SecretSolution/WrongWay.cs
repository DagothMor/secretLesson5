using System;

public class Class1
{
	/// <summary>
	/// теперь генерятся разные числа но если вызвать несколько раз то сами наборы в нескольких
	/// экземплярах будут равны ибо проблема кроется в том же одинаковом значении при инициализа-
	/// ции.Сам класс Random не потокобезопасен.
	/// </summary>
	public Class1()
	{
		Random rng = new Random();
		for (int i = 0; i < 100; i++)
		{
			Console.WriteLine(GenerateDigit(rng));
		}
	}
	static int GenerateDigit(Random rng)
	{
		return rng.Next(10);
	}
}
