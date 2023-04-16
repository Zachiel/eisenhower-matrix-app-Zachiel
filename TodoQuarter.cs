namespace EisenhowerCore
{
	public class TodoQuarter
	{
		QuarterTypes.quarters type;
		List<TodoItem> assignedItems;
		TodoMatrix matrix;
        public TodoQuarter(QuarterTypes.quarters type, TodoMatrix matrix)
		{
			this.type = type;
			this.matrix = matrix;
		}

		public List<TodoItem> getAssignedItems() 
		{ 
			List<TodoItem> assigned = new List<TodoItem>();
			foreach (TodoItem item in matrix.allItems)
			{
				if (item.assignQuarter() == type) { assigned.Add(item);}
			}
			return assigned;
		}
		public void updateAssignedItems()
		{
			assignedItems = getAssignedItems();
		}
    }
}
