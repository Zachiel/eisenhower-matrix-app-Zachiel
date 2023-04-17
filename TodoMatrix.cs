namespace EisenhowerCore
{
	public class TodoMatrix
	{
		private readonly List<TodoQuarter> _quarters;
		public readonly List<TodoItem>    _allItems;

		public TodoMatrix()
		{
			_allItems = new List<TodoItem>();
			_quarters = new List<TodoQuarter>();
			foreach (QuarterTypes.quarters quarter in Enum.GetValues(typeof(QuarterTypes.quarters)))
				_quarters.Add(new TodoQuarter(quarter, this));
		}

		public void updateAllQuarters()
		{
			foreach (TodoQuarter quarter in _quarters) quarter.UpdateAssignedItems();
		}

		public void CreateItem(string name, DateTime date, bool isImportant)
		{
			TodoItem item = new(name, date, isImportant);
			_allItems.Add(item);
			updateAllQuarters();
		}

		public void RemoveItem(int id)
		{
			foreach (TodoItem item in _allItems)
				if (item._id == id)
					_allItems.Remove(item);

			updateAllQuarters();
		}

		public void ArchiveCards()
		{
			foreach (TodoItem item in _allItems)
				if (item._isDone)
					item.MarkAsArchived();

			updateAllQuarters();
		}
	}
}
