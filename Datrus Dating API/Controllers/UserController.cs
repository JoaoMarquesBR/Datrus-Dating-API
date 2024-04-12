﻿using Datrus_Application.IServices;
using Datrus_Contracts.Requests;
using Datrus_Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Datrus_Dating_API.Controllers
{
    [ApiController]
    [Route("/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService guestService) {
            _userService = guestService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetAll();
        }

        [HttpPost("Add")]
        public async Task Add(User req)
        {
            User guest = new User();
            guest.FirstName = req.FirstName;
            guest.LastName = req.LastName;
            guest .Email = req.Email;  
            guest.Username= req.Username;
            guest.Gender = req.Gender;

            await _userService.Add(guest);
        }

        [HttpPost("SendLike")]
        public async Task SendLike(SendLikeRequest req)
        {

            await _userService.SendLike(req);
        }

        [HttpPost("SetPreferences")]
        public async Task SetPreferences(SetPreferencesRequest req)
        {
            await _userService.SetPreferences(req);
        }

    }
}
