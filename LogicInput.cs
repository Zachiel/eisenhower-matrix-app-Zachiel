namespace EisenhowerCore
{
	internal class LogicInput : Input
	{
		public LogicInput(string message) : base(message) { }

		protected override bool IsInputValid() =>
			Value.ToLower() == "t" || Value.ToLower() == "d" || Value.ToLower() == "p";
	}
}
