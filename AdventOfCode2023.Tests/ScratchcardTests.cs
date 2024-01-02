
namespace AOC2023.Tests
{
	[TestClass]
	public class ScratchCardTests
	{
		[TestMethod]
		public void TestParseScratchCard()
		{
			string scratchcardLine = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
			Scratchcard scratchcard = Scratchcard.ParseScratchcardLine(scratchcardLine);
			Assert.AreEqual(scratchcard.CardNumber, 1);
			List<int> winningNumbers = new List<int>{41, 48, 83, 86, 17};
			List<int> givenNumbers = new List<int>{83, 86, 6, 31, 17, 9, 48, 53};
			CollectionAssert.AreEqual(winningNumbers, scratchcard.WinningNumbers);
			CollectionAssert.AreEqual(givenNumbers, scratchcard.GivenNumbers);
		}
		[TestMethod]
		public void TestGetWinningNumbersInGivenLine()
		{
			string scratchcardLine = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
			Scratchcard scratchcard = Scratchcard.ParseScratchcardLine(scratchcardLine);
			List<int> foundWinningNumbers = scratchcard.FindWinningNumbers();
			List<int> shouldBeThis = new List<int>{48,83,86,17};
			CollectionAssert.AreEqual(foundWinningNumbers, shouldBeThis);
		}

		[TestMethod]
		public void TestGetCardScore()
		{
			string scratchcardLine = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
			Scratchcard scratchcard = Scratchcard.ParseScratchcardLine(scratchcardLine);
			int cardScore = scratchcard.GetScore();
			Assert.AreEqual(8, cardScore);
		}

		[TestMethod]
		public void TestGetCardScoreWhenNoWinningAreFound()
		{
			string scratchcardLine = "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";
			Scratchcard scratchcard = Scratchcard.ParseScratchcardLine(scratchcardLine);
			int cardScore = scratchcard.GetScore();
			Assert.AreEqual(0, cardScore);
		}
	}
}