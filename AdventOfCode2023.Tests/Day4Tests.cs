
namespace AOC2023.Tests
{
	[TestClass]
	public class Day4Tests
	{

		[TestMethod]
		public void TestDay4BGetNumberOfCards()
		{
			Day4B day4B = new Day4B();
			Assert.AreEqual(day4B.calculateTest(), "30");
		}
	}
}