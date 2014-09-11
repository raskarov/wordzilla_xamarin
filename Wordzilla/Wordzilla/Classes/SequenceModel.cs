using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagment.Words.Areas.api.Models.Flashcard
{
    public class SequenceModel
    {
        public List<CardUpModel> Data { get; set; }

        public Int32 TypeId { get; set; }
    }
}