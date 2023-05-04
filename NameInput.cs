namespace EisenhowerCore
{
	internal class NameInput : Input
	{
		private readonly List<string> _names = new();
		private readonly TodoMatrix   _operatingMatrix;

		public NameInput(string message, TodoMatrix operatingMatrix) : base(message)
		{
			//AddNamesToList(operatingMatrix);
			_operatingMatrix = operatingMatrix;
			Console.WriteLine(_names);
		}

		protected override bool IsInputValid() => IsGivenName(_operatingMatrix, Value);


		//public bool IsGivenName(string givenName)
		//{
		//    if (Names.Contains(givenName))
		//    {
		//        return true;
		//    }
		//    return false;
		//}

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
