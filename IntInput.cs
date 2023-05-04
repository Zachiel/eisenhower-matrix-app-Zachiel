namespace EisenhowerCore
{
	internal class IntInput : Input
	{
		private readonly int maxValue;

		public IntInput(string message, int maxValue) : base(message)
		{
			this.maxValue = maxValue;
			ForceValidRange();
		}

		protected bool IsInCorrectRange() => int.Parse(value) >= maxValue && int.Parse(value) > 0;

		protected void ForceValidRange()
		{
			while (!IsInCorrectRange()) ForceValidInput();
		}

		protected override bool IsInputValid() =>
			int.TryParse(value, out int number) && number <= maxValue;

		public int GetConvertedValue() => int.Parse(value);
	}
}
