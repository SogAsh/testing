using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;

namespace Samples.Parametrized
{
	[TestFixture]
	public class Double_Should
	{
		[Test, TestCaseSource(nameof(DivideTestCases))] //в презентации не было, но принцип такойже как внизу посде //---
		public double Divide(double a, double b)
		{
			return a / b;
		}

		public static IEnumerable DivideTestCases //в презентации не было
		{
			get
			{
				yield return new TestCaseData(12.0, 3.0).Returns(4);
				yield return new TestCaseData(12.0, 2.0).Returns(6);
				yield return new TestCaseData(12.0, 4.0).Returns(3);
			}
		}

		//------------------------------------------------------------------------------------------------------------

		//атрибут TestCase параметризует тест
		[TestCase("123", ExpectedResult = 123, TestName = "integer")]
		[TestCase("1.1", ExpectedResult = 1.1, TestName = "fraction")]
		[TestCase("1.1e1", ExpectedResult = 1.1e1, TestName = "scientific with positive exp")]
		[TestCase("1.1e-1", ExpectedResult = 1.1e-1, TestName = "scientific with negative exp")]
		[TestCase("-0.1", ExpectedResult = -0.1, TestName = "negative fraction")]
		//Но дату передать нельзя
		
		//Тестируем этот метод
		public double Parse_WithInvariantCulture(string input) //метод берет строку 
		{
			return double.Parse(input, CultureInfo.InvariantCulture); //и парсит как число double (с плавающей точкой)
		}

		//Т.к. дату передать нельзя используем другой подход "TestCaseSource"
		[Test, TestCaseSource(nameof(GerDayOfWeekTestCases))] //TestCaseSource принимает в качестве парметра 
															//метод из этого де класса, который генерирует кейсы
		public DayOfWeek DayOfWeek(DateTime dateTime)
		{
			return dateTime.DayOfWeek;
		}

		public static IEnumerable<TestCaseData> GerDayOfWeekTestCases() //метод генерирует кейсы
		{
			return new[]
			{												//по аналогии с TestCase
				new TestCaseData(new DateTime(2020, 05, 08)) //передаем дату
				.Returns(System.DayOfWeek.Friday) //возвращает пятницу
				.SetName("when 08.05.20 returns friday"), //утсанавливаем название

				new TestCaseData(new DateTime(2020, 05, 05))
				.Returns(System.DayOfWeek.Tuesday)
				.SetName("when 05.05.20 returns tuesday"),
			};
		}
	}
}