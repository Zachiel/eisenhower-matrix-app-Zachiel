using System;
namespace EisenhowerCore
{
    public class Display
    {
        public Display()
        {
        }

        private string Header()
        {
            return " |                URGENT                 |              NOT URGENT              | ";

        }

        private string BreakLine()
        {
            return "-|---------------------------------------|--------------------------------------|-";

        }

        private List<string> Lines(TodoQuarter urgent, TodoQuarter notUrgent, int lineWidth=37)
        {
            List<string> lines = new List<string>();

            List<TodoItem> urgentItems = urgent.GetAssignedItems();
            List<TodoItem> notUrgentItems = notUrgent.GetAssignedItems();

            int urgentCounter = urgentItems.Count();
            int notUrgentCounter = notUrgentItems.Count();
            int max;
            if (urgentCounter < 13 && notUrgentCounter < 13) max = 13;
            else if (urgentCounter > notUrgentCounter) max = urgentCounter - 1;
            else max = notUrgentCounter - 1;
            for (int i = 0; i <= max; i++)
            {
                if (i < urgentCounter && i < notUrgentCounter)
                {
                    lines.Add($" | {urgentItems[i].ToString().PadRight(lineWidth)} | {notUrgentItems[i].ToString().PadRight(lineWidth)} | ");
                }
                else if (i < notUrgentCounter)
                {
                    lines.Add($" |                                       | {notUrgentItems[i].ToString().PadRight(lineWidth)} | ");
                }
                else if (i < urgentCounter)
                {
                    lines.Add($" | {urgentItems[i].ToString().PadRight(lineWidth)} |                                      | ");
                }
                else
                {
                    lines.Add($" |                                       |                                      | ");
                }

            }

            return lines;

        }

        public void DisplayMatrix(TodoMatrix Matrix)
        {
            Console.WriteLine(Header());
            Console.WriteLine(BreakLine());
            List<string> importantLines = Lines(Matrix._quarters[0], Matrix._quarters[1]);
            foreach (string line in importantLines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(BreakLine());
            List<string> notImportantLines = Lines(Matrix._quarters[2], Matrix._quarters[3]);
            foreach (string line in notImportantLines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(BreakLine());
        }

        public void TakeInput(TodoMatrix matrix)
        {
            Input input = new Input("Provide task");
            DateInput dateInput = new DateInput("Provide deadline for you task");
            BoolInput boolInput = new BoolInput("Is your task important?");

            string todo = input.GetValue();
            DateTime deadline = dateInput.GetConvertedValue();
            bool importance = boolInput.GetConvertedValue();

            matrix.CreateItem(todo, deadline, importance);
        }

        public void Welcome()
        {
            Console.WriteLine("Welcome in Eisenhower App");
        }


        public string HoldLogic()
        {
            LogicInput input = new LogicInput("Provide 't' if you want to add task, " +
                "provide 'd' if you want to mark your task as done");

            string inputValue = input.GetValue();
            return inputValue;
        }


        public string RunProgram()
        {
            ProgramLogicInput input = new ProgramLogicInput("Provide 'c' if you want to contiue using program, " +
                "provide 's' if you want to stop the program");

            string inputValue = input.GetValue();
            return inputValue;
        }

        public void Closing()
        {
            Console.WriteLine("Thanks for using Eisenhower App");
        }
    }
}
