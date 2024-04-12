using Datrus_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Application.IRepositories
{
    public interface ILikesSentRepository : IGenericRepository<LikesSent>
    {

        Task<bool> WasLikeAlreadySent(string fromUserA, string toUserB);

        Task<IEnumerable<LikesSent>> GetLikesSentByClientId(object clientId);
    }
}
