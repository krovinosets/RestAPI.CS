using System.Data;
using System.Security.Authentication;
using System.Security.Claims;
using DataFlow.Dto;
using DataFlow.Entities;
using Microsoft.AspNetCore.Authorization;
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
    
    // POST: api/auth/register
    /// <summary>
    /// Регистрация нового пользователя.
    /// </summary>
    /// <remarks>
    /// Возвращает данные зарегестрированного пользователя.
    /// </remarks>
    /// <returns>Возвращает запись созданного пользователя.</returns>
    /// <response code="501">Метод не реализован.</response>
    [HttpPost]
    [Route("/register")]
    public IActionResult Register()
    {
        return StatusCode(501, ResponseManager.SendError("регистрация не доступна"));
    }

    [HttpPost]
    [Route("/test")]
    [Authorize]
    public IActionResult Test()
    {
        var uid = User.Identity?.Name;
        return StatusCode(200, ResponseManager.SendJson(new {uid}));
    }

    // POST: api/auth/login
    /// <summary>
    /// Авторизация клиента.
    /// </summary>
    /// <remarks>
    /// Возвращает JWT токен сессии.
    /// </remarks>
    /// <param name="auth">Данные пользователя для создания сессии.</param>
    /// <returns>Возвращает json web token.</returns>
    /// <response code="200">Авторизация успешна пройдена.</response>
    /// <response code="400">Не все поля тела запроса введены.</response>
    /// <response code="403">Некоректный пароль от аккаунта.</response>
    /// <response code="404">Пользователь с таким email не найден.</response>
    /// <response code="500">Внутренняя ошибка, подключение к Базе Данных.</response>
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
            return Ok(ResponseManager.SendJson(new { Token = jwt }));
        }
        catch (NoNullAllowedException e)
        {
            return BadRequest(ResponseManager.SendError(e.Message));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(ResponseManager.SendError(e.Message));
        }
        catch (AuthenticationException e)
        {
            return StatusCode(403 ,ResponseManager.SendError(e.Message));
        } 
        catch (Exception e) 
        {
            return BadRequest(ResponseManager.SendError(e.Message));
        }
    }
}