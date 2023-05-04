namespace EisenhowerCore
{
	internal class ProgramLogicInput : Input
	{
		public ProgramLogicInput(string message) : base(message) { }

		public override bool IsInputValid() => Value.ToLower() == "c" || Value.ToLower() == "s";

		public bool Running() => Value == "c";
	}
}
