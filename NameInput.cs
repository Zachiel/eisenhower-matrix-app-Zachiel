using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerCore
{
    internal class NameInput : Input
    {
        private List<string> Names = new List<string>();
        private TodoMatrix operatingMatrix;

        public NameInput(string message, TodoMatrix operatingMatrix) : base(message)
        {
            //AddNamesToList(operatingMatrix);
            this.operatingMatrix = operatingMatrix;
            Console.WriteLine(Names);
        }

        protected override bool IsInputValid() => IsGivenName(operatingMatrix, value) == true;


        //public bool IsGivenName(string givenName)
        //{
        //    if (Names.Contains(givenName))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        private bool IsGivenName(TodoMatrix matrix, string givenName)
        {
            foreach (TodoItem item in matrix._allItems)
            {
                if (item.GetName() == givenName)
                {
                    return true;
                };
            }
            return false;
        }
    }
}