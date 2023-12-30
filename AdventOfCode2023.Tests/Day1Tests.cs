
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
		
		[TestMethod]
		public void TestDay1B()
		{
			// Arrange
			Day1B day1B = new Day1B();

			// Act
			string result = day1B.calculateTest();

			// Assert
			Assert.AreEqual("281", result);
		}
	}
}