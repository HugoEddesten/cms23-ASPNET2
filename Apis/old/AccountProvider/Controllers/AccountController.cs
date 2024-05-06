using AccountProvider.Contexts;
using AccountProvider.Entities;
using AccountProvider.Factories;
using AccountProvider.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace AccountProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;


        [HttpPost]
        public async Task<IActionResult> Create(AccountModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _context.Accounts.FindAsync(model.UserId);
                if (entity == null)
                {
                        var result = _context.Accounts.Add(AccountFactory.Create(model));
                        await _context.SaveChangesAsync();
                        return Created();
                }
                return Problem();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string userId)
        {
            AccountEntity? entity = await _context.Accounts.FindAsync(userId);
            var result = JsonConvert.SerializeObject(entity);
            if (entity != null) 
            {
                return Ok(result);
            }
            return BadRequest();
        }

        
    }
}
