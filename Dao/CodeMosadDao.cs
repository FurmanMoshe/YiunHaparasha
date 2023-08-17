namespace YiunHa.Dao
{
    public class CodeMosadotDao
    {
        public string GetMaxCodeMosad()
        {
            return "SELECT MAX(קוד) AS exp FROM[קוד מוסדות]";
         }

        public string GetCodeMosad(string newMosad)
        {
            return "SELECT קוד FROM [קוד מוסדות]  WHERE(שם = '" + newMosad + "')";
        }

        public string InsertNewMosad(string newMosad, int code, int type)
        {
            return "INSERT INTO [קוד מוסדות] (קוד, שם, ישיבה) VALUES(" + code + ",'"+ newMosad + "',"+ type + ")";
        }

    }
}
