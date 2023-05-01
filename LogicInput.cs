using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerCore
{
    internal class LogicInput : Input
    {
        public LogicInput(string message) : base(message)
        {
        }

        protected override bool IsInputValid() => value.ToLower() == "t" || value.ToLower() == "d";

    }
}