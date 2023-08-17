using Microsoft.Data.SqlClient;
using System;
using YiunHa.Dao;

namespace YiunHa.BL
{
    public class UserBL : SqlDatabaseConnector
    {
        private UserDao userDao = new UserDao();
      
        public bool IsTZExists(int id)
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(userDao.GetUserByTZ(id));
            bool exists = reader.Read();
            connection.Close();
            return exists;
        }

        public bool VerifyCodeManuyByTZ(int id, int code)
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(userDao.GetUserByTZAndCodeManuy(id, code));
            bool exists = reader.Read();
            connection.Close();
            return exists;
        }

        public int GetCodeManuyByTZ(int id)
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(userDao.GetUserByTZ(id));
            reader.Read();
            int code = reader.GetInt32(0);
            connection.Close();
            return code;
        }

        public UserDto GetUserByTZ(int id)
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(userDao.GetUserDetailesByTZ(id));
            reader.Read();
            UserDto user = CreateUser(reader);
            connection.Close();
            return user;
        }

        private UserDto CreateUser(SqlDataReader reader)
        {
            UserDto user = new UserDto();
            user.TZ = int.Parse(reader.GetString(0));
            user.LastName = reader.GetString(1);
            user.FirstName = reader.GetString(2);
            user.Street = reader.GetString(3);
            user.StreetNum = helpFunction.GetIntValueOrNull(4, reader);
            user.HomeNum = helpFunction.GetIntValueOrNull(5, reader);
            user.Mikud = helpFunction.GetIntValueOrNull(6, reader);
            user.MailBox = helpFunction.GetIntValueOrNull(7, reader);
            user.PhoneNum = helpFunction.GetStringValueOrNull(8, reader);
            user.MobilePhoneNum = helpFunction.GetStringValueOrNull(9, reader);
            user.BankNum = helpFunction.GetByteValueOrNull(10, reader);
            user.BankBranchNum = helpFunction.GetIntValueOrNull(11, reader);
            user.BankAccount = helpFunction.GetIntValueOrNull(12, reader);
            user.ChildrenNum = helpFunction.GetByteValueOrNull(13, reader);
            user.MarriedChildrenNum = helpFunction.GetByteValueOrNull(14, reader);
            user.Status = reader.GetByte(19);
            user.CodeMosad = GetCodeMosad(reader, user);
            user.FoodChainCode = helpFunction.GetByteValueOrNull(17, reader);
            user.CodeIshuv = helpFunction.GetIntValueOrNull(18, reader);

            return user;
        }

        public object[] GetFoodChainInfo(int id)
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(userDao.GetFoodChainInfoByTZ(id));
            reader.Read();

            Nullable<int> foodChain = helpFunction.GetByteValueOrNull(0, reader);
            Nullable<double> foodChainBarkod1 = GetCodeForFoodChain(foodChain, reader);
            Nullable<double> foodChainBarkod2 = GetCodeForFoodChain2(foodChain, reader);

            connection.Close();
            return new object[] { foodChain, foodChainBarkod1, foodChainBarkod2 };
        }

        private Nullable<double> GetCodeForFoodChain(Nullable<int> foodChain, SqlDataReader reader)
        {
            if (foodChain == 2)
            {
                return helpFunction.GetDoubleValueOrNull(1, reader);
            }
            if (foodChain == 5)
            {
                return helpFunction.GetIntValueOrNull(2, reader);
            }
            if (foodChain == 4)
            {
                return helpFunction.GetDoubleValueOrNull(3, reader);
            }
            else
                return null;
        }

        private Nullable<double> GetCodeForFoodChain2(Nullable<int> foodChain, SqlDataReader reader)
        {
            if (foodChain == 4)
                return helpFunction.GetDoubleValueOrNull(4, reader);
            return null;
        }

        public int CreateNewUser(User user)
        {
            user.Code = GetCodeForNewUser();
            int rowAffected = OpenConnection(userDao.InsertNewUser(user));
            return rowAffected == 1 ? user.Code : 0;
        }

        public void UpdateExistsUser(User user)
        {
            User updatedUser = HandleChangeStatusAndCFRM(user);
            OpenConnection(userDao.UpdateUser(updatedUser));
        }

        private User HandleChangeStatusAndCFRM(User user)
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(userDao.GetUserStatusDateAndFoodChainCodeByTZ(user.TZ));
            reader.Read();

            int oldStatus = reader.GetByte(0);
            DateTime oldDate = reader.GetDateTime(1);
            Nullable<double> codeForReshetMazon = helpFunction.GetDoubleValueOrNull(2, reader);
            Nullable<int> codeForMaayan = helpFunction.GetIntValueOrNull(3, reader);

            connection.Close();

            if (oldStatus != user.Status) { user.EnterDate = DateTime.Now; }
            else { user.EnterDate = oldDate; }
            if (codeForReshetMazon == null) { user.CodeForReshetMazon = GetCodeForReshetMazon(user); }
            else { user.CodeForReshetMazon = codeForReshetMazon; }
            if (codeForMaayan == null) { user.CodeForMaayan = GetCodeForMaayan(user); }
            else { user.CodeForMaayan = codeForMaayan; }
            return user;
        }

        private int GetCodeForNewUser()
        {
            SqlDataReader reader = OpenConnectionAndReturnReader(userDao.GetCodeForNewUser());
            reader.Read();
            int maxCode = reader.GetInt32(0);
            connection.Close();

            return maxCode + 1;
        }

        public Nullable<double> GetCodeForReshetMazon(User user)
        {
            if (user.FoodChainCode == 2)
            {
                SqlDataReader reader = OpenConnectionAndReturnReader(userDao.GetCodeForReshetMazon());
                reader.Read();
                double code = reader.GetDouble(0) + 1;
                bool codeSameMaxCode = !reader.Read();
                connection.Close();

                if (!codeSameMaxCode)
                    return code;
            }
            return null;
        }

        public Nullable<int> GetCodeForMaayan(User user)
        {
            if (user.FoodChainCode == 5)
            {
                return Int32.Parse("4192" + user.TZ.ToString().Substring(0, 4));
            }
            return null;
        }

        private Nullable<int> GetCodeMosad(SqlDataReader reader, UserDto user)
        {
            if (user.Status == 1)
            {
                return helpFunction.GetIntValueOrNull(15, reader);
            }
            return helpFunction.GetIntValueOrNull(16, reader);
        }

    }
}
