using System;
namespace EisenhowerCore
{
	public class Display
	{
		public Display()
		{
		}

		private string Header()
		{
			return " |                URGENT                  |              NOT URGENT              | ";

        }

        private string BreakLine()
        {
            return "-|----------------------------------------|--------------------------------------|-";

        }

        private List<string> Lines(TodoQuarter urgent, TodoQuarter notUrgent)
        {
			List<string> lines = new List<string>();

			List<TodoItem> urgentItems = urgent.GetAssignedItems();
            List<TodoItem> notUrgentItems = notUrgent.GetAssignedItems();

			int urgentCounter = urgentItems.Count();
            int notUrgentCounter = notUrgentItems.Count();
			int max;
			if (urgentCounter < 13 && notUrgentCounter < 13) max = 13;
			else if (urgentCounter > notUrgentCounter) max = urgentCounter - 1;
			else max = notUrgentCounter - 1;

            for (int i = 0; i<=max; i++)
			{
				if (i < urgentCounter && i < notUrgentCounter)
				{
					lines.Add($" | {urgentItems[max - i].ToString()}  | {notUrgentItems[max- i].ToString()} | ");
				}
				else if (i < notUrgentCounter)
				{
                    lines.Add($" |                                    | {notUrgentItems[13 - i].ToString()} | ");
                }
                else if (i < urgentCounter)
                {
                    lines.Add($" | {urgentItems[max - i].ToString()}  |                                     | ");
                }
				else
				{
                    lines.Add($" |                                    |                                     | ");
                }

            }	

            return lines;

        }

        public void DisplayMatrix(TodoQuarter importantUrgent, TodoQuarter importantNotUrgent, TodoQuarter notImportantUrgent, TodoQuarter notImportantNotUrgent)
		{
			Console.WriteLine(Header());
			Console.WriteLine(BreakLine());
			List<string> importantLines = Lines(importantUrgent, importantNotUrgent);
			foreach (string line in importantLines)
			{
				Console.WriteLine(line);
			}
			Console.WriteLine(BreakLine());
            List<string> notImportantLines = Lines(notImportantNotUrgent, notImportantNotUrgent);
            foreach (string line in notImportantLines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(BreakLine());
        }
    }
}

