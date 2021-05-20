using System.Collections;
using System.Data.SqlClient;

namespace myprojectgym.Utility
{
    public interface Isqlhelper
    {
        SqlDataReader ExecuteReader(string sp, SortedList ls);
    }
}