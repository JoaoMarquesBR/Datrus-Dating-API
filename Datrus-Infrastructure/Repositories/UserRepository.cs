using Datrus_Application.IRepositories;
using Datrus_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DatusDatingDb _db;

        public UserRepository(DatusDatingDb db) {
            _db = db;
        }

        public async Task Add(User entity)
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

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
