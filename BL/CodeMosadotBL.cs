using Microsoft.Data.SqlClient;
using YiunHa.Dao;

namespace YiunHa.BL
{
    public class CodeMosadotBL : SqlDatabaseConnector
    {
        private CodeMosadotDao codeMosadotDao = new CodeMosadotDao();

        public User HandleNewMosadIfNeeded(User user)
        {
            if (user.NewMosad != null)
            {
                int code = GetCodeMosadOr0(user.NewMosad);
                if (code == 0)
                {
                    int newCode = GetCodeForNewMosad();
                    int type = user.Status == 1 ? 3 : 2;

                    OpenConnection(codeMosadotDao.InsertNewMosad(user.NewMosad, newCode, type));

                    return UpdateCodeMosad(user, newCode);
                }
                return UpdateCodeMosad(user, code);
            }
            return user;
        }

        private User UpdateCodeMosad(User user, int code)
        {
            if (user.Status == 1)
                user.CodeColel = code;
            else
                user.CodeYeshiva = code;
            return user;
        }

        private int GetCodeMosadOr0(string newIshuv)
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(codeMosadotDao.GetCodeMosad(newIshuv));
            if (reader.Read())
            {
                int code = reader.GetInt32(0);
                connection.Close();
                return code;
            }
            connection.Close();
            return 0;
        }

        private int GetCodeForNewMosad()
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(codeMosadotDao.GetMaxCodeMosad());
            reader.Read();
            int maxCode = reader.GetInt32(0) + 1;
            connection.Close();
            return maxCode;
        }

    }
}
