using System.Collections.Generic;
using YiunHa.Dao;
using Microsoft.Data.SqlClient;


namespace YiunHa.BL
{
    public class MenuimWinningsBL : SqlDatabaseConnector
    {
        private MenuimWinningsDao menuimWinningsDao = new MenuimWinningsDao();

        public List<int> GetAnswersToGilun(int id)
        {
            List<int> list = new List<int>();
            SqlDataReader reader = OpenConnectionAndReturnReader(menuimWinningsDao.GetSystemAnswersToGilun(id));
            for (int i = 0; reader.Read(); i++)
            {
                list.Add(reader.GetInt32(0));
            }
            connection.Close();
            return list;
        }

        public List<int> GetSystemHalachaAnswersToGilun(int id)
        {
            List<int> list = new List<int>();
            SqlDataReader reader = OpenConnectionAndReturnReader(menuimWinningsDao.GetSystemHalachaAnswersToGilun(id));
            for (int i = 0; reader.Read(); i++)
            {
                list.Add(reader.GetInt32(0));
            }
            connection.Close();
            return list;
        }

    }
}
