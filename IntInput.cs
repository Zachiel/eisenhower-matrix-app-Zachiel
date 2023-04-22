using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerCore
{
    internal class IntInput : Input
    {
        int maxValue;
        public IntInput(string message, int maxValue) : base(message)
        {
            this.maxValue = maxValue;
            ForceValidRange();
        }

        protected override bool IsInputValid() => int.TryParse(value, out int number);
        protected bool IsInCorrectRange() => int.Parse(value) >= maxValue && int.Parse(value) > 0;
        protected void ForceValidRange() 
        {
            while (!IsInCorrectRange())
            {
                ForceValidInput();
            }
        }
        public int GetConvertedValue() => int.Parse(value);


    }
}
