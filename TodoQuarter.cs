namespace EisenhowerCore
{
	public class TodoQuarter
	{
		private readonly TodoMatrix            _matrix;
		private readonly QuarterTypes.Quarters _type;
		private          List<TodoItem>        _assignedItems = null!;

		public TodoQuarter(QuarterTypes.Quarters type, TodoMatrix matrix)
		{
			_type   = type;
			_matrix = matrix;
			UpdateAssignedItems();
		}

		public List<TodoItem> GetAssignedItems()
		{
			List<TodoItem> assigned = new();

			foreach (TodoItem item in _matrix.AllItems)
			{
				if (item.AssignQuarter() == _type) assigned.Add(item);
			}

			return assigned;
		}

		public void UpdateAssignedItems() => _assignedItems = GetAssignedItems();
	}
}
