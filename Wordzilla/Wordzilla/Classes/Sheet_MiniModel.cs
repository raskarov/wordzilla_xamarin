using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagment.Words.Areas.api.Models.Sheet
{
	[Serializable]
    public class MiniModel
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public String DateCreate { get; set; }

        public String Type { get; set; }

        public Int32 Good { get; set; }

        public Int32 Nearly { get; set; }

        public Int32 Bad { get; set; }

        public Int32 No { get; set; }

		public String IsNew { get; set; }
    }
}