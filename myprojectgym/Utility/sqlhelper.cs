using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace myprojectgym.Utility
{
    public class sqlhelper : Isqlhelper
    {
        private readonly IConfiguration _configuration;
        public sqlhelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlDataReader ExecuteReader(string sp, SortedList ls)
        {
            string CS = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(CS);
            SqlDataReader dr;
            SqlCommand cmd = returncommandForStoreProc(sp, ls);
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;

        }
        private SqlCommand returncommandForStoreProc(string name, SortedList list)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = name;
            cmd.CommandType = CommandType.StoredProcedure;
            if (list != null)
            {
                cmd.Parameters.Clear();
                foreach (string li in list.Keys)
                {
                    cmd.Parameters.AddWithValue(li, list[li]);
                }
            }
            return cmd;
        }
    }
}
