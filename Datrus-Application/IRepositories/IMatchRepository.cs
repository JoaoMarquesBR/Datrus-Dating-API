using Datrus_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Application.IRepositories
{
    public interface IMatchRepository : IGenericRepository<UsersMatch>
    {
        Task<IEnumerable<UsersMatch>> GetByClientId(object clientId);
    }
}
