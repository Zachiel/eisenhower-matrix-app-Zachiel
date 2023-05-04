namespace EisenhowerCore
{
	public class IntInput : Input
	{
		private readonly int _maxValue;

		public IntInput(string message, int maxValue) : base(message)
		{
			_maxValue = maxValue;
			ForceValidRange();
		}

		private bool IsInCorrectRange() => int.Parse(Value) >= _maxValue && int.Parse(Value) > 0;

		private void ForceValidRange()
		{
			while (!IsInCorrectRange()) ForceValidInput();
		}

		public override bool IsInputValid() =>
			int.TryParse(Value, out int number) && number <= _maxValue;

		public int GetConvertedValue() => int.Parse(Value);
	}
}
