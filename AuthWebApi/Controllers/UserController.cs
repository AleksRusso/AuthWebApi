using AuthWebApi.FContext;
using AuthWebApi.Models;
using AuthWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly MyContext db;
        public UserController(AuthService authService, MyContext _db)
        {
            _authService = authService;
            db = _db;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<string> LogVerify(User user)
        {
            string result = await _authService.Login(user);
            return result;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await db.Users.ToListAsync();
            return Ok(user);
        }
    }

}
