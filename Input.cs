namespace EisenhowerCore
{
	public class Input
	{
		protected static string  InvalidInputError = "This input is not valid. Try again";
		private readonly Display display           = new();
		protected        int     maxValue;
		protected        string  message;
		protected        string  value;

		public Input(string message, int maxValue = 0)
		{
			this.maxValue = maxValue;
			this.message  = message;
			ForceValidInput();
		}

		protected string getInputValue() => Console.ReadLine();

		protected void assignValue() => value = getInputValue();

		protected virtual bool IsInputValid() => value != "";

		public string GetValue() => value;

		protected void ForceValidInput()
		{
			do
			{
				display.PrintMessage(message);
				assignValue();
				if (!IsInputValid()) display.PrintMessage(InvalidInputError);
			}
			while (!IsInputValid());
		}
	}
}
