namespace EisenhowerCore
{
	internal class BoolInput : Input
	{
		public BoolInput(string message) : base(message) { }

		public override bool IsInputValid() => Value.ToLower() == "y" || Value.ToLower() == "n";

		public bool GetConvertedValue() => Value.ToLower() == "y";
	}
}
