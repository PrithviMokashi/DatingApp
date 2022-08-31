using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//Mvc is Modern view controller

namespace API.Controllers
{
      [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        //IEnumerable allows us to use simple iteration over a collection of specific type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            //Variable to store users
            //Returning list of users Asynchronously 
            var users = await _userRepository.GetMembersAsync();

            return Ok(users);
        }

        //api/users/3 when user hits this endpoint these results are fetched
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
        }


        //Used to update a resource in our server
        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            //Returns the users username from the token that API uses to authenticate
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepository.GetUserByUsernameAsync(username);

            //Maps all the properties of memberUpdateDto to user
            //Ex: user.City = memberUpdateDto.City
            _mapper.Map(memberUpdateDto, user);

            //Flagged as being updated by entity framework we wont get exception or error
            //when we come back from updating the user in database
            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        } 
    }
}