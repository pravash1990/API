using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task< ActionResult<IEnumerable<AppUser>>> GetUser()
        {
            var userlist = await _context.users.ToListAsync();
            return userlist;
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<AppUser>> GetUser(int id)
        { 
            return await _context.users.FindAsync(id);
        }
    }
}
