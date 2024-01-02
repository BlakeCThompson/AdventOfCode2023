
namespace AOC2023.Tests
{
	[TestClass]
	public class Day3Tests
	{
		[TestMethod]
		public void TestDay3AGetNumbersInLine()
		{
			string line = "467..114..";
			List<DataLocation> numbers = Day3A.ParseDataLocationsFromLine(line, 0, (c)=>char.IsDigit(c));
			Assert.AreEqual("467", numbers[0].Value);
			Assert.AreEqual("114", numbers[1].Value);
			Assert.AreEqual(0, numbers[0].BeginCol);
			Assert.AreEqual(5, numbers[1].BeginCol);
			Assert.AreEqual(2, numbers[0].EndCol);
			Assert.AreEqual(7, numbers[1].EndCol);
			Assert.AreEqual(0, numbers[0].Row);
			Assert.AreEqual(0, numbers[1].Row);
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
			List<DataLocation> numbers = Day3A.GetDataLocations(aOCFR, (c)=>char.IsDigit(c));
			Assert.AreEqual(10, numbers.Count);
			Assert.AreEqual("467", numbers[0].Value);
			Assert.AreEqual(0, numbers[0].BeginCol);
			Assert.AreEqual(2, numbers[2].BeginCol);
			Assert.AreEqual(2, numbers[2].Row);
			Assert.AreEqual("598", numbers[9].Value);
		}

		[TestMethod]
		public void TestDay3AGetSymbolLocations()
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
			List<DataLocation> symbols = Day3A.GetDataLocations(aOCFR, (c)=>!char.IsLetterOrDigit(c) && c != '.');
			Assert.AreEqual(6, symbols.Count);
			Assert.AreEqual("*", symbols[0].Value);
			Assert.AreEqual(3, symbols[0].BeginCol);
			Assert.AreEqual("#", symbols[1].Value);
		}

		[TestMethod]
		public void TestDay3AGetNumbersAdjacentToSymbols()
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
			List<DataLocation> numbers =  Day3A.GetDataLocations(aOCFR, (c)=>!char.IsDigit(c));
			List<DataLocation> symbols = Day3A.GetDataLocations(aOCFR, (c)=>!char.IsLetterOrDigit(c) && c != '.');
			HashSet<DataLocation> numbersAdjacentToSymbols = Day3A.GetAdjacent(numbers, symbols);
			Assert.AreEqual(8, numbersAdjacentToSymbols.Count);
		}
	}
}