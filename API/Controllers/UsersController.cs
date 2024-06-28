﻿using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;


[ApiController]
[Route("api/[controller]")]//api/users
public class UsersController:ControllerBase
{
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
_context=context;
    }

    [HttpGet]
public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
var users = await _context.Users.ToListAsync();
return users;
}

 [HttpGet("{id:int}")]
public async Task<ActionResult<AppUser>> GetUser(int id){
var user = await _context.Users.FindAsync(id);
if(user == null)
{
    return NotFound();
}
return user;
}
}
