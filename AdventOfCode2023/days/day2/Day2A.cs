using System.Text.RegularExpressions;

namespace AOC2023
{
	public class Day2A : DayBoilerPlate
	{
		private const string testFileName = "days/day2/test.txt";
		private const string fullPuzzleFileName = "days/day2/puzzleInput.txt";
		public Day2A() : base(testFileName, fullPuzzleFileName)
		{
		}
		private int parseGameNumber(string gameLine)
		{
			Regex regex = new Regex (@"Game (\d+):");
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
		public List<string> getGameResults(string gameLine) {
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
		private bool gameIsPossible(string gameLine){
			return false;
		}
		private int getSumOfPossibleGames(AdventOfCodeFileReader fr)
		{
			string gameLine = fr.GetLine();
			int sumOfPossibleGames = 0;
			while(gameLine != null) {
				int gameNumber = this.parseGameNumber(gameLine);
				if (this.gameIsPossible(gameLine))
				{
					sumOfPossibleGames += this.parseGameNumber(gameLine);
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
			return "";
		}
	}
}