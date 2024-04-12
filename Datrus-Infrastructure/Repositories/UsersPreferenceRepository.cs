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
    public class UsersPreferenceRepository : IUsersPreference
    {

        private readonly DatusDatingDb _db;

        public UsersPreferenceRepository(DatusDatingDb db) {
            _db = db;
        }

        public async Task Add(UserPreferences entity)
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

        public Task<IEnumerable<UserPreferences>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserPreferences?> GetByClientId(object clientId)
        {
            return await _db.UsersPreferences.FirstOrDefaultAsync(x => x.ClientId.Equals(clientId));
        }

        public async Task<UserPreferences> GetById(object id)
        {
            return await _db.UsersPreferences.FirstOrDefaultAsync(x => x.UserPreferenceId.Equals(id));
        }

        public async Task<UserPreferences> Update(UserPreferences entity)
        {
            try
            {
                UserPreferences existingPref = await GetById(entity.UserPreferenceId);

                if(existingPref != null)
                {
                    _db.Entry(existingPref).CurrentValues.SetValues(entity);
                    await _db.SaveChangesAsync();
                    return existingPref;
                }
                else
                {
                    return null;
                }
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
