using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Samples.Antipatterns
{
    [TestFixture, Explicit]
    public class Stack2_Tests
	{
		[Test]
		public void TestPushPop()
		{
			var stack = new Stack<int>();
			stack.Push(10);
			stack.Push(20);
			stack.Push(30);
			while (stack.Any()) //пока стек не пустой
				Console.WriteLine(stack.Pop()); //надо доставать значения и печатать
		}

		#region Почему это плохо?
		/*
		## Антипаттерн Loudmouth

		Тест не является автоматическим. Если он сломается, никто этого не заметит.

		## Мораль

		Вместо вывода на консоль, используйте Assert-ы.
		*/
		//Лучше так
		[Test]
		public void TestPushPop2()
		{
			var stack = new Stack<int>();
			stack.Push(10);
			stack.Push(20);
			stack.Push(30);

			var values = new List<int>(); //создаем коллекцию
			while (stack.Any()) //пока стек не пустой
				values.Add(stack.Pop()); //добавить значения из стека в коллекцию
			Assert.That(values, Is.EqualTo(new[] { 30, 20, 10 })); //проверяем что в этой колеекция оказалось то что мы ожидаем
		}
		#endregion
	}
}
