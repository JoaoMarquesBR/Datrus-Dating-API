using Datrus_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Application.IRepositories
{
    public interface IUsersPreference : IGenericRepository<UserPreferences>
    {
        Task<UserPreferences?> GetByClientId(object clientId);

    }
}
