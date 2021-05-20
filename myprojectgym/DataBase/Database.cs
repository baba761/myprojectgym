using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace myprojectgym.DataBase
{
    public class Database
    {
        private readonly IConfiguration _configuration;

        public Database(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //public string InsertData(Customer objcust)
        //{
        //    string result = "";
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        //        SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        //cmd.Parameters.AddWithValue("@CustomerID", 0);    
        //        cmd.Parameters.AddWithValue("@Name", objcust.Name);
        //        cmd.Parameters.AddWithValue("@Address", objcust.Address);
        //        cmd.Parameters.AddWithValue("@Mobileno", objcust.Mobileno);
        //        cmd.Parameters.AddWithValue("@Birthdate", objcust.Birthdate);
        //        cmd.Parameters.AddWithValue("@EmailID", objcust.EmailID);
        //        cmd.Parameters.AddWithValue("@Query", 1);
        //        con.Open();
        //        result = cmd.ExecuteScalar().ToString();
        //        return result;
        //    }
        //    catch
        //    {
        //        return result = "";
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
    }
}
