using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
namespace AOC2023
{
	public class Day1B : DayBoilerPlate
	{
		private const string testFileName = "days/day1/test2.txt";
		private const string fullPuzzleFileName = "days/day1/puzzleInput.txt";
		private List<int> lineValues = new List<int>();
		public Day1B() : base(testFileName, fullPuzzleFileName)
		{
		}
		private static Dictionary<string, int> wordDigitValues = new Dictionary<string, int>
		{
			{"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4},
			{"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9},
			{"0", 0}, {"1", 1}, {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6},
			{"7", 7}, {"8", 8}, {"9", 9}
		};
		protected char GetFirstDigit(string line)
		{
			Regex combinedRegex = new Regex(@"(?:\d|(?:zero|one|two|three|four|five|six|seven|eight|nine))", RegexOptions.IgnoreCase);
			Match match = combinedRegex.Match(line);
			return (char)(Day1B.wordDigitValues[match.Value] + '0');
		}
		protected char GetLastDigit(string line)
		{
			Regex combinedRegex = new Regex(@"(?:\d|(?:zero|one|two|three|four|five|six|seven|eight|nine))", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
			Match match = combinedRegex.Match(line);
			return (char)(Day1B.wordDigitValues[match.Value] + '0');
		}
		
		protected int GetLineValue(string line)
		{
			char firstDigit = this.GetFirstDigit(line);
			char lastDigit = this.GetLastDigit(line);
			string combinedDigits = String.Concat(firstDigit,lastDigit);
			int lineValue = int.Parse(combinedDigits);
			this.lineValues.Add(lineValue);
			return int.Parse(combinedDigits);
		}

		protected int getFileValue(AdventOfCodeFileReader fr)
		{
			this.lineValues.Clear();
			string line = fr.GetLine();
			int totalValue = 0;
			string oldLine = "";
			while(line != null)
			{
				oldLine = line;
				int lineValue = this.GetLineValue(line);
				totalValue += lineValue;
				line = fr.GetLine();
			}
			return totalValue;
		}

		public override string calculateTest()
		{
			return this.getFileValue(this.testPuzzleFileReader).ToString();
		}

		public override string calculateFullPuzzle()
		{
			return this.getFileValue(this.fullPuzzleFileReader).ToString();
		}
	}
}
