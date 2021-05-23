using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myprojectgym.DAL.DALGym;
using myprojectgym.DAL.DALRegistration;
using myprojectgym.DTO.DTORegistration;

namespace myprojectgym.Controllers
{
    
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IDALRegistration dALRegistration; 
        public RegistrationController(IDALRegistration DALRegistration)
        {
            dALRegistration = DALRegistration;
        }
        [HttpPost]
        [Route("api/Registration/SaveRegistration")]
        public int SaveRegistration(DTORegistration Registration )
        {
            return dALRegistration.SaveRegistreation(Registration);
        }
    }
}
