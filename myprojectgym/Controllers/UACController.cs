using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myprojectgym.ApiResponse;
using myprojectgym.DAL.DALNotification;
using myprojectgym.DAL.UACDAL;
using myprojectgym.DTO.DTONotification;
using myprojectgym.DTO.DTOUAC;

namespace myprojectgym.Controllers
{

    [ApiController]
    public class UACController : ControllerBase
    {
        private readonly IDALUAC _dALUAC = null;
        private readonly IDALNotification _dalNotification;

        public HttpResponse _apiresponse { get; }

        public UACController(IDALUAC dALUAC,
            IDALNotification dALNotification
           
            )
        {
            _dALUAC = dALUAC;
            _dalNotification = dALNotification;
           
        }
        [HttpGet, Route("api/UAC/allemp")]
        public List<DTOUAC> allemp()
        {
            return _dALUAC.allUsers();
        }
        [HttpPost, Route("api/UAC/userregistration")]
        public string Userregistration(DTOUAC user)
        {
            
            string result = _dALUAC.Userregistration(user);
            //int status = Convert.ToInt32(result);
            ////if (status == 1)
            //{
            //    UserEmailOptions options = new UserEmailOptions
            //    {
            //        ToEmails = new List<string> { "test@Mail.com" }
            //    };
            //    _dalNotification.SendTestEmail(options);

            //}
            return result;
        }

        [HttpPost, Route("api/UAC/UserLogin")]
        public object UserLogin(DTOUAC user)
        {
            int result=0;
            result = _dALUAC.UserLogin(user);
            if (result != -1)
            {
                return new
                {
                    data = result,
                    massage = "ok",
                    status="true"
                };
            }
           else
            {
                return new
                {
                    data = result,
                    massage = "not ok",
                    status = "false"
                };
            }
        }
        [HttpPost, Route("api/UAC/BindModule")]
        public List<DTOUACSubscribeModule> BindModule(DTOGetPages obj)
        {
            return _dALUAC.BindModule(obj);
            
        }

        [HttpPost, Route("api/UAC/Pages")]
        public List<UACPages> Pages(DTOGetPages obj)
        {
            return _dALUAC.Pages(obj);

        }

    }
}
