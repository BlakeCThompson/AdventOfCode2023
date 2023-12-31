using System.Text.RegularExpressions;

namespace AOC2023
{
	public class Day2A : DayBoilerPlate
	{
		private const string testFileName = "days/day2/test.txt";
		private const string fullPuzzleFileName = "days/day2/puzzleInput.txt";

		private Dictionary<string, int> actualNumbers = new Dictionary<string, int>
		{
			{"red", 12}, {"green", 13}, {"blue", 14}
		};
		public Day2A() : base(testFileName, fullPuzzleFileName)
		{
		}
		protected static int ParseGameNumber(string gameLine)
		{
			Regex regex = new Regex(@"Game (\d+):");
			Match match = regex.Match(gameLine);
			if (match.Success)
			{
				return int.Parse(match.Groups[1].Value);
			}
			throw new Exception("game number could not be parsed!");
		}

		/// <summary>
		/// This method parses a game line in the following format:
		/// Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
		/// which is a game identifier, followed by an arbitrary non-zero number of game results.
		/// It returns a list of the game results.
		/// In the example string, this would be
		/// [
		///		"3 blue, 4 red"
		///		"1 red, 2 green, 6 blue"
		///		"2 green"
		///	]
		/// </summary>
		/// <param name="gameLine">The gameLine, which is assumed to take the format described in the summary.</param>
		/// <returns>The sum of the two integers.</returns>
		public static List<string> getGameResultStrings(string gameLine)
		{
			List<string> resultList = new List<string>();

			// Find the index of ":" symbol in the input string
			int colonIndex = gameLine.IndexOf(':');

			if (colonIndex != -1)
			{
				// Get the substring after the ":" symbol
				string substringAfterColon = gameLine.Substring(colonIndex + 1);

				// Split the substring by semicolon and trim each part
				string[] parts = substringAfterColon.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(part => part.Trim())
					.ToArray();

				// Add the trimmed parts to the result list
				resultList.AddRange(parts);
			}

			return resultList;
		}

	public static Dictionary<string, int> ParseNumberColorPairs(string gameScenarioString)
	{
		Dictionary<string, int> numberColorPairs = new Dictionary<string, int>();

		// Splitting the gameScenarioString string by comma and trimming whitespace
		string[] pairs = gameScenarioString.Split(',')
							.Select(pair => pair.Trim())
							.ToArray();

		foreach (var pair in pairs)
		{
			// Splitting each pair into number and color
			string[] parts = pair.Split(' ');

			if (parts.Length == 2 && int.TryParse(parts[0], out int number))
			{
				string color = parts[1];

				// Adding color-number pairs to the dictionary
				numberColorPairs[color] = number;
			}
			else
			{
				// Handle invalid gameScenarioString format
				throw new FormatException("Invalid gameScenarioString format for number-color pair.");
			}
		}

		return numberColorPairs;
	}

	public static List<Dictionary<string, int>> GetGameResults(string gameLine)
	{
		List<string> gameResultStrings = Day2A.getGameResultStrings(gameLine);
        List<Dictionary<string, int>> gameResultDict = new List<Dictionary<string, int>>();
		foreach (string gameResultString in gameResultStrings)
		{
			gameResultDict.Add(Day2A.ParseNumberColorPairs(gameResultString));
		}
		return gameResultDict;
	}

		/// <summary>
		/// Checks the possibility of a game based on the number of colors drawn and the actual count of each color.
		/// </summary>
		/// <param name="numberOfColorsDrawn">A dictionary representing the expected count of each color drawn in the game.</param>
		/// <param name="actualNumberOfEachColor">A dictionary representing the actual count of each color available in the game.</param>
		/// <returns>
		/// Returns 'true' if the game is possible based on the comparison of the expected count of colors drawn
		/// with the actual count of each color available; otherwise, returns 'false'.
		/// </returns>
		/// <exception cref="ArgumentException">
		/// Thrown when a color key in 'numberOfColorsDrawn' is not found in 'actualNumberOfEachColor'.
		/// </exception>
		public bool gameScenarioIsPossible(Dictionary<string, int> numberOfColorsDrawn)
		{
			foreach (var kvp in numberOfColorsDrawn)
			{
				if (!this.actualNumbers.ContainsKey(kvp.Key))
				{
					throw new ArgumentException($"Key '{kvp.Key}' does not exist in the description of the actual numbers of each color available.");
				}

				if (kvp.Value > this.actualNumbers[kvp.Key])
				{
					return false;
				}
			}
			return true;
		}

		public bool gameIsPossible(List<Dictionary<string, int>> gameResults)
		{
			foreach (var gameScenario in gameResults)
			{
				if (!this.gameScenarioIsPossible(gameScenario))
				{
					return false;
				}
			}
			return true;
		}

		private int getSumOfPossibleGames(AdventOfCodeFileReader fr)
		{
			string gameLine = fr.GetLine();
			int sumOfPossibleGames = 0;
			while (gameLine != null)
			{
				List<Dictionary<string, int>> gameResults = Day2A.GetGameResults(gameLine);
				if (this.gameIsPossible(gameResults))
				{
					sumOfPossibleGames += Day2A.ParseGameNumber(gameLine);
				}
				gameLine = fr.GetLine();
			}
			return sumOfPossibleGames;
		}

		public override string calculateTest()
		{
			return this.getSumOfPossibleGames(this.testPuzzleFileReader).ToString();
		}

		public override string calculateFullPuzzle()
		{
			return this.getSumOfPossibleGames(this.fullPuzzleFileReader).ToString();
		}
	}
}