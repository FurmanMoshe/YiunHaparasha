namespace YiunHa.Dao
{
    public class CommonTableDao
    {
        public string GetLastMilga(int id)
        {
            return "SELECT  [הכל בלי תלוש 4] FROM [טבלה משותפת] " +
                " WHERE([תעודת זהות]" +
                " = '" + id + "')";
         }        
    }
}
