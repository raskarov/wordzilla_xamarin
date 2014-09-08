using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagment.Words.Areas.api.Models.Sheet
{
    public class TableModel
    {
        public Int32 BadLearn { get; set; }

        public Int32 NearlyLearn { get; set; }

        public Int32 GoodLearn { get; set; }

        public Int32 NoLearn { get; set; }

        public Int64 GroupId { get; set; }

        public Int64 GroupTeacherId { get; set; }

        public String TeacherName { get; set; }

        public List<MiniModel> DataTeacher { get; set; }

        public List<MiniModel> DataStudent { get; set; }
    }
}