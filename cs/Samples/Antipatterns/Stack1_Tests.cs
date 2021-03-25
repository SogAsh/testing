using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Samples.Antipatterns
{
    [TestFixture, Explicit]
	public class Stack1_Tests
	{
		[Test]
		public void Test() //смотри файл data.txt
		{
			var lines = File.ReadAllLines(@"C:\work\edu\testing-course\Patterns\bin\Debug\data.txt")
				.Select(line => line.Split(' '))
				.Select(line => new { command = line[0], value = line[1] });

			var stack = new Stack<string>();
			foreach (var line in lines)
			{
				if (line.command == "push")
					stack.Push(line.value);
				else
					Assert.AreEqual(line.value, stack.Pop());
			}
		}

		#region Почему это плохо?
		/*
		## Антипаттерн Local Hero

		Тест не будет работать на машине другого человека или на Build-сервере. 
		Да и у того же самого человека после Clean Solution / переустановки ОС / повторного Clone репозитория / ...

		## Решение

		Тест не должен зависеть от особенностей локальной среды.
		Если нужна работа с файлами, то поместить файлы в код (см. lines = new[] выше)
		либо включите файл в проект и настройте в свойствах его копирование в OutputDir,
		либо поместите его в ресурсы.

		var lines = File.ReadAllLines(@"data.txt") //положить файл в репо рядом с тестом
		var lines = Resources.data.Split(new []{"\r\n"}, StringSplitOptions.RemoveEmptyEntries) //скомпилировать файл в саму dll
		*/
		#endregion

		//Лучше так
		[Test]
		public void Test2() //смотри файл data.txt
		{
			var lines = File.ReadAllLines(@"E:\Работа\Workplace\KonturCourses\testing\cs\Samples\data.txt") //читаем данные из файла
				.Select(line => line.Split(' ')) //парсинг данных
				.Select(line => new { command = line[0], value = line[1] }); //в данных лежат команды и их значения

			//решение проблемы №1
			lines = new[]
			{
				new {command = "push", value = "1"}
			};


			var stack = new Stack<string>(); //создаем стэк
			foreach (var line in lines) //для каждой прочитанной команды смотрим что это за команда
			{
				if (line.command == "push") //если команда push
					stack.Push(line.value); //то мы делаем push значения
				else
					Assert.AreEqual(line.value, stack.Pop()); //если другая команда (Pop), то мы сравниваем значение из файла
															  //"value" со значением с вершины стэка
			}
		}
	}
}
