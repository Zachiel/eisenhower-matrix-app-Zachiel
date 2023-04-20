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

            for (int i = 13; i>0; i--)
			{
				if (urgentItems[13 - i] == null && notUrgentItems[13 - i] != null)
				{
					lines.Add($" | {urgentItems[13 - i]}  | {notUrgentItems[13 - i]} | ");
					urgentCounter--;
					notUrgentCounter--;
				}
				else if (urgentItems[13 - i] == null && notUrgentItems[13 - i] != null)
				{
                    lines.Add($" |                                        | {notUrgentItems[13 - i]} | ");
					notUrgentCounter--;
                }
                else if (urgentItems[13 - i] != null && notUrgentItems[13 - i] == null)
                {
                    lines.Add($" | {urgentItems[13 - i]}  |                                         | ");
					urgentCounter--;
                }
				else
				{
                    lines.Add($" |                                         |                                         | ");
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

