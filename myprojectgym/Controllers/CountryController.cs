using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myprojectgym.DAL.CountryDAL;
using myprojectgym.DTO.DTOUAC;

namespace myprojectgym.Controllers
{
   
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryDAL _countryDAl;

        public CountryController(ICountryDAL countryDAL)
        {
            _countryDAl = countryDAL;
        }
        [HttpGet, Route("api/Country/allcountry")]
        public List<DTOUAC> allcountry()
        {
            return _countryDAl.allUsers();
        }
    }
}
