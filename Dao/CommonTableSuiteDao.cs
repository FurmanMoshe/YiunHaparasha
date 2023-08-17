namespace YiunHa.Dao
{
    public class CommonTableSuiteDao
    {
        public string GetShovarAndTlushById(int id)
        {
            return "SELECT [ברקוד שובר], [תלוש1 השתתפות], [תלוש2 השתתפות], [תלוש3 השתתפות], [זכיות1 השתתפות], [זכיות2 השתתפות] " +
                "FROM[טבלה משותפת חליפות]"+ 
                "WHERE([תעודת זהות]" +
                " = '" + id + "')";
        }        
        
    }
}
