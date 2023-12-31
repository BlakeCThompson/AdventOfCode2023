
namespace AOC2023.Tests
{
	[TestClass]
	public class Day2Tests
	{
		[TestMethod]
		public void TestDay2A()
		{
			// Arrange
			Day2A day2A = new Day2A();

			// Act
			List<string> results = day2A.getGameResults("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

			// Assert
			Assert.AreEqual(3, results.Count);
			Assert.AreEqual("3 blue, 4 red", results[0]);
			Assert.AreEqual("1 red, 2 green, 6 blue", results[1]);
			Assert.AreEqual("2 green", results[2]);
		}
		
		[TestMethod]
		public void TestDay2B()
		{
			// // Arrange
			// Day1B day1B = new Day1B();

			// // Act
			// string result = day1B.calculateTest();

			// // Assert
			// Assert.AreEqual("281", result);
		}
	}
}