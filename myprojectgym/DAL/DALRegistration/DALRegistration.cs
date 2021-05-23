using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using myprojectgym.DTO.DTORegistration;
using myprojectgym.Utility;

namespace myprojectgym.DAL.DALRegistration
{
    public class DALRegistration : IDALRegistration
    {
       
        private readonly Isqlhelper sqlhelper;
        public DALRegistration(Isqlhelper Sqlhelper)
        {
            sqlhelper = Sqlhelper;
        }

        public int SaveRegistreation(DTORegistration Registration)
        {
            try
            {
                SortedList li = new SortedList();
                li.Add("@RegistationId", 1);
                li.Add("@GymId", 1);
                li.Add("@FirstName", Registration.FirstName);
                li.Add("@LastName", Registration.LastName);
                li.Add("@CountryId", Registration.CountryId);
                li.Add("@StateId", Registration.StateId);
                li.Add("@City", Registration.City);
                li.Add("@DateOfJoining", Registration.DateOfJoining);
                li.Add("@DateOfBirth", Registration.DateOfJoining);
                li.Add("@Age", Registration.Age);
                li.Add("@Gender", Registration.Gender);
                li.Add("@Email", Registration.Email);
                li.Add("@ContectInfo", Registration.ContectInfo);
                li.Add("@Address", Registration.Address);
                //li.Add("@WorkType", Registration.WorkType);
                li.Add("@PlanId", Registration.PlanId);
                //li.Add("@Counter", Registration.Counter);
                //li.Add("@RegistrationNo",Registration.GymId);
                li.Add("@TotalAmmount", Registration.TotalAmmount);
                li.Add("@DiscountType", Registration.DiscountType);
                li.Add("@DisCount", Registration.DisCount);
                li.Add("@PaidAmount", Registration.PaidAmount);
                using (IDataReader dataReader = sqlhelper.ExecuteReader("GYM.spSaveGymRegistration", li)) ;
            }
            catch (Exception ex)
            {

                
            }
            
            return 1;
        }
    }
}
