namespace YiunHa.Dao
{
    public class CodeIshuvDao
    {
        public string GetMaxCodeIshuv()
        {
            return "SELECT MAX(קוד) AS exp FROM[קוד ישוב]";
         }        
        
        public string GetCodeIshuv(string newIshuv)
        {
            return "SELECT קוד FROM[קוד ישוב] WHERE(תאור = '"+ newIshuv + "')";
         }

        public string InsertNewIshuv(string newIshuv, int code)
        {
            return "INSERT INTO [קוד ישוב] (קוד, תאור) VALUES(" +code+", '"+newIshuv+"')";
        }

    }
}
