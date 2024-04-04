using DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace SHACT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Users : ControllerBase
{
    private readonly Services.Services _services;
    
    public Users(Services.Services services)
    {
        _services = services;
    }
    
    [HttpPost]
    public String Create()
    {
        return "Create Fine!";
    }
    
    [HttpGet]
    public String Get()
    {
        return "Get Fine!";
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