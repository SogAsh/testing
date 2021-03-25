using System.Collections.Generic;

namespace Challenge
{
	public interface IWordsStatistics
	{
		void AddWord(string word);
		IEnumerable <WordCount> GetStatistics();

		//https://refactoring.guru/ru/design-patterns/iterator
	}
}