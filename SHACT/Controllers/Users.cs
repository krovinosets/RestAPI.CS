using DataFlow.Dto;
using DataFlow.Entities;
using Microsoft.AspNetCore.Mvc;
using SHACT.Response;

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
    public IActionResult Get([FromQuery] int uid)
    {
        try
        {
            UserDto userDto = new UserDto();
            userDto.Id = uid;

            UserEntity ue = (UserEntity)userDto.ToEntity();
            UserDto result = _services.UsersService.Read(ue);

            return Ok(ResponseManager.SendJson(result));
        }
        catch (Exception e)
        {
            return BadRequest(ResponseManager.SendError(e.Message));
        }
    }
    
    [HttpGet]
    [Route("All")]
    public IActionResult GetAll()
    {
        try
        {
            UserDto userDto = new UserDto();
            UserEntity ue = (UserEntity)userDto.ToEntity();
            List<UserDto> result = _services.UsersService.ReadAll(ue);

            return Ok(ResponseManager.SendJson(result));
        }
        catch (Exception e)
        {
            return BadRequest(ResponseManager.SendError(e.Message));
        }
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