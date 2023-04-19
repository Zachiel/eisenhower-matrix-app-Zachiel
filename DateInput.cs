using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerCore
{
    internal class DateInput : Input
    {
        protected override bool IsInputValid()
        {
            return DateTime.TryParse(value, out DateTime date);
        }
        public DateInput(string message) : base(message)
        {
        }

        public DateTime GetConvertedValue() => DateTime.Parse(value);
    }
}
