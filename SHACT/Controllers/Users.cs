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
    public IActionResult Create([FromBody] UserDto user)
    {
        try
        {
            UserEntity ue = (UserEntity) user.ToEntity();
            UserDto userDto = _services.UsersService.Create(ue);
            return Ok(ResponseManager.SendJson(userDto));
        }
        catch (Exception e)
        {
            return BadRequest(ResponseManager.SendError(e.Message));
        }
    }
    
    [HttpPatch]
    public IActionResult Update([FromQuery] int uid, [FromBody] UserDto user)
    {
        try
        {
            UserEntity ue = (UserEntity) user.ToEntity();
            ue.Id = uid;
            UserDto userDto = _services.UsersService.Update(ue);
            return Ok(ResponseManager.SendJson(userDto));
        }
        catch (Exception e)
        {
            return BadRequest(ResponseManager.SendError(e.Message));
        }
    }
    
    [HttpDelete]
    public IActionResult Remove([FromQuery] int uid)
    {
        try
        {
            UserEntity userEntity = new UserEntity();
            userEntity.Id = uid;
            
            UserDto result = _services.UsersService.Remove(userEntity);
            return Ok(ResponseManager.SendJson(result));
        }
        catch (Exception e)
        {
            return BadRequest(ResponseManager.SendError(e.Message));
        }
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
}