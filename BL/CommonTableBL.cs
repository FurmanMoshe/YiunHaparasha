using System;
using YiunHa.Dao;
using Microsoft.Data.SqlClient;

namespace YiunHa.BL
{
    public class CommonTableBL : SqlDatabaseConnector
    {
        private CommonTableDao commonTableDao = new CommonTableDao();

        public Nullable<double> GetLastMilga(int id)
        {
            Nullable<double> lastMilga = null;
            SqlDataReader reader = OpenConnectionAndReturnReader(commonTableDao.GetLastMilga(id));
            if (reader.Read())
            {
                lastMilga = reader.GetDouble(0);
            }
            connection.Close();
            return lastMilga;
        }

    }
}
