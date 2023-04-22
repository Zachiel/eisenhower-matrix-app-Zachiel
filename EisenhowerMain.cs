namespace EisenhowerCore
{
    public class EisenhowerMain
    {
        public static void Main(string[] args)
        {
            TodoMatrix matrix = new TodoMatrix();
            matrix.CreateItem("Go for a walk", DateTime.Parse("23.04.2023"), false);
            matrix.CreateItem("Kill myself", DateTime.Parse("24.04.2023"), true);
            matrix.CreateItem("Get course finished", DateTime.Parse("8.10.2023"), true);
            matrix.CreateItem("Write a book", DateTime.Parse("29.04.2222"), false);
            matrix._allItems[0].MarkAsDone();
            matrix._allItems[3].MarkAsDone();
            matrix.Display();
        }
    }
}