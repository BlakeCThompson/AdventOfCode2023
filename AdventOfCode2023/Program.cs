// See https://aka.ms/new-console-template for more information
using AOC2023;
Console.WriteLine("what day are you on?");
string day = Console.ReadLine() ?? "";
Console.WriteLine("working on day " + day);
string className = "AOC2023.Day" + day + "A";
Type dayType = Type.GetType(className);

if (dayType != null) {
	DayInterface dayInstance = (DayInterface)Activator.CreateInstance(dayType);
	Console.WriteLine("test solution part A:" + dayInstance.calculateTest());
	Console.WriteLine("real solution part A:" + dayInstance.calculateFullPuzzle());
}

className = "AOC2023.Day" + day + "B";

dayType = Type.GetType(className);
if (dayType != null) {
	DayInterface dayInstanceB = (DayInterface)Activator.CreateInstance(dayType);
	Console.WriteLine("test solution part B:" + dayInstanceB.calculateTest());
	Console.WriteLine("real solution part B:" + dayInstanceB.calculateFullPuzzle());
}