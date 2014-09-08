using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagment.Words.Areas.api.Models.Words
{
    public class MiniModel
    {
		public Int32 WordId { get; set; }

        public String English { get; set; }

        public String Transcription { get; set; }

        public String Russian { get; set; }

        public String Description { get; set; }

		//work
		public Int32 Id { get; set; }

    }
}