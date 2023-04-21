using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerCore
{
    public class Input
    {
        protected static string InvalidInputError = "This input is not valid. Try again";
        protected string message;
        protected string value;
        protected string getInputValue() => Console.ReadLine();
        protected void assignValue() => value = getInputValue();
        protected virtual bool IsInputValid() => value != "";
        public string GetValue() => value; 
        protected void ForceValidInput()
        {
            do {
                Console.WriteLine(message); //placeholder until display class is not created
                assignValue();
                if (!IsInputValid()) Console.WriteLine(InvalidInputError); //also a placeholder
               }
            while (!IsInputValid());
        }
        public Input(string message)
        {
            this.message = message;
            ForceValidInput();
        }

    }
}
