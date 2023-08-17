using System;

namespace YiunHa.Dao
{
    public class UserDao
    {
        public string GetCodeForNewUser()
        {
            return "SELECT MAX([קוד מנוי]) AS Expr1 FROM[רשימת מנויים]";
        }        
        
        public string GetCodeForReshetMazon()
        {
            return "SELECT MAX([רשימת מנויים].[קוד לרשת מזון]) AS Expr1 " +
                "FROM([רשימת מנויים] INNER JOIN [הגדרות מערכת] " +
                "ON[רשימת מנויים].[קוד לרשת מזון] > [הגדרות מערכת].[ממספר בר כל]  AND [רשימת מנויים].[קוד לרשת מזון] < [הגדרות מערכת].[עד מספר בר כל] + 1) " +
                "UNION " +
                "SELECT[עד מספר בר כל] " +
                "FROM[הגדרות מערכת][הגדרות מערכת_1]";
        }

        public string InsertNewUser(User user)
        {
           return "INSERT INTO [רשימת מנויים]" +
                "([קוד מנוי], " +
                "[תעודת זהות], " +
                "[שם משפחה]," +
                " [שם פרטי], " +
                "רחוב, מספר, " +
                "[מס' בית], " +
                "ישוב, מיקוד, תד, טלפון, נייד, הערה, כולל, ישיבה, בנק, " +
                "[מספר סניף], " +
                "חשבון, " +
                "[קוד רשת מזון], " +
                "[קוד למעיין 2000], " +
                "[קוד לרשת מזון], " +
                "[מספר ילדים], " +
                "[מספר ילדים נשואים], " +
                "תואר)" +
                " VALUES(" +
            user.Code + ", " +
            user.TZ + ", '" +
            user.LastName + "', '" +
            user.FirstName + "', '" +
            user.Street + "', " +
            user.StreetNum + ", " +
            user.HomeNum + ", " +
            user.CodeIshuv + ", " +
            user.Mikud + ", " +
            user.MailBox + ", " +
            user.PhoneNum + ", " +
            user.MobilePhoneNum + ", '" +
            user.Comment + "', " +
            GetValueOrNull(user.CodeColel) + ", " +
            GetValueOrNull(user.CodeYeshiva) + ", " +
            GetValueOrNull(user.BankNum) + ", " +
            GetValueOrNull(user.BankBranchNum) + ", " +
            GetValueOrNull(user.BankAccount) + ", " +
            GetValueOrNull(user.FoodChainCode) + ", " +
            GetValueOrNull(user.CodeForMaayan) + ", " +
            GetValueOrNull(user.CodeForReshetMazon) + ", " +
            GetValueOrNull(user.ChildrenNum) + ", " +
            GetValueOrNull(user.MarriedChildrenNum) + ", " +
            user.Status +
            ")";
         }

        public string GetUserByTZ(int id)
        {
            return "SELECT *" +
                " FROM[רשימת מנויים]" +
                " WHERE([תעודת זהות]" +
                " = '" +id + "')";
        }

        public string GetUserByTZAndCodeManuy(int id, int code)
        {
            return "SELECT * " +
                "FROM[רשימת מנויים] " +
                "WHERE([תעודת זהות] = '" + id + "') AND([קוד מנוי] = " + code + ")";
        }

        public string GetUserDetailesByTZ(int id)
        {
            return "SELECT [תעודת זהות], [שם משפחה], [שם פרטי], רחוב, מספר, [מס' בית], מיקוד, תד, טלפון, נייד, בנק, [מספר סניף], חשבון, [מספר ילדים], [מספר ילדים נשואים], ישיבה, כולל, [קוד רשת מזון], ישוב, תואר "+
                "FROM[רשימת מנויים]"+
                "WHERE([תעודת זהות]" +
                " = '" + id + "')";
        }

        public string GetFoodChainInfoByTZ(int id)
        {
            return "SELECT [קוד רשת מזון], [קוד לרשת מזון], [קוד למעיין 2000], [אידיש כארד1], [אידיש כארד2] " +
                "FROM[רשימת מנויים]"+
                "WHERE([תעודת זהות]" +
                " = '" + id + "')";
        }

        public string UpdateUser(User user)
        {
            return "UPDATE [רשימת מנויים]" +
                "SET [שם משפחה] = '" + user.LastName +"'," +
                " [שם פרטי] = '"+user.FirstName +"'," +
                " רחוב = '"+ user.Street+"'," +
                " מספר = " + user.StreetNum +"," +
                " [מס' בית] = " + user.HomeNum +"," +
                " ישוב = "+user.CodeIshuv +"," +
                " מיקוד = " + user.Mikud +"," +
                " תד = '" + user.MailBox +"'," +
                " טלפון = '"+user.PhoneNum +"'," +
                " נייד = '" + user.MobilePhoneNum +"'," +
                " ישיבה = "+ GetValueOrNull(user.CodeYeshiva) +"," +
                " הערה = '" + user.Comment +"'," +
                " תואר = " + user.Status +"," +
                " כולל = "+ GetValueOrNull(user.CodeColel)+"," +
                " בנק = "+ GetValueOrNull(user.BankNum) +", " +
                " [מספר סניף] = " + GetValueOrNull(user.BankBranchNum) +"," +
                " חשבון = " + GetValueOrNull(user.BankAccount) +"," +
                " [מספר ילדים] = "+ GetValueOrNull(user.ChildrenNum) +"," +
                " [מספר ילדים נשואים] = " + GetValueOrNull(user.MarriedChildrenNum) +"," +
                " [קוד רשת מזון] = " + GetValueOrNull(user.FoodChainCode) + "," +
                " [קוד למעיין 2000] = " + GetValueOrNull(user.CodeForMaayan) + "," +
                " [קוד לרשת מזון] = " + GetValueOrNull(user.CodeForReshetMazon) + "," +
                " [תאריך הכנסה] = #" + user.EnterDate.ToString("dd/MM/yyyy") + "#" +
                " WHERE([תעודת זהות]" +
                " = '" + user.TZ + "')";
        }

        public string GetUserStatusDateAndFoodChainCodeByTZ(int id)
        {
            return "SELECT תואר, תאריך, [קוד לרשת מזון], [קוד למעיין 2000]" +
                " FROM[רשימת מנויים]" +
                " WHERE([תעודת זהות]" +
                " = '" + id + "')";
        }

        private object GetValueOrNull(Nullable<int> value)
        {
            if (value.Equals(null))
                return "NULL";
            return value.Value;
        }

        private object GetValueOrNull(Nullable<double> value)
        {
            if (value.Equals(null))
                return "NULL";
            return value.Value;
        }

    }
}
