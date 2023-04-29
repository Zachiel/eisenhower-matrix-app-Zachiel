namespace EisenhowerCore
{
    public class EisenhowerMain
    {
        public static void Main(string[] args)
        {


            TodoMatrix matrix = new TodoMatrix();
            matrix.CreateItem("Go for a walk", DateTime.Parse("12.12.2012"), false);
            matrix.CreateItem("Kill myself", DateTime.Parse("04.24.2020"), true);
            matrix.CreateItem("Get course finished", DateTime.Parse("8.10.2020"), true);
            matrix.CreateItem("Write a book", DateTime.Parse("09.04.2222"), false);
            matrix._allItems[0].MarkAsDone();
            matrix._allItems[3].MarkAsDone();
            matrix.Display();

            Display display = new Display();
            display.TakeInput(matrix);
            matrix.Display();

            Console.ReadKey();
        }
    }
}