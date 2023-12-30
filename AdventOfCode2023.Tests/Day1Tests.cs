
namespace AOC2023.Tests
{
	[TestClass]
	public class Day1Tests
	{
		[TestMethod]
		public void TestDay1A()
		{
			// Arrange
			Day1A day1A = new Day1A();

			// Act
			string result = day1A.calculateTest();

			// Assert
			Assert.AreEqual("142", result);
		}
	}
}