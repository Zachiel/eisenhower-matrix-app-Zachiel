namespace EisenhowerCore
{
    public class EisenhowerMain
    {
        public static void Main(string[] args)
        {
            Display display = new Display();
            TodoMatrix matrix = new TodoMatrix();
            TodoQuarter quarter1 = new TodoQuarter(QuarterTypes.quarters.importantUrgent, matrix);
            TodoQuarter quarter2 = new TodoQuarter(QuarterTypes.quarters.importantNotUrgent, matrix);
            TodoQuarter quarter3 = new TodoQuarter(QuarterTypes.quarters.notImportantUrgent, matrix);
            TodoQuarter quarter4 = new TodoQuarter(QuarterTypes.quarters.notImportantNotUrgent, matrix);

            display.DisplayMatrix(quarter1, quarter2, quarter3, quarter4);


            BoolInput boolInput = new BoolInput("give me bool");


            IntInput input = new IntInput("Get value", 13);
        }
    }
}