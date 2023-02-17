﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarPanelServer.Models;

namespace SolarPanelServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }*/

        //GET: api/Users/test1
        [HttpGet("{userName}")]
        public async Task<ActionResult<User>> GetUser(string userName)
        {
            if (_context.Users == null)
                return NotFound();
            //var user = await _context.Users.FindAsync(username);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.userName == userName);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string userName, User user)
        {
            if (userName != user.userName)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(userName))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(string userName, string password, string role)
        {
            Int16 roleConv = -1;
            if (Int16.TryParse(role, out roleConv))
            {
                var user = new User
                {
                    userName = userName,
                    password = password,
                    role = roleConv,
                    created = DateTime.Now,
                    rowUpdated = DateTime.Now
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { userName = user.userName }, user);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{userName}")]
        public async Task<ActionResult<User>> ModifyUserRole(string userName, string role)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.userName == userName);
            Int16 roleConv = -1;
            if(user == null)
            {
                return NotFound();
            }
            if(Int16.TryParse(role, out roleConv))
            {
                user.role = roleConv;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.userName == userName);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string userName)
        {
            return (_context.Users?.Any(e => e.userName == userName)).GetValueOrDefault();
        }

        private User getUserByName(string userName)
        {
            return (_context.Users.FirstOrDefault(u => u.userName == userName));
        }
    }
}
