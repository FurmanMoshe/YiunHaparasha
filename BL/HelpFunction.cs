using Microsoft.Data.SqlClient;

namespace YiunHa.BL
{
    public class HelpFunction
    {
        public int? GetIntValueOrNull(int index, SqlDataReader reader)
        {
            if (reader.IsDBNull(index))
            {
                return null;
            }
            return reader.GetInt32(index);
        }

        public double? GetDoubleValueOrNull(int index, SqlDataReader reader)
        {
            if (reader.IsDBNull(index))
            {
                return null;
            }
            return reader.GetDouble(index);
        }

        public string GetStringValueOrNull(int index, SqlDataReader reader)
        {
            if (reader.IsDBNull(index))
            {
                return null;
            }
            return reader.GetString(index);
        }

        public int? GetByteValueOrNull(int index, SqlDataReader reader)
        {
            if (reader.IsDBNull(index))
            {
                return null;
            }
            return reader.GetByte(index);
        }
    }
}
