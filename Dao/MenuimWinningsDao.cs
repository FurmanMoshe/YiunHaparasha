namespace YiunHa.Dao
{
    public class MenuimWinningsDao
    {
        public string GetSystemAnswersToGilun(int id)
        {
            return "SELECT [זכיות למנויים].[קוד גליון] " +
                "FROM([רשימת מנויים] INNER JOIN " +
                "[זכיות למנויים] ON[רשימת מנויים].[קוד מנוי] = [זכיות למנויים].[קוד מנוי]) " +
                "WHERE([רשימת מנויים].[תעודת זהות] = '" + id +"')" +
                " AND([זכיות למנויים].[מספר זכיות] > 0) " +
                "ORDER BY[זכיות למנויים].[קוד גליון] DESC";
        }          
        
        public string GetSystemHalachaAnswersToGilun(int id)
        {
            return "SELECT [זכיות למנויים].[קוד גליון] " +
                "FROM([רשימת מנויים] INNER JOIN " +
                " [זכיות למנויים] ON[רשימת מנויים].[קוד מנוי] = [זכיות למנויים].[קוד מנוי]) " +
                "WHERE([רשימת מנויים].[תעודת זהות] = '" + id +" ')" +
                " AND([זכיות למנויים].[עיון ההלכה] = True) " +
                "OR ([רשימת מנויים].[תעודת זהות] = '" + id + "') " +
                "AND([זכיות למנויים].[עיון ההלכה תשובות] < 0) " +
                "ORDER BY[זכיות למנויים].[קוד גליון] DESC";
        }        
        
        

    }
}
