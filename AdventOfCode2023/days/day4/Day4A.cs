using System.Collections.Generic;
using System.Linq;
namespace AOC2023
{
	public class Day4A : DayBoilerPlate
	{
		private const string testFileName = "days/day4/test.txt";
		private const string fullPuzzleFileName = "days/day4/puzzleInput.txt";
		public Day4A() : base(testFileName, fullPuzzleFileName)
		{ }

		public int GetScoreFromCardFile(AdventOfCodeFileReader fr)
		{
			string? line = fr.GetLine();;
			List<Scratchcard> scratchcards = new List<Scratchcard>();
			while (line != null)
			{
				scratchcards.Add(Scratchcard.ParseScratchcardLine(line));
				line = fr.GetLine();
			}
			int score = 0;
			foreach (var scratchcard in scratchcards)
			{
				score += scratchcard.GetScore();
			}
			return score;
		}

		public override string calculateTest()
		{
			int score = GetScoreFromCardFile(this.testPuzzleFileReader);
			return score.ToString();
		}

		public override string calculateFullPuzzle()
		{
			int score = GetScoreFromCardFile(this.fullPuzzleFileReader);
			return score.ToString();
		}
	}
}
