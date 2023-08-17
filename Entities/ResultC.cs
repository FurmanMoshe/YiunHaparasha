using System.Collections.Generic;
using System;

namespace YiunHa
{
    public class ResultC
    {
        public int CodeManuy { get; set; }
        public string SystemMassege { get; set; }
        public Nullable<double> LastMilga { get; set; }
        public string MilgaTitle { get; set; }
        public string MilgaValidity { get; set; }
        public Nullable<int> Shovar { get; set; }
        public Nullable<int> ShovarBarkod { get; set; }
        public Nullable<int> FoodChain { get; set; }
        public Nullable<double> FoodChainBarkod1 { get; set; }
        public Nullable<double> FoodChainBarkod2 { get; set; }
        public string AnswerTitle { get; set; }
        public string AnswerTitleForHalacha { get; set; }
        public List<int> AnswerToGilyun { get; set; }
        public List<int> HalachaAnswerToGilyun { get; set; }
       
    }
}
