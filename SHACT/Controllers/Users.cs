using System.Data;
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
    
    // POST: api/users
    /// <summary>
    /// Создание нового пользователя.
    /// </summary>
    /// <remarks>
    /// Создает запись нового пользователя и возращает ее.
    /// </remarks>
    /// <param name="user">Данные нового пользователя.</param>
    /// <returns>Возвращает запись нового пользователя.</returns>
    /// <response code="200">Пользователь успешно добавлен.</response>
    /// <response code="400">Недостаточно полей заполнено для создания нового пользователя.</response>
    /// <response code="500">Внутренняя ошибка, подключение к Базе Данных.</response>
    [HttpPost]
    public IActionResult Create([FromBody] UserDto user)
    {
        try
        {
            UserEntity ue = (UserEntity) user.ToEntity();
            UserDto userDto = _services.UsersService.Create(ue);
            return Ok(ResponseManager.SendJson(userDto));
        }
        catch (NoNullAllowedException e)
        {
            return BadRequest(ResponseManager.SendError(e.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, ResponseManager.SendError(e.Message));
        }
    }
    
    // PATCH: api/users
    /// <summary>
    /// Обновление данных пользователя.
    /// </summary>
    /// <remarks>
    /// Возвращает обновленные данные пользователя.
    /// </remarks>
    /// <param name="uid">Уникальный ID номер обновляемого пользователя.</param>
    /// <param name="user">Новые данные существующего пользователя.</param>
    /// <returns>Возвращает запись обновленного пользователя.</returns>
    /// <response code="200">Данные успешно обновлены.</response>
    /// <response code="404">Пользователь с таким ID номером не найден.</response>
    /// <response code="500">Внутренняя ошибка, подключение к Базе Данных.</response>
    [HttpPatch]
    public IActionResult Update([FromQuery] int uid, [FromBody] UserDto user)
    {
        try
        {
            UserEntity ue = (UserEntity)user.ToEntity();
            ue.Id = uid;
            UserDto userDto = _services.UsersService.Update(ue);
            return Ok(ResponseManager.SendJson(userDto));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(ResponseManager.SendError(e.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, ResponseManager.SendError(e.Message));
        }
    }
    
    // DELETE: api/users
    /// <summary>
    /// Удаление пользователя.
    /// </summary>
    /// <remarks>
    /// Возвращает удаленные данные пользователя.
    /// </remarks>
    /// <param name="uid">Уникальный ID номер удаляемого пользователя.</param>
    /// <returns>Возвращает запись удаленного пользователя.</returns>
    /// <response code="200">Данные успешно удалены.</response>
    /// <response code="404">Пользователь с таким ID номером не найден.</response>
    /// <response code="500">Внутренняя ошибка, подключение к Базе Данных.</response>
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
        catch (KeyNotFoundException e)
        {
            return NotFound(ResponseManager.SendError(e.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, ResponseManager.SendError(e.Message));
        }
    }
    
    // GET: api/users
    /// <summary>
    /// Получение пользователя.
    /// </summary>
    /// <remarks>
    /// Возвращает полученные данные пользователя.
    /// </remarks>
    /// <param name="uid">Уникальный ID номер получаемого пользователя.</param>
    /// <returns>Возвращает запись получаемого пользователя.</returns>
    /// <response code="200">Данные успешно получены.</response>
    /// <response code="404">Пользователь с таким ID номером не найден.</response>
    /// <response code="500">Внутренняя ошибка, подключение к Базе Данных.</response>
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
        catch (KeyNotFoundException e)
        {
            return NotFound(ResponseManager.SendError(e.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, ResponseManager.SendError(e.Message));
        }
    }
    
    // GET: api/users/all
    /// <summary>
    /// Получение всех пользователей.
    /// </summary>
    /// <remarks>
    /// Возвращает полученные данные всех пользователей.
    /// </remarks>
    /// <returns>Возвращает все записи пользователей.</returns>
    /// <response code="200">Данные успешно получены.</response>
    /// <response code="500">Внутренняя ошибка, подключение к Базе Данных.</response>
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
            return StatusCode(500, ResponseManager.SendError(e.Message));
        }
    }
}