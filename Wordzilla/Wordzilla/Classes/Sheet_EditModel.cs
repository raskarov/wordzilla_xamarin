using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagment.Words.Areas.api.Models.Sheet
{
    public class EditModel
    {
        public Int32 SheetId { get; set; }

        public String Name { get; set; }

        public String DateCreate { get; set; }

        public Int32 Type { get; set; }
    }
}