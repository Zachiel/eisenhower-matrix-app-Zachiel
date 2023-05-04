namespace EisenhowerCore
{
	public class TodoItem
	{
		private static   int      _counter;
		private readonly DateTime _date;
		private readonly string   _name;
		private          bool     _isArchived;
		private          bool     _isImportant;

		public TodoItem(string name, DateTime date, bool isImportant)
		{
			_id          = _counter++;
			_name        = name;
			_date        = date;
			_isImportant = isImportant;
			_isDone      = false;
			_isArchived  = false;
		}

		public int  _id     { get; set; }
		public bool _isDone { get; set; }


		public override string ToString()
		{
			string stringToReturn = "[";
			if (_isDone)
				stringToReturn += "X";
			else
				stringToReturn += " ";

			stringToReturn += $"] {_date.Day}-{_date.Month} {_name}";

			return stringToReturn;
		}

		public bool IsUrgent()
		{
			DateTime now        = DateTime.Now;
			double   difference = (now - _date).TotalDays;

			return difference <= 3;
		}

		public QuarterTypes.quarters AssignQuarter()
		{
			if (!_isArchived)
			{
				if (_isImportant && IsUrgent()) return QuarterTypes.quarters.importantUrgent;

				if (_isImportant || IsUrgent())
				{
					if (_isImportant) return QuarterTypes.quarters.importantNotUrgent;

					return QuarterTypes.quarters.notImportantUrgent;
				}

				return QuarterTypes.quarters.notImportantNotUrgent;
			}

			return QuarterTypes.quarters.archivedCards;
		}

		public void MarkAsDone() => _isDone = true;

		public void UnmarkAsDone() => _isDone = false;

		public void MarkAsArchived() => _isArchived = true;

		public void MarkAsImportant() => _isImportant = true;

		public void UnmarkAsImportant() => _isImportant = false;
	}
}

        public void MarkAsDone() => _isDone = true;

        public void UnmarkAsDone() => _isDone = false;

        public void MarkAsArchived() => _isArchived = true;

        public void MarkAsImportant() => _isImportant = true;

        public void UnmarkAsImportant() => _isImportant = false;
    }
}
