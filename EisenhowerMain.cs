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

            matrix.CreateItem("Go for a walk", DateTime.Parse("12.12.2012"), false);
            matrix.CreateItem("Kill myself", DateTime.Parse("04.24.2020"), true);
            matrix.CreateItem("Get course finished", DateTime.Parse("8.10.2020"), true);
            matrix.CreateItem("Write a book", DateTime.Parse("09.04.2222"), false);
            matrix._allItems[0].MarkAsDone();
            matrix._allItems[3].MarkAsDone();
            //matrix.Display();

            string run = display.RunProgram();
            do
            {
                string letter = display.HoldLogic();

                if (letter == "t")
                {
                    display.TakeInput(matrix);
                }
                else if (letter == "d")
                {

                }

                matrix.Display();
                run = display.RunProgram();
            } while (run == "c");

            display.Closing();


            Console.ReadKey();
        }
    }
}