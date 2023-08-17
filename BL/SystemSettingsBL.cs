using YiunHa.Dao;
using Microsoft.Data.SqlClient;

namespace YiunHa.BL
{
    public class SystemSettingsBL : SqlDatabaseConnector
    {
        private SystemSettingsDao systemSettingsDao = new SystemSettingsDao();

        public string GetWrongCodeMassege()
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(systemSettingsDao.GetWrongCodeMassege());
            reader.Read();
            string msg = reader.GetString(0);
            connection.Close();
            return msg;
        }

        public bool CanChangeFoodChain(UserDto user)
        {
            if (user.Status == 1)
            {
                bool empty = user.FoodChainCode == null;
                SqlDataReader reader = OpenConnectionAndReturnReader(systemSettingsDao.GetCanChangeFoodChain());
                reader.Read();
                bool CanChangeFoodChain = reader.GetBoolean(0); ;
                bool CanChangeFoodChainForEmpties = reader.GetBoolean(1); ;
                connection.Close();
                return CanChangeFoodChain || (empty && CanChangeFoodChainForEmpties);
            }
            return false;
        }

        public string[] GetSystemSettingsData()
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(systemSettingsDao.GetDataFromSystemSettingTable());
            reader.Read();

            string systemMassege = reader.GetString(0);
            string milgaTitle = reader.GetString(1);
            string milgaValidity = reader.GetDateTime(2).ToString("dd/MM/yyyy");
            string answerTitle = reader.GetString(3);
            string answerTitleForHalacha = reader.GetString(4);

            connection.Close();
            return new string[] { systemMassege, milgaTitle, answerTitle,
                answerTitleForHalacha, milgaValidity};
        }
    }
}
