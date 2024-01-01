
namespace AOC2023.Tests
{
	[TestClass]
	public class Day3Tests
	{
		[TestMethod]
		public void TestDay3AGetNumbersInLine()
		{
			string line = "467..114..";
			List<DataLocation> numbers = Day3A.ParseNumberDataLocationsFromLine(line, 0);
			Assert.AreEqual("467", numbers[0].Value);
			Assert.AreEqual("114", numbers[1].Value);
			Assert.AreEqual(0, numbers[0].BeginCol);
			Assert.AreEqual(5, numbers[1].BeginCol);
			Assert.AreEqual(2, numbers[0].EndCol);
			Assert.AreEqual(7, numbers[1].EndCol);
			Assert.AreEqual(0, numbers[0].BeginRow);
			Assert.AreEqual(0, numbers[1].BeginRow);
			Assert.AreEqual(0, numbers[0].EndRow);
			Assert.AreEqual(0, numbers[1].EndRow);
		}


		[TestMethod]
		public void TestDay3AGetNumbersFromEntireFile()
		{
			/*
			test.txt:
467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..
			*/
			string fileName = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory + "../../../days/day3/test.txt");
			AdventOfCodeFileReader aOCFR= new AdventOfCodeFileReader(fileName);
			List<DataLocation> numbers = Day3A.getNumberLocations(aOCFR);
			Assert.AreEqual(10, numbers.Count);
			Assert.AreEqual("467", numbers[0].Value);
			Assert.AreEqual("598", numbers[9].Value);
		}
	}
}