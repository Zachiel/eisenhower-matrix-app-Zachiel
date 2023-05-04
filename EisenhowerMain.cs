namespace EisenhowerCore
{
	public static class EisenhowerMain
	{
		public static void Main(string[] args)
		{
			Display    display   = new();
			TodoMatrix newMatrix = new();

			display.Welcome();

			//matrix.CreateItem("Go for a walk", DateTime.Parse("12.12.2012"), false);
			//matrix.CreateItem("Kill myself", DateTime.Parse("04.24.2020"), true);
			//matrix.CreateItem("Get course finished", DateTime.Parse("8.10.2020"), true);
			//matrix.CreateItem("Write a book", DateTime.Parse("09.04.2222"), false);
			//matrix._allItems[0].MarkAsDone();
			//matrix._allItems[3].MarkAsDone();

			// ReSharper disable once RedundantAssignment
			string run = RunProgram();

			do
			{
				string letter = HoldLogic();

				switch (letter)
				{
					case "t":
						MakeItem(newMatrix);

						break;
					case "d":
						Console.WriteLine(newMatrix.AllItems);

						NameInput taskName = new(
							"Provide name of task you want to mark as done", newMatrix
						);

						if (taskName.IsInputValid(newMatrix, taskName.GetValue()))
						{
							TodoItem updatingItem = TodoMatrix.ItemFromName(
								newMatrix, taskName.GetValue()
							);

							updatingItem.MarkAsDone();
						}
						else
							Console.WriteLine($"No item with name {taskName.GetValue()} found.");

						break;
				}

				newMatrix.Display();
				run = RunProgram();
			}
			while (run == "c");

			display.Closing();
			Console.ReadKey();


			void MakeItem(TodoMatrix matrix)
			{
				Input     input     = new("Provide task");
				DateInput dateInput = new("Provide deadline for you task");
				BoolInput boolInput = new("Is your task important?");

				string   todo       = input.GetValue();
				DateTime deadline   = dateInput.GetConvertedValue();
				bool     importance = boolInput.GetConvertedValue();

				matrix.CreateItem(todo, deadline, importance);
			}


			string HoldLogic()
			{
				LogicInput input = new(
					"Provide 'p' if you only want to see your matrix, "
					+ "'t' if you want to add task, "
					+ "or 'd' if you want to mark your task as done"
				);

				string inputValue = input.GetValue();

				return inputValue;
			}


			string RunProgram()
			{
				ProgramLogicInput input = new(
					"Provide 'c' if you want to continue using program, "
					+ "provide 's' if you want to stop the program"
				);

				string inputValue = input.GetValue();

				return inputValue;
			}
		}
	}
}
