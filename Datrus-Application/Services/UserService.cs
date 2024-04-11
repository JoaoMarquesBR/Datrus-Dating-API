using Datrus_Application.IRepositories;
using Datrus_Application.IServices;
using Datrus_Domain.Entities;
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


        public UserService(IUserRepository userRepo, ILikesSentRepository likeSentRepo, IMatchRepository matchRepo)
        {
            _userRepo = userRepo;
            _matchRepo = matchRepo;
            _likesSentRepo = likeSentRepo;
        }

        public Task Add(User entity)
        {
            return _userRepo.Add(entity);
        }



        public Task<IEnumerable<User>> GetAll()
        {
            return null;

        }

        public Task<User> GetById(object id)
        {
            return null;

        }

        public Task Match(User userSender, User userReceiver)
        {
            UsersMatch usersMatch = new UsersMatch();

            usersMatch.UserA = userSender.ClientId;
            usersMatch.UserB = userReceiver.ClientId;
            usersMatch.Date = DateTime.Now;

            return _matchRepo.Add(usersMatch);
        }


        public async Task SendLike(string senderId, string receiverId)
        {
            LikesSent likesSent = new LikesSent();
            likesSent.FromClientId = senderId;
            likesSent.ToClientId = receiverId;
            likesSent.Date = DateTime.Now;
            likesSent.LikeType = "Normal";

            //does receiver already sent a like for the sender? if yes, its a match
            if (await _likesSentRepo.WasLikeAlreadySent(receiverId, senderId))
            {
                //also register the like sent for data anylsys purposes
                await _likesSentRepo.Add(likesSent);

                UsersMatch match = new UsersMatch();
                match.Date = DateTime.UtcNow;
                match.UserA = receiverId;//userA is the one that liked first!
                match.UserB = senderId;

                await _matchRepo.Add(match);
            }
            else
            {
                //checks if user already sent like to this person.
                if (!await _likesSentRepo.WasLikeAlreadySent(senderId, receiverId))
                {
                    await _likesSentRepo.Add(likesSent);
                }
            }


        }
    }
}
