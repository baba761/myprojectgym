using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myprojectgym.ApiResponse
{
    public class ApiResponse : IApiResponse
    {
        public string massage { get; set; }
        public object data { get; set; }
    }
}
