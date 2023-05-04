namespace EisenhowerCore
{
	public class FileManager
	{
		private readonly List<string> _file = new();

		private bool VerifyEntry(string line)
		{
			string[] splitLine = line.Split('|');

			if (splitLine.Length != 3) return false;

			string date        = splitLine[1];
			string isImportant = splitLine[2];


			bool[] check = new bool[2];

			check[0] = DateTime.TryParse(date, out DateTime result);
			check[1] = isImportant is "true" or "false";

			bool verified = check.Any(item => !item);

			return !verified;
		}

		private string ParseToFile(TodoItem item) =>
			$"{item.GetName()}|{item.GetDate()}|{item.GetIsImportant()}";

		private string[] ParseFromFile(string line) => line.Split('|');

		public void ExportToFile(string fileName, TodoMatrix matrix)
		{
			string filePath = Directory.GetCurrentDirectory();

			using StreamWriter outputFile = new(Path.Combine(filePath, $"{fileName}.txt"));
			foreach (TodoItem item in matrix.GetAllItems()) outputFile.WriteLine(item);
		}

		private void ReadFile(string fileName)
		{
			try
			{
				StreamReader reader = new(fileName);
				string?      line   = reader.ReadLine();

				while (line != null)
				{
					if (VerifyEntry(line)) _file.Add(line);
					line = reader.ReadLine();
				}

				reader.Close();
			}
			catch (FileNotFoundException e) { Console.WriteLine($"Exception: {e.Message}"); }
		}

		public TodoMatrix ImportFromFile(string fileName)
		{
			TodoMatrix newMatrix = new();
			ReadFile(fileName);

			foreach (string item in _file)
			{
				string[] newTodo     = ParseFromFile(item);
				string   name        = newTodo[0];
				DateTime date        = DateTime.Parse(newTodo[1]);
				bool     isImportant = bool.Parse(newTodo[2]);
				newMatrix.CreateItem(name, date, isImportant);
			}

			return newMatrix;
		}
	}
}
