using Datrus_Application.IRepositories;
using Datrus_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Infrastructure.Repositories
{
    public class UsersMatchRepository : IMatchRepository
    {

        private readonly DatusDatingDb _db;

        public UsersMatchRepository(DatusDatingDb db) {
            _db = db;
        }

        public async Task Add(UsersMatch entity)
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

        public Task<IEnumerable<UsersMatch>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UsersMatch> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<UsersMatch> Update(UsersMatch entity)
        {
            throw new NotImplementedException();
        }
    }
}
