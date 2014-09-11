using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagment.Words.Areas.api.Models.Flashcard
{
    public class CardDownModel
    {
        public Int32 WordId { get; set; }

        public String Name { get; set; }

        public String DateCreate { get; set; }
    }
}