﻿using DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace SHACT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Test : ControllerBase
{
    private readonly Services.Services _services;
    
    public Test(Services.Services services)
    {
        _services = services;
    }
    
    [HttpPost]
    public String Create()
    {
        return "Create Fine!";
    }
    
    [HttpGet]
    public List<Chakaton> Get()
    {
        return _services.TestService.TestFull();
    }
    
    [HttpPatch]
    public String Update()
    {
        return "Update Fine!";
    }
    
    [HttpDelete]
    public String Delete()
    {
        return "Delete Fine!";
    }
}