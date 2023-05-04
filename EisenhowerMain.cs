using System.Diagnostics.Metrics;

namespace EisenhowerCore
{
    public class EisenhowerMain
    {
        public static void Main(string[] args)
        {
            Display display = new Display();
            TodoMatrix matrix = new TodoMatrix();

            display.Welcome();

            //matrix.CreateItem("Go for a walk", DateTime.Parse("12.12.2012"), false);
            //matrix.CreateItem("Kill myself", DateTime.Parse("04.24.2020"), true);
            //matrix.CreateItem("Get course finished", DateTime.Parse("8.10.2020"), true);
            //matrix.CreateItem("Write a book", DateTime.Parse("09.04.2222"), false);
            //matrix._allItems[0].MarkAsDone();
            //matrix._allItems[3].MarkAsDone();

            bool run = true;
            do
            {
                string letter = HoldLogic();

                if (letter == "t")
                {
                    MakeItem(matrix);
                }
                else if (letter == "d")
                {
                    Console.WriteLine(matrix._allItems);

                    NameInput taskName = new NameInput("Provide name of task you want to mark as done", matrix);
                    //TodoItem updatingItem = ItemFromName(matrix, taskName.GetValue());
                    //updatingItem.MarkAsDone();
                }

                matrix.Display();
                run = RunProgram();
            } while (run == true);

            display.Closing();
            Console.ReadKey();



            void MakeItem(TodoMatrix matrix)
            {
                Input input = new Input("Provide task");
                DateInput dateInput = new DateInput("Provide deadline for you task");
                BoolInput boolInput = new BoolInput("Is your task important?");

                string todo = input.GetValue();
                DateTime deadline = dateInput.GetConvertedValue();
                bool importance = boolInput.GetConvertedValue();

                matrix.CreateItem(todo, deadline, importance);
            }


            string HoldLogic()
            {
                LogicInput input = new LogicInput("Provide 'p' if you only want to see your matrix, " +
                    "'t' if you want to add task, " +
                    "or 'd' if you want to mark your task as done");

                string inputValue = input.GetValue();
                return inputValue;
            }


            bool RunProgram()
            {
                ProgramLogicInput input = new ProgramLogicInput("Provide 'c' if you want to contiue using program, " +
                    "provide 's' if you want to stop the program");

                string inputValue = input.GetValue();

                return input.Running();
            }

        //    TodoItem ItemFromName(TodoMatrix matrix, string givenName)
        //    {
        //        foreach (TodoItem item in matrix._allItems)
        //        {
        //             if (item.GetName() == givenName)
        //             {
        //                return item;
        //             }
        //        }
        //    }
        }
    }
}