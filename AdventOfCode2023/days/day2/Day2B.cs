using System.Text.RegularExpressions;

namespace AOC2023
{
	public class Day2B : Day2A
	{
		public static Dictionary<string, int> GetMinimumNumberOfColorsRequired(List<Dictionary<string, int>> gameResultList)
		{
			Dictionary<string, int> minimumNumberOfEachColor = new Dictionary<string, int>();
			// gameResultSet takes format of something like 4 red, 3 blue; 6 blue, 16 green; 9 blue, 13 green, 1 red; 10 green, 4 red, 6 blue
			// these are separated by ;, so one gameResult might be 4 red, 3 blue.
			foreach(Dictionary<string, int> gameResult in gameResultList)
			{
				Dictionary<string, int> thisGameResultsMinimumNumbers = Day2B.GetMinimumNumberOfColorsRequiredHelper(gameResult);
				foreach(var colorNumberPair in thisGameResultsMinimumNumbers)
				{
					if (!minimumNumberOfEachColor.ContainsKey(colorNumberPair.Key) || minimumNumberOfEachColor[colorNumberPair.Key] < colorNumberPair.Value)
					{
						minimumNumberOfEachColor[colorNumberPair.Key] = colorNumberPair.Value;
					}
				}
			}
			return minimumNumberOfEachColor;
		}

		public static Dictionary<string, int> GetMinimumNumberOfColorsRequiredHelper(Dictionary<string, int> gameResultScenario)
		{
			Dictionary<string, int> minimumNumberOfColorsRequired = new Dictionary<string, int>();
			foreach(var gameResult in gameResultScenario)
			{
				if (!minimumNumberOfColorsRequired.ContainsKey(gameResult.Key) || minimumNumberOfColorsRequired[gameResult.Key] < gameResult.Value)
				{
					minimumNumberOfColorsRequired[gameResult.Key] = gameResult.Value;
				}
			}
			return minimumNumberOfColorsRequired;
		}

		public static int calculateProductOfColorNumbers(List<Dictionary<string, int>> gameResultList)
		{
			Dictionary<string, int> minimumNumberOfEachColorRequiredForGame = Day2B.GetMinimumNumberOfColorsRequired(gameResultList);
			int product = 1;
			foreach (var colorNumberPair in minimumNumberOfEachColorRequiredForGame)
			{
				product *= colorNumberPair.Value;
			}
			return product;
		}

		// What is the fewest number of cubes of each color that could have been in the bag to make the game possible?
		// The power of a set of cubes is equal to the numbers of red, green, and blue cubes multiplied together.
		public static int calculateSumOfPowers(AdventOfCodeFileReader fr)
		{
			string gameLine = fr.GetLine();
			int sumOfProducts = 0;
			while (gameLine != null)
			{
				List<Dictionary<string, int>> gameResults = Day2A.GetGameResults(gameLine);
				sumOfProducts += calculateProductOfColorNumbers(gameResults);
				gameLine = fr.GetLine();
			}
			return sumOfProducts;
		}

		public override string calculateTest()
		{
			return Day2B.calculateSumOfPowers(this.testPuzzleFileReader).ToString();
		}

		public override string calculateFullPuzzle()
		{
			return Day2B.calculateSumOfPowers(this.fullPuzzleFileReader).ToString();
		}
	}
}