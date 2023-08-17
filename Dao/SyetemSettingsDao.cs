namespace YiunHa.Dao
{
    public class SystemSettingsDao
    {
        public string GetDataFromSystemSettingTable()
        {
            return "SELECT [הודעה לנדרים], מלגה, [תוקף המלגות], [כותרת לגליונות], [כותרת לעיון ההלכה] " +
                "FROM [הגדרות מערכת]";
        }

        public string GetCanChangeFoodChain()
        {
            return "SELECT [האם אפשר לשנות רשת], [האם אפשר לשנות רשת לריקים] " +
                "FROM[הגדרות מערכת]";
        }           
        
        public string GetWrongCodeMassege()
        {
            return "SELECT [הודעה לקוד מנוי שגוי] " +
                "FROM[הגדרות מערכת]";
        }        
      

    }
}
