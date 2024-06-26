﻿using Castle.Components.DictionaryAdapter.Xml;
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

        public async Task<User> Update(User entity)
        {
            try
            {
                User existingEntity = await GetById(entity.ClientId);

                if (existingEntity != null)
                {
                    _db.Entry(existingEntity).CurrentValues.SetValues(entity);
                    await _db.SaveChangesAsync();
                    return existingEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<User>> GetUserByPreference(UserPreferences pref, IEnumerable<LikesSent>likesSent)
        {
            //get all the users that meet his criteria
            IEnumerable<User> test = await _db.Users.Where(x=>x.Age >= pref.MinAge && x.Age<= pref.MaxAge).ToListAsync();

            //get all likes user already sent (so they dont appear again)
            IEnumerable<LikesSent> likesSentByUser = likesSent;
            IEnumerable<string> clientsId = likesSentByUser.Select(x => x.ToClientId);

            //filtering likes already sent 
            IEnumerable<User> filteredList = test.Where(x => string.Equals(x.Gender, pref.Gender, StringComparison.OrdinalIgnoreCase)).ToList();
            
            IEnumerable<User> finalList = filteredList.Where(x => !clientsId.Contains(x.ClientId));

            return finalList;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}
