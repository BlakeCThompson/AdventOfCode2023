using System.Collections.Generic;
using System.Linq;
namespace AOC2023
{
	public class Day3A : DayBoilerPlate
	{
		private const string testFileName = "days/day3/test.txt";
		private const string fullPuzzleFileName = "days/day3/puzzleInput.txt";
		public Day3A() : base(testFileName, fullPuzzleFileName)
		{}

		public static List<DataLocation> getNumberLocations(AdventOfCodeFileReader fr)
		{
			List<DataLocation> numbers = new List<DataLocation>();
			string line = "";
			int rowIndex = 0;
			while((line = fr.GetLine()) != null)
			{
				List<DataLocation> newNumbers = Day3A.ParseNumberDataLocationsFromLine(line, rowIndex);
				numbers = numbers.Concat(newNumbers).ToList();
				rowIndex++;
			}
			return numbers;
		}
		public static List<DataLocation> ParseNumberDataLocationsFromLine(string line, int row)
		{
			List<DataLocation> numbersInLine = new List<DataLocation>();
			int lineIndex = 0;
			while (lineIndex < line.Length)
			{
				int beginCol = lineIndex;
				int? endCol = null;
				string number = "";
				while (char.IsDigit(line[lineIndex]) && lineIndex < line.Length)
				{
					number += line[lineIndex];
					endCol = lineIndex;
					lineIndex++;
				}
				if (endCol.HasValue)
				{
					int realEndCol = endCol.Value;
					numbersInLine.Add(new DataLocation(row, beginCol, row, realEndCol, number));
				}
				lineIndex++;
			}
			return numbersInLine;
		}
		public override string calculateTest()
		{
			List<DataLocation> numbers = Day3A.getNumberLocations(this.testPuzzleFileReader);
			return "";
		}

		public override string calculateFullPuzzle()
		{
			return "";
		}
	}
}