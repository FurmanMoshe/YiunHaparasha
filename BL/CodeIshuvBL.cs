using Microsoft.Data.SqlClient;
using YiunHa.Dao;

namespace YiunHa.BL
{
    public class CodeIshuvBL : SqlDatabaseConnector
    {
        private CodeIshuvDao codeIshuvDao = new CodeIshuvDao();

        public User HandleNewIshuvIfNeeded(User user)
        {
            if (user.NewIshuv != null)
            {
                int code = GetCodeIshuvOr0(user.NewIshuv);
                if (code == 0)
                {
                    int newCode = GetCodeForNewIshuv();

                    OpenConnection(codeIshuvDao.InsertNewIshuv(user.NewIshuv, newCode));

                    user.CodeIshuv = newCode;
                    return user;
                }
                user.CodeIshuv = code;
                return user;
            }
            return user;
        }

        private int GetCodeForNewIshuv()
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(codeIshuvDao.GetMaxCodeIshuv());
            reader.Read();
            int maxCode = reader.GetInt32(0) + 1;
            connection.Close();
            return maxCode;
        }

        private int GetCodeIshuvOr0(string newIshuv)
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(codeIshuvDao.GetCodeIshuv(newIshuv));
            if (reader.Read())
            {
                int code = reader.GetInt32(0);
                connection.Close();
                return code;
            }
            connection.Close();
            return 0;
        }

    }
}
