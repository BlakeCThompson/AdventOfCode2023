using System.Dynamic;
using System.Linq;
using System.Reflection.PortableExecutable;
namespace AOC2023
{
	public class Day1A : DayBoilerPlate
	{
		private const string testFileName = "days/day1/test.txt";
		private const string fullPuzzleFileName = "days/day1/puzzleInput.txt";
		public Day1A() : base(testFileName, fullPuzzleFileName)
		{
		}
		protected char GetFirstDigit(string line)
		{
			return line.FirstOrDefault(char.IsDigit, '0');
		}
		protected char GetLastDigit(string line)
		{
			return line.LastOrDefault(char.IsDigit, '0');
		}
		
		protected int GetLineValue(string line)
		{
			char firstDigit = this.GetFirstDigit(line);
			char lastDigit = this.GetLastDigit(line);
			string combinedDigits = String.Concat(firstDigit,lastDigit);
			return int.Parse(combinedDigits);
		}

		protected int getFileValue(AdventOfCodeFileReader fr)
		{
			string line = fr.GetLine();
			int totalValue = 0;
			while(line != null)
			{
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
