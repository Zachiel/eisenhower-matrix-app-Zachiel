using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerCore
{
    internal class BoolInput : Input
    {
        public BoolInput(string message) : base(message)
        {
        }

        protected override bool IsInputValid() => value.ToLower() == "y" || value.ToLower() == "n";
        public bool GetConvertedValue() => value.ToLower() == "y";


    }
}
