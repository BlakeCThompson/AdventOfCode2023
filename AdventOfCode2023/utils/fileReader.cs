namespace AOC2023
{
	using System.IO;

	public class AdventOfCodeFileReader
	{
		private StreamReader streamReader;
		public AdventOfCodeFileReader(string fileName)
		{
			this.streamReader = new StreamReader(fileName);
		}

		public string? GetLine()
		{
			return this.streamReader.ReadLine();
		}
		~AdventOfCodeFileReader()
		{
			streamReader.Close();
		}

		public static string GetProjectDirectory()
		{
			return AppDomain.CurrentDomain.BaseDirectory + "../../../";
		}

		public void ResetStreamToBeginning()
		{
			this.streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
			this.streamReader.DiscardBufferedData();
		}

		// <summary>
		// PLEASE NOTE:
		// this function has a side effect of resetting the StreamReader's current index back to the beginning of the file.
		// </summary>
		// <returns> the file the local StreamReader points to represented as a two dimensional array of characters.</returns>
		public char[,] parseTwoDimensionalArray()
		{
			int rows = File.ReadAllLines(((FileStream)this.streamReader.BaseStream).Name).Length;
			int columns = this.getLongestLineLength();

			string line;
			int row = 0;
			char[,] charArray = new char[rows, columns];

			// Read lines and populate the 2D char array
			while ((line = this.streamReader.ReadLine()) != null)
			{
				for (int col = 0; col < columns; col++)
				{
					if (col < line.Length)
					{
						charArray[row, col] = line[col];
					}
					else
					{
						charArray[row, col] = '\0'; // Pad with null character if line is shorter
					}
				}
				row++;
			}

			return charArray;
		}

		// <summary>
		// PLEASE NOTE:
		// this function has a side effect of resetting the StreamReader's current index back to the beginning of the file.
		// </summary>
		// <returns>the number of characters in the longest line of the file.</returns>
		private int getLongestLineLength()
		{
			int longestLineLength = 0;
			string line = "";
			// Iterate through the file to find the maximum line length
			while ((line = this.streamReader.ReadLine()) != null)
			{
				if (line.Length > longestLineLength)
				{
					longestLineLength = line.Length;
				}
			}

			// Reset StreamReader to the beginning of the file
			this.streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
			this.streamReader.DiscardBufferedData();
			return longestLineLength;
		}
	}

}
