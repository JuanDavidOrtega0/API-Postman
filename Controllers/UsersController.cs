using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostmanAPI.Data;
using PostmanAPI.Models;

namespace PostmanAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly BaseContext _context;

    public UsersController(BaseContext context)
    {
        _context = context;
    }
}