
namespace AOC2023.Tests
{
	[TestClass]
	public class Day2Tests
	{
		[TestMethod]
		public void TestDay2AGetGameResultsParsesResultsCorrectly()
		{
			// Arrange
			Day2A day2A = new Day2A();

			// Act
			List<string> results = Day2A.getGameResultStrings("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

			// Assert
			Assert.AreEqual(3, results.Count);
			Assert.AreEqual("3 blue, 4 red", results[0]);
			Assert.AreEqual("1 red, 2 green, 6 blue", results[1]);
			Assert.AreEqual("2 green", results[2]);
		}
		
		[TestMethod]
		public void TestDay2AParseNumberColorPairs()
		{
			string gameScenario = "1 red, 2 green, 6 blue";
			Dictionary<string, int> gameScenarioDict = Day2A.ParseNumberColorPairs(gameScenario);

			Assert.AreEqual(3, gameScenarioDict.Count);
			Assert.AreEqual(1, gameScenarioDict["red"]);
			Assert.AreEqual(2, gameScenarioDict["green"]);
			Assert.AreEqual(6, gameScenarioDict["blue"]);
		}

		[TestMethod]
		public void TestDay2ACalculateIfScenarioIsPossible()
		{
			// Arrange
			// List of dictionaries initialization
			Dictionary<string, int> possibleNumberOfColorsDrawnInGame1 = new Dictionary<string, int>
			{
				{"blue", 3}, {"red", 4}
			};

			Dictionary<string, int> possibleNumberOfColorsDrawnInGame2 = new Dictionary<string, int>
			{
				{"red", 1}, {"green", 2}, {"blue", 6}
			};

			Dictionary<string, int> possibleNumberOfColorsDrawnInGame3 = new Dictionary<string, int>
			{
				{"green", 2}
			};

			Dictionary<string, int> impossibleNumberOfColorsDrawnInGame1 = new Dictionary<string, int>
			{
				{"green", 5}, {"blue", 16}, {"red", 5}
			};


			Day2A day2A = new Day2A();

			// Act
			// Assert
			Assert.IsTrue(day2A.gameScenarioIsPossible(possibleNumberOfColorsDrawnInGame1));
			Assert.IsTrue(day2A.gameScenarioIsPossible(possibleNumberOfColorsDrawnInGame2));
			Assert.IsTrue(day2A.gameScenarioIsPossible(possibleNumberOfColorsDrawnInGame3));
			Assert.IsTrue(day2A.gameScenarioIsPossible(possibleNumberOfColorsDrawnInGame1));
		}

		[TestMethod]
		public void TestDay2ACalculatesImpossibleGame()
		{
			List<Dictionary<string, int>> impossibleGame = new List<Dictionary<string, int>>
			{
				new Dictionary<string, int>
				{
					{"blue", 3}, {"red", 4}
				},
				new Dictionary<string, int>
				{
					{"red", 1}, {"green", 2}, {"blue", 6}
				},
				new Dictionary<string, int>
				{
					{"green", 2}
				},
				new Dictionary<string, int>
				{
					{"green", 5}, {"blue", 16}, {"red", 5}
				}
			};
			Day2A day2A = new Day2A();
			Assert.IsFalse(day2A.gameIsPossible(impossibleGame));
		}

		[TestMethod]
		public void TestDay2ACalculatesPossibleGame()
		{
			Dictionary<string, int> actualNumbersOfEachColor = new Dictionary<string, int>
			{
				{"red", 12}, {"green", 13}, {"blue", 14}
			};
			List<Dictionary<string, int>> impossibleGame = new List<Dictionary<string, int>>
			{
				new Dictionary<string, int>
				{
					{"blue", 3}, {"red", 4}
				},
				new Dictionary<string, int>
				{
					{"red", 1}, {"green", 13}, {"blue", 6}
				},
				new Dictionary<string, int>
				{
					{"green", 2}
				},
				new Dictionary<string, int>
				{
					{"green", 5}, {"blue", 13}, {"red", 5}
				}
			};
			Day2A day2A = new Day2A();
			Assert.IsTrue(day2A.gameIsPossible(impossibleGame));
		}

		[TestMethod]
		public void TestDay2ACalculatesSumOfIndexesOfPossibleGames()
		{
			
			Day2A day2A = new Day2A();
			Assert.AreEqual("8", day2A.calculateTest());
		}

		[TestMethod]
		public void TestDay2BCalculatesMinimumNumberOfColors()
		{
			string gameString = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

			List<Dictionary<string, int>> gameResultSet = Day2B.GetGameResults(gameString);
			Dictionary<string, int> minimumNumberOfColorsRequiredForGame = Day2B.GetMinimumNumberOfColorsRequired(gameResultSet);
			Assert.AreEqual(4, minimumNumberOfColorsRequiredForGame["red"]);
			Assert.AreEqual(2, minimumNumberOfColorsRequiredForGame["green"]);
			Assert.AreEqual(6, minimumNumberOfColorsRequiredForGame["blue"]);
		}

		[TestMethod]
		public void TestDay2BCalculatesProductOfColors()
		{
			string gameString = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

			List<Dictionary<string, int>> gameResultSet = Day2B.GetGameResults(gameString);
			Assert.AreEqual(48, Day2B.calculateProductOfColorNumbers(gameResultSet));
		}
	}
}