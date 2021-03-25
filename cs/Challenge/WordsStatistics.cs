using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge
{
	/**
	 * <summary>
	 * Частотный словарь добавленных слов. 
	 * Слова сравниваются без учета регистра символов. // GetStatistics_IgnoresCase() //готово
	 * Порядок — по убыванию частоты слова.
	 * При одинаковой частоте — в лексикографическом порядке.
	 * </summary>
	 */
	public class WordsStatistics : IWordsStatistics
	{
		protected readonly IDictionary<string, int> statistics 
			= new Dictionary<string, int>();

		public virtual void AddWord(string word)
		{
			if (word == null) throw new ArgumentNullException(nameof(word)); //если слов нет, выходит exception
			if (string.IsNullOrWhiteSpace(word)) return; //если строки пустые или состоят из пробелов, то мы слово игнорируем 
			//метод WordsStatisticsE противоречит этому
			
			if (word.Length > 10) //если слово состоит из более, чем 10 символов
				word = word.Substring(0, 10); //отрезать все после 10го знака
			int count;
			statistics[word.ToLower()] = 1 + (statistics.TryGetValue(word.ToLower(), out count) ? count : 0);
		}

		public virtual IEnumerable<WordCount> GetStatistics()
		{
			return statistics
				.Select(WordCount.Create)
				.OrderByDescending(wordCount => wordCount.Count)
				.ThenBy(wordCount => wordCount.Word);
		}
	}
}