namespace EisenhowerCore
{
	internal class ProgramLogicInput : Input
	{
		public ProgramLogicInput(string message) : base(message) { }

		protected override bool IsInputValid() => Value.ToLower() == "c" || Value.ToLower() == "s";

		public bool Running() => Value == "c";
	}
}
