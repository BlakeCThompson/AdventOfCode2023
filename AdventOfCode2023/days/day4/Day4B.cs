using System.Collections.Generic;
using System.Linq;
namespace AOC2023
{
	public class Day4B : DayBoilerPlate
	{
		private const string testFileName = "days/day4/test.txt";
		private const string fullPuzzleFileName = "days/day4/puzzleInput.txt";
		public Day4B() : base(testFileName, fullPuzzleFileName)
		{ }

		/// <summary>
		/// scratchcards only cause you to win more scratchcards equal to the number of winning numbers you have
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		public int getNumberOfCards(AdventOfCodeFileReader fr)
		{
			string? line = fr.GetLine();
			List<Scratchcard> scratchcards = new List<Scratchcard>();
			while (line != null)
			{
				scratchcards.Add(Scratchcard.ParseScratchcardLine(line));
				line = fr.GetLine();
			}
			// work backwards for easier calculation.
			scratchcards.Reverse();
			List<Scratchcard> copiesWon = new List<Scratchcard>();
			int scratchcardIndex = 0;
			int totalCardsWon = 0;
			foreach (Scratchcard card in scratchcards)
			{
				int matchesCount = card.FindWinningNumbers().Count;
				if (matchesCount != 0)
				{
					foreach (var n in Enumerable.Range(1, matchesCount))
					{
						Scratchcard cardWonByThisCard = scratchcards[scratchcardIndex - n];
						// add the new card to the NumberOfCopiesThisCardWins count, 
						// and the number of cards that card wins
						card.NumberOfCopiesThisCardWins += 1 + cardWonByThisCard.NumberOfCopiesThisCardWins;
					}
				}
				scratchcardIndex++;
				totalCardsWon += 1 + card.NumberOfCopiesThisCardWins;
			}
			return totalCardsWon;
		}

	

		public override string calculateTest()
		{
			int cards = getNumberOfCards(this.testPuzzleFileReader);
			return cards.ToString();
		}

		public override string calculateFullPuzzle()
		{
			int cards = getNumberOfCards(this.fullPuzzleFileReader);
			return cards.ToString();
		}
	}
}
