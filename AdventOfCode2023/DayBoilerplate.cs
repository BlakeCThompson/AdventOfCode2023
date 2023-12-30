
namespace AOC2023
{
	public abstract class DayBoilerPlate : DayInterface
	{
		public AdventOfCodeFileReader testPuzzleFileReader;
		public AdventOfCodeFileReader fullPuzzleFileReader;
		public DayBoilerPlate(string testPuzzleFileName, string fullPuzzleFileName)
		{
			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			testPuzzleFileName = AdventOfCodeFileReader.GetProjectDirectory() + testPuzzleFileName;
			fullPuzzleFileName = AdventOfCodeFileReader.GetProjectDirectory() + fullPuzzleFileName;
			this.testPuzzleFileReader = new AdventOfCodeFileReader(testPuzzleFileName);
			this.fullPuzzleFileReader = new AdventOfCodeFileReader(fullPuzzleFileName);
		}
		public abstract string calculateTest();
		public abstract string calculateFullPuzzle();
	}
}