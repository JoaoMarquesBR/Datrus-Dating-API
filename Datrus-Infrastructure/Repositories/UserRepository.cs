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

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetById(object id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.ClientId.Equals(id));
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
