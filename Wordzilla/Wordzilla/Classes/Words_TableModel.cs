using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagment.Words.Areas.api.Models.Words
{
    public class TableModel
    {
        public Int32 SheetWordId { get; set; }

        public Int64 GroupId { get; set; }

        public List<MiniModel> Data { get; set; }
    }
}