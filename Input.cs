namespace EisenhowerCore
{
	public class Input
	{
		private const    string  InvalidInputError = "This input is not valid. Try again";
		private readonly Display _display          = new();
		private readonly string  _message;
		protected        int     MaxValue;
		protected        string  Value;

		public Input(string message, string value = "", int maxValue = 0)
		{
			MaxValue = maxValue;
			_message = message;
			Value    = value;
			ForceValidInput();
		}

		private string? GetInputValue() => Console.ReadLine();

		private void AssignValue() => Value = GetInputValue() ?? string.Empty;

		public virtual bool IsInputValid() => Value != "";

		public string GetValue() => Value;

		protected void ForceValidInput()
		{
			do
			{
				_display.PrintMessage(_message);
				AssignValue();
				if (!IsInputValid()) _display.PrintMessage(InvalidInputError);
			}
			while (!IsInputValid());
		}
	}
}
