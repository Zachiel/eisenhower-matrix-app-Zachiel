namespace EisenhowerCore
{
	public class TodoItem
	{
		static int counter = 0;
		public int id { get; }
		string name;
		DateTime date;
		bool isImportant;
		public bool isDone { get; }
		bool isArchived;
		public TodoItem(string name, DateTime date, bool isImportant)
		{
			id = counter++;
			this.name = name;
			this.date = date;
			this.isImportant = isImportant;
			isDone = false; 
			isArchived = false;
		}
        public override string ToString()
        {
			string stringToReturn = "[";
			if (isDone)
			{
				stringToReturn += "X";
			}
			else
			{
				stringToReturn += " ";
			}
			stringToReturn += $"] {date.Day}-{date.Month} {name}";
			return stringToReturn;
        }

		public bool isUrgent()
		{
			DateTime now = DateTime.Now;
			double difference = (now - date).TotalDays;
			return difference <= 3;
		}
		public QuarterTypes.quarters assignQuarter()
		{
			if (isArchived)
			{
				if (isImportant && isUrgent())
				{
					return QuarterTypes.quarters.importantUrgent;
				}
				else if (isImportant || isUrgent())
				{
					if (isImportant)
					{
						return QuarterTypes.quarters.importantNotUrgent;
					}
					else
					{
						return QuarterTypes.quarters.notImportantUrgent;
					}
				}
				else
				{
					return QuarterTypes.quarters.notImportantNotUrgent;
				}
			}
			else
			{
				return QuarterTypes.quarters.archivedCards;
			}
		}

		public void markAsDone()
		{
			isDone = true;
		}
		public void unmarkAsDone()
		{
			isDone = false;
		}
		public void markAsArchived()
		{
			isArchived = true;
		}
		public void markAsImportant()
		{
			isImportant = true;
		}
		public void unmarkAsImportant()
		{
			isImportant = false;
		}

    }
}
