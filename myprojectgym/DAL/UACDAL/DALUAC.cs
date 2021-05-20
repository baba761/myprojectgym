using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using myprojectgym.DTO.DTOUAC;
using myprojectgym.DAL.DALNotification;

namespace myprojectgym.DAL.UACDAL
{
    public class DALUAC : IDALUAC
    {
        private readonly IConfiguration _configuration;
        public DALUAC(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<DTOUAC> allUsers()
        {
            List<DTOUAC> users = new List<DTOUAC>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("select * from UAC.tbUsers", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTOUAC USER = new DTOUAC();
                USER.FullName = dt.Rows[i]["FirstName"].ToString();
                USER.Email = dt.Rows[i]["LastName"].ToString();
                users.Add(USER);
            }
            return users;
        }
        public string Userregistration(DTOUAC user)
        {
            string CS = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("UAC.spAdminRegistration", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GymId", user.GymId);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@City", user.City);
                cmd.Parameters.AddWithValue("@PostalCode", user.Postalcode);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@ContactInfo", user.ContactInfo);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                SqlParameter OutputParameter = new SqlParameter();
                OutputParameter.ParameterName = "@Return";
                OutputParameter.SqlDbType = SqlDbType.Int;
                OutputParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(OutputParameter);
                conn.Open();
                cmd.ExecuteNonQuery();
                return OutputParameter.Value.ToString();

            }
        }

        int IDALUAC.UserLogin(DTOUAC user)
        {
            try
            {
                string CS = _configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection conn = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("UAC.spLogin", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    SqlParameter OutputParameter = new SqlParameter();
                    OutputParameter.ParameterName = "@Return";
                    OutputParameter.SqlDbType = SqlDbType.Int;
                    OutputParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(OutputParameter);
                    conn.Open();
                    cmd.ExecuteReader();
                    string status = OutputParameter.Value.ToString();
                    return Convert.ToInt32(status);

                }
            }
            catch (Exception EX)
            {

                throw;
            }
        }
        

        List<DTOUACSubscribeModule> IDALUAC.BindModule(DTOGetPages obj)
        {
            List<DTOUACSubscribeModule> pm = new List<DTOUACSubscribeModule>();
            List<DTOUACModule> m = new List<DTOUACModule>();
            List<DTOUACPages> p = new List<DTOUACPages>();

            string CS = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection conn = new SqlConnection(CS))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UAC.spBindSuscribeModule", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", obj.uid);
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    pm.Add(new DTOUACSubscribeModule
                    {
                        ParentModuleId = Convert.ToInt32(dr["ModuleId"]),
                        ParentMoudleName = dr["ModuleName"].ToString(),
                    });
                }
                dr.NextResult();
                while (dr.Read())
                {
                    m.Add(new DTOUACModule
                    {
                        ModuleId = Convert.ToInt32(dr["ModuleId"]),
                        ParentModuleId = Convert.ToInt32(dr["ParentModuleId"]),
                        MoudleName = dr["ModuleName"].ToString(),
                    });
                }
                dr.NextResult();
                while (dr.Read())
                {
                    p.Add(new DTOUACPages
                    {
                        PageId = Convert.ToInt32(dr["PageId"]),
                        ModuleId= Convert.ToInt32(dr["ModuleId"]),
                        PageName = dr["PageName"].ToString(),
                    });
                }
                foreach (DTOUACSubscribeModule item in pm)
                {
                    item.modules = m.Where(x => x.ParentModuleId == item.ParentModuleId).ToList();

                    foreach (DTOUACModule items in m)
                    {
                        items.page = p.Where(x => x.ModuleId == items.ModuleId).ToList();
                    }
                }

                return pm;
            }
        }

        public List<UACPages> Pages(DTOGetPages obj)
        {
           
            List<UACPages> p = new List<UACPages>();

            string CS = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection conn = new SqlConnection(CS))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UAC.spBindSuscribePages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", obj.uid);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    p.Add(new UACPages
                    {
                         
                         PageName= dr["PageName"].ToString(),
                    });
                }
                
                return p;
            }
        }
    }
}