using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostmanAPI.Data;
using PostmanAPI.Models;

namespace PostmanAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{   
    //Este es el controlador de la base de datos
    private readonly BaseContext _context;

    public UsersController(BaseContext context)
    {
        _context = context;
    }

    //Este es el controlador de listar los usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    //Este es el controlador de ver detalles de un usuario mediante Id
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    //Este es el controlador de crear un usuario
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    //Este es el controlador de actualizar un usuario
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, User user)
    {   
        if (id!= user.Id)
        {
            return BadRequest();
        }
        _context.Update(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    //Este es el controlador de eliminar un usuario
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}