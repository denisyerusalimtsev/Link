using System.Threading.Tasks;
using Link.EmailManagement.Domain.Model.Entities;

namespace Link.EmailManagement.Domain.Services.Interfaces
{
    public interface IMailBox
    {
        Task Send(Email mail);
    }
}
