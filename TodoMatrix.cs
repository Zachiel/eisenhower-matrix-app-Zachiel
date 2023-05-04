namespace EisenhowerCore
{
    public class TodoMatrix
    {
        public readonly List<TodoQuarter> _quarters;
        public readonly List<TodoItem> _allItems;
        Display display;

        public TodoMatrix()
        {
            display = new Display();
            _allItems = new List<TodoItem>();
            _quarters = new List<TodoQuarter>();
            foreach (QuarterTypes.quarters quarter in Enum.GetValues(typeof(QuarterTypes.quarters)))
                _quarters.Add(new TodoQuarter(quarter, this));
        }

        public List<TodoItem> GetAllItems() => _allItems;

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

        public void Display()
        {
            display.DisplayMatrix(this);
        }

        //Dictionary<string, TodoQuarter> TodoQuarters = new Dictionary<string, TodoQuarter>()
        //{
        //    {"IU", _quarters[0] },
        //    {"IN", _quarters[1] },
        //    {"NU", _quarters[2] },
        //    {"NN", _quarters[3] }
        //};

        //public List<TodoQuarter> GetQuarters()
        //{
        //    return _quarters;
        //}

        //public TodoQuarter GetQuarter(string status)
        //{
        //    return TodoQuarters[status];
        //}
    }
}
