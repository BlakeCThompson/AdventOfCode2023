
namespace AOC2023.Tests
{
	[TestClass]
	public class AdventOfCodeFileReaderTests
	{
		[TestMethod]
		public void TestDay1A()
		{
			string fileName = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory + "../../../testData/twoDimensionalArray1.txt");
			AdventOfCodeFileReader aOCFR= new AdventOfCodeFileReader(fileName);
			char[,] twoDimensionalArray = aOCFR.parseTwoDimensionalArray();
			char[,] comparableTwoDimensionalArray = {{'1','2','3'},{'4','5','6'},{'7','8','9'}};
			CollectionAssert.AreEqual(comparableTwoDimensionalArray, twoDimensionalArray);
		}
	}
}