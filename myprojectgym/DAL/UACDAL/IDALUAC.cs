using System.Collections.Generic;
using myprojectgym.DTO.DTOUAC;

namespace myprojectgym.DAL.UACDAL
{
    public interface IDALUAC
    {
        
        List<DTOUAC> allUsers();
        string Userregistration(DTOUAC user);
        int UserLogin(DTOUAC user);
        List<DTOUACSubscribeModule> BindModule(DTOGetPages obj);
        List<UACPages> Pages(DTOGetPages obj);

    }
}