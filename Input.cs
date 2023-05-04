using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerCore
{
    public class Input
    {
        protected int maxValue;
        protected static string InvalidInputError = "This input is not valid. Try again";
        protected string message;
        protected string value;
        protected string getInputValue() => Console.ReadLine();
        protected void assignValue() => value = getInputValue();
        protected virtual bool IsInputValid() => value != "";
        public string GetValue() => value;
        Display display = new Display();

        protected void ForceValidInput()
        {
            do
            {
                display.PrintMessage(message); 
                assignValue();
                if (!IsInputValid()) display.PrintMessage(InvalidInputError); 
            }
            while (!IsInputValid());
        }
        public Input(string message, int maxValue = 0)
        {
            this.maxValue = maxValue;
            this.message = message;
            ForceValidInput();
        }

    }
}