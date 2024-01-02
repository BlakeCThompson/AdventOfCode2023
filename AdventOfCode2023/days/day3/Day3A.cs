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

		public static List<DataLocation> GetDataLocations(AdventOfCodeFileReader fr, Func<char, bool> comparator)
		{
			List<DataLocation> dataLocations = new List<DataLocation>();
			string line = "";
			int rowIndex = 0;
			while((line = fr.GetLine()) != null)
			{
				List<DataLocation> newDataLocations = Day3A.ParseDataLocationsFromLine(line, rowIndex, comparator);
				dataLocations = dataLocations.Concat(newDataLocations).ToList();
				rowIndex++;
			}
			return dataLocations;
		}
		/// <summary>
		/// searches a string and returns a DataLocation signalling where substrings matching a comparator function
		/// </summary>
		public static List<DataLocation> ParseDataLocationsFromLine(string line, int row, Func<char, bool> comparator)
		{
			List<DataLocation> numbersInLine = new List<DataLocation>();
			int lineIndex = 0;
			while (lineIndex < line.Length)
			{
				int beginCol = lineIndex;
				int? endCol = null;
				string number = "";
				while (lineIndex < line.Length && comparator(line[lineIndex]))
				{
					number += line[lineIndex];
					endCol = lineIndex;
					lineIndex++;
				}
				if (endCol.HasValue)
				{
					int realEndCol = endCol.Value;
					numbersInLine.Add(new DataLocation(row, beginCol, realEndCol, number));
				}
				lineIndex++;
			}
			return numbersInLine;
		}
	/// <summary>
	/// take a list of DataLocations, and compare it with a second list of data locations to find any in the second list that may be adjacent to the first.
	/// </summary>
		public static HashSet<DataLocation> GetAdjacent(List<DataLocation> targetLocations, List<DataLocation> possiblyAdjacentLocations)
		{
			HashSet<DataLocation> locationsAdjacentToTargets = new HashSet<DataLocation>();
			foreach (DataLocation possiblyAdjacentLocation in possiblyAdjacentLocations)
			{
				foreach(DataLocation targetLocation in targetLocations)
				{
					if(targetLocation.IsAdjacent(possiblyAdjacentLocation))
					{
						locationsAdjacentToTargets.Add(possiblyAdjacentLocation);
					}
				}
			}
			return locationsAdjacentToTargets;
		}



		public override string calculateTest()
		{
			List<DataLocation> numbers = Day3A.GetDataLocations(this.testPuzzleFileReader, (c)=>char.IsDigit(c));
			return "";
		}

		public override string calculateFullPuzzle()
		{
			return "";
		}
	}
}