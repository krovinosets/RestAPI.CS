using DataFlow.Dto;
using DataFlow.Entities;
using Microsoft.AspNetCore.Mvc;
using SHACT.Response;

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
    public IActionResult Login([FromBody] AuthDto auth)
    {
        try
        {
            UserEntity ue = new UserEntity();
            ue.Email = auth.Email;
            ue.Password = auth.Password;
            string jwt = _services.AuthService.Login(ue);
            return Ok(ResponseManager.SendJson(new {Token = jwt}));
        } catch (Exception e) {
            return BadRequest(ResponseManager.SendError(e.Message));
        }
    }
}