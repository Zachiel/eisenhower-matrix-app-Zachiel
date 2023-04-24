namespace EisenhowerCore
{
	public class EisenhowerMain
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello Codecool!");
			FileManager file = new();
			file.ImportFromFile("NewFile1.txt");
			Console.ReadLine();
		}
	}
}
