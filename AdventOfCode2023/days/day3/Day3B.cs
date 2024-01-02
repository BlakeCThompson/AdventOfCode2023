using System.Collections.Generic;
using System.Linq;
namespace AOC2023
{
	public class Day3B : Day3A
	{
		public static string CalculateSumOfGearRatios(AdventOfCodeFileReader fr)
		{
			List<DataLocation> numbers =  Day3A.GetDataLocations(fr, (c)=>char.IsDigit(c));
			List<DataLocation> stars = Day3A.GetDataLocations(fr, (c)=> c == '*');
			int sum = 0;
			foreach(var star in stars)
			{
				List<DataLocation> tempStars = new List<DataLocation>{star};
				HashSet<DataLocation> adjacentNumbers = Day3B.GetAdjacent(tempStars, numbers);
				if (adjacentNumbers.Count == 2)
				{
					int firstElement = int.Parse(adjacentNumbers.ElementAtOrDefault(0).Value); // Get the first element
					int secondElement = int.Parse(adjacentNumbers.Skip(1).FirstOrDefault().Value); // Get the second element by skipping the first
					int product = firstElement * secondElement;
					sum += product;
				}
			}
			
			return sum.ToString();
		}
		public override string calculateTest()
		{
			return Day3B.CalculateSumOfGearRatios(this.testPuzzleFileReader);
		}

		public override string calculateFullPuzzle()
		{
			return Day3B.CalculateSumOfGearRatios(this.fullPuzzleFileReader);
		}
	}
}