using Datrus_Contracts.Requests;
using Datrus_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Application.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetUserByPreference(UserPreferences pref, IEnumerable<LikesSent> likesSent);

        Task<User> GetByEmail(string email);
    }
}
