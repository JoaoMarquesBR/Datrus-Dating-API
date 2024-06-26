﻿using Datrus_Application.IRepositories;
using Datrus_Application.IServices;
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
        private readonly IMatchRepository _matchRepository;

        public UserController(IUserService guestService,IMatchRepository _matchRepo) {
            _userService = guestService;
            _matchRepository = _matchRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetAll();
        }

        [HttpGet("GetMatches")]
        public async Task<IEnumerable<UsersMatch>> GetMatches(string clientId)
        {
            return await _matchRepository.GetByClientId(clientId);
        }


        [HttpGet("GetProfiles")]
        public async Task<IEnumerable<User>> GetProfiles(string clientId)
        {
            IEnumerable<User> usersToLike = await _userService.GetUsersToLike(new GetProfilesRequest(clientId));

            return usersToLike;
        }

        [HttpPost("Add")]
        public async Task Add(AddUserRequest req)
        {
            User guest = new User();
            guest.FirstName = req.firstName;
            guest.LastName = req.lastName;
            guest .Email = req.email;
            guest.Password = req.password;
            guest.Username= req.username;
            guest.Gender = req.gender;
            guest.Age = req.age;
            guest.Religion = req.religion;
            guest.FirstLanguage = req.firstLanguage;
            guest.ImageSrc = "";


            await _userService.Add(guest);
        }

        [HttpPost("Login")]
        public async Task<User> Login(LoginRequest req)
        {
            return await _userService.Login(req);

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

        [HttpPut("Image/upload")]
        public async Task<IActionResult> updateImage(string  clientId,IFormFile file)
        {
            if (file == null)
                return BadRequest(new { message = "File is required." });

            string[] supportedContentTypes = { "image/jpeg", "image/svg", "image/jpg", "image/png", "image/gif" };

            if (!supportedContentTypes.Contains(file.ContentType))
                return null;


            await _userService.SetImageSrc(new SetImageRequest(clientId, file));

            return Ok(new { message = "success" });

        }
    }
}
