namespace EisenhowerCore
{
	public class Display
	{
		private List<string> Lines(TodoQuarter urgent, TodoQuarter notUrgent, int lineWidth = 37)
		{
			List<string> lines = new();

			List<TodoItem> urgentItems    = urgent.GetAssignedItems();
			List<TodoItem> notUrgentItems = notUrgent.GetAssignedItems();

			int urgentCounter    = urgentItems.Count();
			int notUrgentCounter = notUrgentItems.Count();
			int max;
			if (urgentCounter < 13
				&& notUrgentCounter < 13)
				max = 13;
			else if (urgentCounter > notUrgentCounter)
				max = urgentCounter - 1;
			else
				max = notUrgentCounter - 1;

			for (int i = 0; i <= max; i++)
			{
				if (i < urgentCounter
					&& i < notUrgentCounter)
				{
					lines.Add(
						$" | {urgentItems[i].ToString().PadRight(lineWidth)} | {notUrgentItems[i].ToString().PadRight(lineWidth - 1)} | "
					);
				}
				else if (i < notUrgentCounter)
				{
					lines.Add(
						$" | {" ".PadRight(lineWidth)} | {notUrgentItems[i].ToString().PadRight(lineWidth - 1)} | "
					);
				}
				else if (i < urgentCounter)
				{
					lines.Add(
						$" | {urgentItems[i].ToString().PadRight(lineWidth)} |                                      | "
					);
				}
				else
					lines.Add($" | {" ".PadRight(lineWidth)} | {" ".PadRight(lineWidth)}| ");
			}

			return lines;
		}

		public void DisplayMatrix(TodoMatrix matrix)
		{
			Console.WriteLine(Header());
			Console.WriteLine(BreakLine());
			List<string> importantLines = Lines(matrix.Quarters[0], matrix.Quarters[1]);
			foreach (string line in importantLines) Console.WriteLine(line);
			Console.WriteLine(BreakLine());
			List<string> notImportantLines = Lines(matrix.Quarters[2], matrix.Quarters[3]);
			foreach (string line in notImportantLines) Console.WriteLine(line);
			Console.WriteLine(BreakLine());
		}


		private string Header() =>
			" |                URGENT                 |              NOT URGENT              | ";

		private string BreakLine() =>
			"-|---------------------------------------|--------------------------------------|-";

		public void Welcome() => Console.WriteLine("Welcome in Eisenhower App");

		public void Closing() => Console.WriteLine("Thanks for using Eisenhower App");

		public void PrintMessage(string message) => Console.WriteLine(message);
	}
}
