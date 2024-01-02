namespace AOC2023
{
	using System.IO;

	public class Scratchcard
	{
		public int CardNumber { get; init; }
		public List<int> WinningNumbers { get; init; }
		public List<int> GivenNumbers { get; init; }
		public Scratchcard(int cardNumber, List<int> winningNumbers, List<int> givenNumbers)
		{
			CardNumber = cardNumber;
			WinningNumbers = winningNumbers;
			GivenNumbers = givenNumbers;
		}
		///<summary>
		///takes in a scratchard line in the format of
		/// "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"
		/// and returns a ScratchCard object.
		///</summary>
		public static Scratchcard ParseScratchcardLine(string scratchcardLine)
		{
			string[] sections = scratchcardLine.Split('|');

			// Parse card number (extract number after "Card ")
			int cardNumber = int.Parse(scratchcardLine.Split(':')[0].Split().Last());
			string winningSectionString = sections[0].Split(": ")[1];
			List<int> winningSection = Scratchcard.ParseSpaceSeparatedList(winningSectionString);
			List<int> givenSection = Scratchcard.ParseSpaceSeparatedList(sections[1]);
			return new (cardNumber, winningSection, givenSection);
		}

		private static List<int> ParseSpaceSeparatedList(string spaceDelineatedList)
		{
			List<int> numbers = spaceDelineatedList.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                         .Select(s =>
                         {
                             if (int.TryParse(s, out int result))
                                 return result;
                             else
                                 throw new FormatException($"Invalid number: {s}");
                         })
                         .ToList();
			return numbers;
		}
		public List<int> FindWinningNumbers()
		{
			return WinningNumbers.Intersect(GivenNumbers).ToList();
		}

		/// <summary>
		/// The score is 1 for the first winning number found, and is doubled 
		/// for each additional winning number found in the given numbers list.
		/// </summary>
		public int GetScore()
		{
			List<int> foundWinningNumbers = FindWinningNumbers();
			return foundWinningNumbers.Aggregate(0, (currentScore, number) => 
				{
					if(currentScore == 0)
					{
						return 1;
					}
					return currentScore * 2;
				}
			);
		}
	}
}