using DataFlow.Dto;
using DataFlow.Entities;
using Microsoft.AspNetCore.Mvc;
using SHACT.Response;

namespace SHACT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Chakatons : ControllerBase
{
    private readonly Services.Services _services;
    
    public Chakatons(Services.Services services)
    {
        _services = services;
    }
    
    [HttpPost]
    public String Create()
    {
        return "Create Fine!";
    }
    
    [HttpGet]
    public IActionResult Get([FromQuery] int cid)
    {
        try
        {
            ChakatonDto chakatonDto = new ChakatonDto();
            chakatonDto.Id = cid;

            ChakatonEntity ue = (ChakatonEntity) chakatonDto.ToEntity();
            ChakatonDto result = _services.ChakatonService.Read(ue);

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
            ChakatonDto chakatonDto = new ChakatonDto();
            ChakatonEntity ue = (ChakatonEntity) chakatonDto.ToEntity();
            List<ChakatonDto> result = _services.ChakatonService.ReadAll(ue);

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