namespace EisenhowerCore
{
	internal class NameInput : Input
	{
		private readonly List<string> _names = new();
		private readonly TodoMatrix   _operatingMatrix;

		public NameInput(string message, TodoMatrix operatingMatrix) : base(message)
		{
			_operatingMatrix = operatingMatrix;

			foreach (TodoItem item in _operatingMatrix.GetAllItems()) _names.Add(item.GetName());

			foreach (string name in _names) Console.WriteLine(name);
		}

		public bool IsInputValid(TodoMatrix matrix, string value) => IsGivenName(matrix, value);

		private bool IsGivenName(TodoMatrix matrix, string givenName)
		{
			foreach (TodoItem item in matrix.AllItems)
			{
				if (item.GetName() == givenName) return true;
			}

			return false;
		}
	}
}
