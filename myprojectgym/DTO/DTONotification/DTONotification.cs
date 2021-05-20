using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myprojectgym.DTO.DTONotification
{
    public class DTONotification
    {
        public string SenderAddress { get; set; }
        public string SenderDisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public bool UseDefaultCredential { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
