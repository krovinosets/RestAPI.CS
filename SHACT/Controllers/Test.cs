using DatabaseModels;
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
        Console.WriteLine("Test route initialized");
    }

    [HttpGet]
    public List<Chakaton> Get()
    {
        return _services.TestService.TestFull();
    }
}