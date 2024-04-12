using Datrus_Application.IRepositories;
using Datrus_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Infrastructure.Repositories
{
    public class LikesSentRepository : ILikesSentRepository
    {

        private readonly DatusDatingDb _db;

        public LikesSentRepository(DatusDatingDb db) {
            _db = db;
        }

        public async Task Add(LikesSent entity)
        {
            try
            {
                await _db.AddAsync(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public Task<IEnumerable<LikesSent>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<LikesSent> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<LikesSent> Update(LikesSent entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> WasLikeAlreadySent(string fromUserA, string toUserB) { 
            var obj = await _db.LikesSent.FirstOrDefaultAsync(x => x.FromClientId.Equals( fromUserA )&& x.ToClientId.Equals(toUserB));

            if(obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
