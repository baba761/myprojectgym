using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myprojectgym.DAL.DALGym;
using myprojectgym.DTO.DTOGYM;
using myprojectgym.DTO.DTOUAC;
using myprojectgym.Utility;

namespace myprojectgym.Controllers
{

    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly IDALGym dALGym;
        public GymController(IDALGym DALGym)
        {
            dALGym = DALGym;
        }
        [HttpPost, Route("api/Gym/addgym")]

        public int addgym(DTOGym obj)
        {
            dALGym.addgym(obj);
            int num = 0;
            return num;
        }
    }
}
