namespace EisenhowerCore
{
	public class TodoMatrix
	{
		List<TodoQuarter> quarters;
		public List<TodoItem> allItems;
		
		public TodoMatrix()
		{
			this.allItems = new List<TodoItem>();
			this.quarters = new List<TodoQuarter>();
            foreach (QuarterTypes.quarters quarter in Enum.GetValues(typeof(QuarterTypes.quarters)))
            {
                quarters.Add(new TodoQuarter(quarter, this));
            }
        }
        public void updateAllQuarters()
		{
            foreach (TodoQuarter quarter in quarters)
            {
                quarter.updateAssignedItems();
            }
        }
		public void createItem(string name, DateTime date, bool isImportant)
		{
			TodoItem item = new TodoItem(name, date, isImportant);
			this.allItems.Add(item);
			updateAllQuarters();
		}
		public void removeItem(int id)
		{
            foreach (var item in allItems)
            {
                if (item.id == id)
				{
					allItems.Remove(item);
				}
            }
			updateAllQuarters();
        }
		public void archiveCards()
		{
            foreach (var item in allItems)
            {
                if (item.isDone)
				{
					item.markAsArchived();
				}
            }
			updateAllQuarters();
        }

    }
}
