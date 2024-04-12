using Datrus_Application.IRepositories;
using Datrus_Application.IServices;
using Datrus_Contracts.Requests;
using Datrus_Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Application.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepo;
        public readonly IMatchRepository _matchRepo;
        public readonly ILikesSentRepository _likesSentRepo;
        public readonly IUsersPreference _preferences;


        public UserService(IUsersPreference userPref, IUserRepository userRepo, ILikesSentRepository likeSentRepo, IMatchRepository matchRepo)
        {
            _userRepo = userRepo;
            _matchRepo = matchRepo;
            _likesSentRepo = likeSentRepo;
            _preferences = userPref;
        }

        public Task Add(User entity)
        {
            return _userRepo.Add(entity);
        }



        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepo.GetAll();
        }

        public async Task<User> GetById(object id)
        {
            return await _userRepo.GetById(id);
        }

        public Task Match(User userSender, User userReceiver)
        {
            UsersMatch usersMatch = new UsersMatch();

            usersMatch.UserA = userSender.ClientId;
            usersMatch.UserB = userReceiver.ClientId;
            usersMatch.Date = DateTime.Now;

            return _matchRepo.Add(usersMatch);
        }


        public async Task SendLike(SendLikeRequest req)
        {
            LikesSent likesSent = new LikesSent();
            likesSent.FromClientId = req.senderId;
            likesSent.ToClientId = req.receiverId;
            likesSent.Date = DateTime.Now;
            likesSent.LikeType = "Normal";

            //does receiver already sent a like for the sender? if yes, its a match
            if (await _likesSentRepo.WasLikeAlreadySent(req.receiverId, req.senderId))
            {
                //also register the like sent for data anylsys purposes
                await _likesSentRepo.Add(likesSent);

                UsersMatch match = new UsersMatch();
                match.Date = DateTime.UtcNow;
                match.UserA = req.receiverId;//userA is the one that liked first!
                match.UserB = req.senderId;

                await _matchRepo.Add(match);
            }
            else
            {
                //checks if user already sent like to this person.
                if (!await _likesSentRepo.WasLikeAlreadySent(req.senderId, req.receiverId))
                {
                    await _likesSentRepo.Add(likesSent);
                }
            }

        }



        public async Task SetImageSrc(SetImageRequest req)
        {
            User? user = await _userRepo.GetById(req.clientId);

            if (user != null)
            {
                string fileName = GetFileName(req.file);
                user.ImageSrc = fileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "Images/ClientImages", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await req.file.CopyToAsync(stream);
                }


                await _userRepo.Update(user);
            }

        }

        public async Task SetPreferences(SetPreferencesRequest req)
        {
            UserPreferences userPref = new UserPreferences();
            userPref.Gender = req.gender;
            userPref.Language = req.language;
            userPref.MinAge = req.minAge;
            userPref.MaxAge = req.maxAge;
            userPref.ClientId = req.clientId;

            UserPreferences? existingPreference =  await _preferences.GetByClientId(userPref.ClientId);

            if (existingPreference == null)
            {
                await _preferences.Add(userPref);
            }
            else
            {
                userPref.UserPreferenceId =existingPreference.UserPreferenceId;
                await _preferences.Update(userPref);
            }

        }


        //helpers
        private static string GetFileName(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var maxFileNameLength = 50 - extension.Length;
            var baseFileName = $"image_{timestamp}";

            var fileName = baseFileName.Length > maxFileNameLength
                            ? $"{baseFileName.Substring(0, maxFileNameLength)}{extension}"
                            : $"{baseFileName}{extension}";

            return fileName;
        }

        public async Task<IEnumerable<User>> GetUsersToLike(GetProfilesRequest req)
        {
            UserPreferences pref = await _preferences.GetByClientId(req.clientId);

            if (pref != null)
            {
                IEnumerable<LikesSent>likesSent = await _likesSentRepo.GetLikesSentByClientId(req.clientId);
                IEnumerable<User> usersToLike = await _userRepo.GetUserByPreference(pref, likesSent);

                return usersToLike;
                //return usersToLike;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> Login(LoginRequest req)
        {
            User user = await _userRepo.GetByEmail(req.email);

            if (user.Password.Equals(req))
            {
                return user;
            }
            else
            {
                return null;
            }

        }
    }

}