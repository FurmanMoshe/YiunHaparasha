using System;

namespace YiunHa
{
    public class UserDto
    {
        public int TZ { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public Nullable<int> StreetNum { get; set; }
        public Nullable<int> HomeNum { get; set; }
        public Nullable<int> CodeIshuv { get; set; }
        public Nullable<int> Mikud { get; set; }
        public Nullable<int> MailBox { get; set; }
        public string PhoneNum { get; set; }
        public string MobilePhoneNum { get; set; }
        public int Status { get; set; }
        public Nullable<int> CodeMosad { get; set; }
        public Nullable<int> ChildrenNum { get; set; }
        public Nullable<int> MarriedChildrenNum { get; set; }
        public Nullable<int> FoodChainCode { get; set; }        
        public Nullable<int> BankNum { get; set; }
        public Nullable<int> BankBranchNum { get; set; }
        public Nullable<int> BankAccount { get; set; }
    }
}
