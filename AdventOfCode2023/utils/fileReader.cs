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

	}

}
