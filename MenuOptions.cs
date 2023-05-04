using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerCore
{
    public class MenuOptions
    {
        public enum Options
        {
            CreateNewItem,
            EditExistingItems,
            EditArchivedItems,
            RemoveItem,
            ArchiveItems,
            Quit
        }
        public enum EditingOptions
        {
            ChangeName,
            ChangeDate,
            ChangePriority,
            MarkOrUnmarkAsDone,
            Quit
        }
    }
}
