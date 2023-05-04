namespace EisenhowerCore
{
	public class TodoMatrix
	{
		private readonly Display           _display;
		public readonly  List<TodoItem>    AllItems;
		public readonly  List<TodoQuarter> Quarters;

		public TodoMatrix()
		{
			_display = new Display();
			AllItems = new List<TodoItem>();
			Quarters = new List<TodoQuarter>();
			foreach (QuarterTypes.Quarters quarter in Enum.GetValues(typeof(QuarterTypes.Quarters)))
				Quarters.Add(new TodoQuarter(quarter, this));
		}

		public List<TodoItem> GetAllItems() => AllItems;

		private void UpdateAllQuarters()
		{
			foreach (TodoQuarter quarter in Quarters) quarter.UpdateAssignedItems();
		}

		public void CreateItem(string name, DateTime date, bool isImportant)
		{
			TodoItem item = new(name, date, isImportant);
			AllItems.Add(item);
			UpdateAllQuarters();
		}

		public void RemoveItem(int id)
		{
			foreach (TodoItem item in AllItems)
			{
				if (item.Id == id) AllItems.Remove(item);
			}

			UpdateAllQuarters();
		}

		public void ArchiveCards()
		{
			foreach (TodoItem item in AllItems)
			{
				if (item.IsDone) item.MarkAsArchived();
			}

			UpdateAllQuarters();
		}

		public void Display() => _display.DisplayMatrix(this);
	}
}
