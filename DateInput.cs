namespace EisenhowerCore
{
	internal class DateInput : Input
	{
		public DateInput(string message) : base(message) { }

		// ReSharper disable once UnusedVariable
		public override bool IsInputValid() => DateTime.TryParse(Value, out DateTime date);

		public DateTime GetConvertedValue() => DateTime.Parse(Value);
	}
}
