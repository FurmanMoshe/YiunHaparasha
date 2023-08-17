using System;
using YiunHa.Dao;
using Microsoft.Data.SqlClient;

namespace YiunHa.BL
{
    public class CommonTableSuiteBL : SqlDatabaseConnector
    {
        private CommonTableSuiteDao commonTableSuiteDao = new CommonTableSuiteDao();

        public int?[] GetShovarBigud(int id)
        {
            Nullable<int> shovar = null, shovarBarkod = null;
            SqlDataReader reader = OpenConnectionAndReturnReader(commonTableSuiteDao.GetShovarAndTlushById(id));
            if (reader.Read())
            {
                shovar = helpFunction.GetIntValueOrNull(0, reader);
                shovarBarkod = GetShovarBarkod(reader);
            }
            connection.Close();
            return new int?[] { shovar, shovarBarkod };
        }

        private Nullable<int> GetShovarBarkod(SqlDataReader reader)
        {
            for (int i = 1; i < 5; i++)
            {
                if (!reader.IsDBNull(i))
                    return reader.GetInt32(i);
            }
            return null;
        }

    }
}
