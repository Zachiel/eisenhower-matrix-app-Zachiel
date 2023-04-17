namespace EisenhowerCore
{
	public class TodoQuarter
	{
		private          List<TodoItem>        _assignedItems;
		private readonly TodoMatrix            _matrix;
		private readonly QuarterTypes.quarters _type;

		public TodoQuarter(QuarterTypes.quarters type, TodoMatrix matrix)
		{
			this._type   = type;
			this._matrix = matrix;
		}

		public List<TodoItem> GetAssignedItems()
		{
			List<TodoItem> assigned = new();
			foreach (TodoItem item in _matrix.allItems)
				if (item.AssignQuarter() == _type)
					assigned.Add(item);

			return assigned;
		}

		public void UpdateAssignedItems() => _assignedItems = GetAssignedItems();
	}
}
