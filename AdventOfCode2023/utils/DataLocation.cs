namespace AOC2023
{
	/// <summary>
	/// Represents a horizontal data location in a given row in a 2 dimensional matrix with specific beginning end and column indices.
	/// </summary>
	public class DataLocation
	{
	public int Row { get; init; }
	public int BeginCol { get; init; }
	public int EndCol { get; init; }
	public string Value { get; private set; }
		public DataLocation(int row, int beginCol, int endCol, string value)
		{
			Row = row;
			BeginCol = beginCol;
			EndCol = endCol;
			Value = value;
		}

		public override bool Equals(object obj)
		{
			if (obj is DataLocation other)
			{
				return other.Row == Row && other.Value == Value && other.BeginCol == BeginCol && other.EndCol == EndCol;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Row.GetHashCode() ^ BeginCol.GetHashCode() ^ EndCol.GetHashCode() ^ Value.GetHashCode();
		}
		public bool IsAdjacent(DataLocation otherDataLocation)
		{
			if (Math.Abs(otherDataLocation.Row - Row) > 1)
			{
				//these exist on rows that are more than 1 apart.
				return false;
			}
			// Check if the ranges are adjacent or intersect
			bool isAdjacentOrIntersect = 
				Math.Abs(BeginCol - otherDataLocation.EndCol) <= 1 ||   // Check if line2 ends within 1 index of line1 begins
				Math.Abs(otherDataLocation.BeginCol - EndCol) <= 1 ||   // Check if line1 ends within 1 index of line2 begins
				(BeginCol <= otherDataLocation.BeginCol && EndCol >= otherDataLocation.EndCol) ||  // Check if line2 begins within line1
				(otherDataLocation.BeginCol <= BeginCol && otherDataLocation.EndCol >= BeginCol);	// Check if line1 begins within line2

			return isAdjacentOrIntersect;
		}
	}

}
