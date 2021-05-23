using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myprojectgym.DTO.DTORegistration
{
    public class DTORegistration
    {
        public int RegistrationId { get; set; }
        public int GymId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string City { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string ContectInfo { get; set; }
        public string Address { get; set; }
        public List<WorkOutType> WorkType { get; set; }
        public int PlanId { get; set; }
        public int Counter { get; set; }
        public int RegistrationNo { get; set; }
        public int TotalAmmount { get; set; }
        public int DiscountType { get; set; }
        public int DisCount { get; set; }
        public int PayableAmount { get; set; }
        public int PaidAmount { get; set; }
        public int Balance { get; set; }
    }

    public class WorkOutType
    {
        public int WorkOutTypeId { get; set; }
        public string WorkOutTypeName { get; set; }
        
    }
        
}                    
                  	
                  	