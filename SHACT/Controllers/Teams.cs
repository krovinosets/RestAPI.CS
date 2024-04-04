using DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace SHACT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Teams : ControllerBase
{
    private readonly Services.Services _services;
    
    public Teams(Services.Services services)
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