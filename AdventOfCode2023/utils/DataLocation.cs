namespace AOC2023
{
	/// <summary>
	/// Represents a data location in a 2 dimensional matrix with specific beginning and ending row and column indices.
	/// </summary>
	public class DataLocation
	{
	public int BeginRow { get; init; }
	public int BeginCol { get; init; }
	public int EndRow { get; init; }
	public int EndCol { get; init; }
	public string Value { get; private set; }
		public DataLocation(int beginRow, int beginCol, int endRow, int endCol, string value)
		{
			BeginRow = beginRow;
			BeginCol = beginCol;
			EndRow = endRow;
			EndCol = endCol;
			Value = value;
		}
	}

}
