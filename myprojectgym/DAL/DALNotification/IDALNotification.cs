using System.Threading.Tasks;
using myprojectgym.DTO.DTONotification;

namespace myprojectgym.DAL.DALNotification
{
    public interface IDALNotification
    {
        Task SendTestEmail(UserEmailOptions userEmail);
    }
}