using DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace SHACT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Auth : ControllerBase
{
    private readonly Services.Services _services;
    
    public Auth(Services.Services services)
    {
        _services = services;
    }
    
    [HttpPost]
    [Route("/register")]
    public String Register()
    {
        return "Register Fine!";
    }
    
    [HttpPost]
    [Route("/login")]
    public String Login()
    {
        return "Login Fine!";
    }
}