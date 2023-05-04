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
			Id           = _counter++;
			_name        = name;
			_date        = date;
			_isImportant = isImportant;
			IsDone       = false;
			_isArchived  = false;
		}

		public int  Id     { get; set; }
		public bool IsDone { get; private set; }

		public bool GetIsImportant() => _isImportant;

		public string GetName() => _name;

		public DateTime GetDate() => _date;


		public override string ToString()
		{
			string stringToReturn = "[";
			if (IsDone)
				stringToReturn += "X";
			else
				stringToReturn += " ";

			stringToReturn += $"] {_date.Day}-{_date.Month} {_name}";

			return stringToReturn;
		}

		private bool IsUrgent()
		{
			DateTime now        = DateTime.Now;
			double   difference = (now - _date).TotalDays;

			return difference >= -3;
		}

		public QuarterTypes.Quarters AssignQuarter()
		{
			if (_isArchived) return QuarterTypes.Quarters.ArchivedCards;
			if (_isImportant && IsUrgent()) return QuarterTypes.Quarters.ImportantUrgent;

			if (!_isImportant
				&& !IsUrgent())
				return QuarterTypes.Quarters.NotImportantNotUrgent;

			return _isImportant
					   ? QuarterTypes.Quarters.ImportantNotUrgent
					   : QuarterTypes.Quarters.NotImportantUrgent;
		}

		public void MarkAsDone() => IsDone = true;

		public void UnmarkAsDone() => IsDone = false;

		public void MarkAsArchived() => _isArchived = true;

		public void MarkAsImportant() => _isImportant = true;

		public void UnmarkAsImportant() => _isImportant = false;
	}
}
