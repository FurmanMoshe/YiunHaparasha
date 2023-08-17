using System;

namespace YiunHa
{
    public class User
    {
        public int Code { get; set; }
        public int TZ { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public Nullable<int> StreetNum { get; set; }
        public Nullable<int> HomeNum { get; set; }
        public Nullable<int> CodeIshuv { get; set; }
        public string NewIshuv { get; set; }
        public Nullable<int> Mikud { get; set; }
        public Nullable<int> MailBox { get; set; }
        public string PhoneNum { get; set; }
        public string MobilePhoneNum { get; set; }
        public int Status { get; set; }
        public Nullable<int> CodeMosad { get; set; }
        public Nullable<int> CodeYeshiva { get; set; }
        public Nullable<int> CodeColel { get; set; }
        public string NewMosad { get; set; }
        public Nullable<int> ChildrenNum { get; set; }
        public Nullable<int> MarriedChildrenNum { get; set; }
        public Nullable<int> FoodChainCode { get; set; }
        public Nullable<int> CodeForMaayan { get; set; }
        public Nullable<double> CodeForReshetMazon { get; set; }
        public string Comment { get; set; }
        public Nullable<int> BankNum { get; set; }
        public Nullable<int> BankBranchNum { get; set; }
        public Nullable<int> BankAccount { get; set; }
        public DateTime EnterDate { get; set; }

        public void SetCodeMosad()
        {
            if (this.Status == 1)
            {
                this.CodeColel = this.CodeMosad;
            }
            else
            {
                this.CodeYeshiva = this.CodeMosad;
            }
        }        
       
    }
}
