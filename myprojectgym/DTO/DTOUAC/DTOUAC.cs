using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myprojectgym.DTO.DTOUAC
{
    public class apires
    {
        public int data { get; set; }
        public string status { get; set; }
        public string massage { get; set; }
    }
    public class DTOUAC
    {
        public string GymId { get; set; }
        public string ProfileId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Postalcode { get; set; }
        public string Password { get; set; }
        public string ContactInfo { get; set; }
        public string Address { get; set; }

    }
   
    public class DTOUACPages
    {
        public int PageId { get; set; }
        public int ModuleId { get; set; }
        public string PageName { get; set; }

    }
    public class UACPages
    {
        
        public string PageName { get; set; }

    }

    public class DTOUACModule
    {
        public int ModuleId { get; set; }
        public int ParentModuleId { get; set; }
        public string MoudleName { get; set; }

        public List<DTOUACPages> page { get; set; }
    }

    public class DTOUACSubscribeModule
    {
        public int ParentModuleId { get; set; }
        public string ParentMoudleName { get; set; }

        public List<DTOUACModule> modules { get; set; }
    }
    public class DTOGetPages
    {
        public string uid { get; set; }
        public string tst { get; set; }
    }
}
