using Datrus_Contracts.Requests;
using Datrus_Domain.Entities;

namespace Datrus_Application.IServices
{
    public interface IUserService : IGenericService<User>
    {
        Task Match(User userSender, User userReceiver);

        Task SendLike(SendLikeRequest req);

        Task SetPreferences(SetPreferencesRequest req);

    }
}
