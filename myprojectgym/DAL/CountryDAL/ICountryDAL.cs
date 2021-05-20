using System.Collections.Generic;
using myprojectgym.DTO.DTOUAC;

namespace myprojectgym.DAL.CountryDAL
{
    public interface ICountryDAL
    {
        List<DTOUAC> allUsers();
    }
}