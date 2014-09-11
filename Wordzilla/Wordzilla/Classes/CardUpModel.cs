using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagment.Words.Areas.api.Models.Flashcard
{
    public class CardUpModel
    {
        public CardUpModel()
        {
        }

        public CardUpModel(CardUpModel x)
        {
            WordId = x.WordId;
            SheetId = x.SheetId;
            English = x.English;
            Transcription = x.Transcription;

            PartSpeech = String.Empty;
            Russian = x.Russian;

            Verb1 = x.Verb1;
            Verb2 = x.Verb2;
            Verb3 = x.Verb3;

            Description = x.Description;
            Status = x.Status;
            BadLearn = x.BadLearn;
            NearlyLearn = x.NearlyLearn;
            GoodLearn = x.GoodLearn;
            NoLearn = x.NoLearn;
        }

        public Int32 WordId { get; set; }

        public Int32 SheetId { get; set; }

        public String English { get; set; }

        public String Transcription { get; set; }

        public String PartSpeech { get; set; }

        public String Russian { get; set; }

        public String Verb1 { get; set; }

        public String Verb2 { get; set; }

        public String Verb3 { get; set; }

        public String Description { get; set; }

        public Int32 Status { get; set; }

        public Int32 BadLearn { get; set; }

        public Int32 NearlyLearn { get; set; }

        public Int32 GoodLearn { get; set; }

        public Int32 NoLearn { get; set; }
    }
}