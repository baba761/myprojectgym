using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using myprojectgym.DTO.DTOGYM;
using myprojectgym.DTO.DTOUAC;
using myprojectgym.Utility;

namespace myprojectgym.DAL.DALGym
{

    public class DALGym : IDALGym
    {
        private readonly Isqlhelper sqlhelper;
        public DALGym(Isqlhelper isqlhelper)
        {
            sqlhelper = isqlhelper;
        }

        public void addgym(DTOGym obj)
        {
            SortedList li = new SortedList();
            li.Add("@GymName",obj.GymName);
            li.Add("@Email", obj.Email);
            li.Add("@CountryId",obj.CountryId);
            li.Add("@StateId", obj.StateId);
            li.Add("@PostalCode", obj.PostalCode);
            li.Add("@Address1", obj.Address1);
            li.Add("@Address2", obj.Address1);
            li.Add("@ContactInfo", obj.ContactInfo);
            li.Add("@Phone",obj.Phone);
            li.Add("@Fax", obj.Fax);
            using (IDataReader dataReader = sqlhelper.ExecuteReader("APP.spAddnewGym", li));
        }

    }
}
