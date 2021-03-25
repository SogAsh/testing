using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Challenge
{
	[TestFixture]
	public class WordsStatistics_Tests
	{
		public virtual IWordsStatistics CreateStatistics()
		{
			// меняется на разные реализации при запуске exe
			return new WordsStatistics();
		}

		private IWordsStatistics wordsStatistics;

		[SetUp]
		public void SetUp()
		{
			wordsStatistics = CreateStatistics();
		}

		// Тесты для правльной реализации //Все учтены - все ок
		[Test]
		public void GetStatistics_IsEmpty_AfterCreation() 
		{
			wordsStatistics.GetStatistics().Should().BeEmpty();
		}

		[Test]
		public void GetStatistics_ContainsItem_AfterAddition()
		{
			wordsStatistics.AddWord("abc");
			wordsStatistics.GetStatistics().Should().Equal(new WordCount("abc", 1));
		}

		[Test]
		public void GetStatistics_ContainsManyItems_AfterAdditionOfDifferentWords()
		{
			wordsStatistics.AddWord("abc");
			wordsStatistics.AddWord("def");
			wordsStatistics.GetStatistics().Should().HaveCount(2);
		}

		// Тесты для неправльной реализации //Учтены 2

		[Test]
		public void GetStatistics_IgnoresCase() //Слова сравниваются без учета регистра символов. //метод WordsStatisticsC
		{
			wordsStatistics.AddWord("abc");
			wordsStatistics.AddWord("ABC");
			wordsStatistics.GetStatistics().Should().HaveCount(1);
		}

		[Test]
		public void AddWord_IgnoreEmptyWord() //Проверяем "if (string.IsNullOrWhiteSpace(word))"
		{
			wordsStatistics.AddWord("");
			wordsStatistics.GetStatistics().Should().HaveCount(0);
		}

		[Test]
		public void AddWord_WhiteSpace() //Проверяем пробелы
		{
			wordsStatistics.AddWord(" ");
			wordsStatistics.GetStatistics().Should().HaveCount(0);
		}

		[Test]
		public void AddWord_IfWordGreaterThan10_CutWords()//проверка на ограничение пожстроки
		{
			var word = "abcdefjhigkl";
			wordsStatistics.AddWord(word);
			wordsStatistics.GetStatistics().OrderByDescending(wordCount => wordCount.Count);
			//Assert.That(word.Length, Is.EqualTo(10));
		}

		[Test]
		public void GetStatistics_ThrowArgumentException_IfNull_() //тест зеленый 2 р
		{
			Assert.Throws<ArgumentNullException>(() => wordsStatistics.AddWord(null));
		}


	}
}