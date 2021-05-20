using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using myprojectgym.DTO.DTOUAC;

namespace myprojectgym.DAL.CountryDAL
{

    public class CountryDAL : ICountryDAL
    {
        private readonly IConfiguration _Configuration;

        public CountryDAL(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        public List<DTOUAC> allUsers()
        {
            List<DTOUAC> users = new List<DTOUAC>();
            SqlConnection con = new SqlConnection(_Configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("select * from UAC.tbUsers", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTOUAC USER = new DTOUAC();
                USER.FullName= dt.Rows[i]["FirstName"].ToString();
                USER.Email = dt.Rows[i]["LastName"].ToString();
                users.Add(USER);
            }
            return users;
        }

    }
}
