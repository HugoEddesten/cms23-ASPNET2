using AccountProvider.Contexts;
using AccountProvider.Entities;
using AccountProvider.Factories;
using AccountProvider.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace AccountProvider.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(ApiContext context) : ControllerBase
{
    private readonly ApiContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Create(AccountModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var entity = await _context.Accounts.FindAsync(model.UserId);
                if (entity == null)
                {
                    _context.Accounts.Add(AccountFactory.Create(model));
                    await _context.SaveChangesAsync();
                    return Created();
                }
                return Problem();
            }
            return BadRequest();
        }
        catch
        {
            return Problem();
        }

    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(string userId)
    {
        AccountEntity? entity = await _context.Accounts.FindAsync(userId);
        if (entity != null)
        {
            return Ok(entity);
        }
        return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            IEnumerable<AccountEntity> entities = await _context.Accounts.ToListAsync();
            return Ok(entities);
        }
        catch
        {
            return Problem();
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(AccountModel model)
    {
        try
        {
            bool userExists = await _context.Accounts.AnyAsync(x => x.UserId == model.UserId);
            if (userExists)
            {
                AccountEntity entity = AccountFactory.Create(model);
                _context.Accounts.Update(entity);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();

        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(AccountModel model)
    {
        bool userExists = _context.Accounts.Any(x => x.UserId == model.UserId);
        if (userExists)
        {
            _context.Accounts.Remove(AccountFactory.Create(model));
            await _context.SaveChangesAsync();
            return NoContent();
        }
        return NotFound();
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> Delete(string userId)
    {
        AccountEntity? entity = await _context.Accounts.FindAsync(userId);
        if (entity != null)
        {
            _context.Accounts.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        return NotFound();
    }
}
