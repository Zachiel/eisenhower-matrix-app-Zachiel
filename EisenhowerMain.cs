namespace EisenhowerCore
{
	public class EisenhowerMain
	{
		public static void Main(string[] args) 
		{
			BoolInput booly = new BoolInput("Enter");
			Input stringy = new Input("String");
			DateInput datey = new DateInput("Date");
			bool True = booly.GetConvertedValue();
			string Yasss = stringy.GetValue();
			datey.GetConvertedValue();
		}
	}
}
