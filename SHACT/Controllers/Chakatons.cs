using System.Data;
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
    
    // POST: api/chakatons
    /// <summary>
    /// Создание нового хакатона.
    /// </summary>
    /// <remarks>
    /// Создает запись нового хакатона и возращает ее.
    /// </remarks>
    /// <param name="chakaton">Данные нового хакатона.</param>
    /// <returns>Возвращает запись нового хакатона.</returns>
    /// <response code="200">Хакатон успешно добавлен.</response>
    /// <response code="400">Недостаточно полей заполнено для создания нового хакатона.</response>
    /// <response code="500">Внутренняя ошибка, подключение к Базе Данных.</response>
    [HttpPost]
    public IActionResult Create([FromBody] ChakatonDto chakaton)
    {
        try
        {
            ChakatonEntity ue = (ChakatonEntity) chakaton.ToEntity();
            ChakatonDto userDto = _services.ChakatonService.Create(ue);
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
    
    // PATCH: api/chakatons
    /// <summary>
    /// Обновление данных хакатона.
    /// </summary>
    /// <remarks>
    /// Возвращает обновленные данные хакатона.
    /// </remarks>
    /// <param name="cid">Уникальный ID номер обновляемого хакатона.</param>
    /// <param name="chakaton">Новые данные существующего хакатона.</param>
    /// <returns>Возвращает запись обновленного хакатона.</returns>
    /// <response code="200">Данные успешно обновлены.</response>
    /// <response code="404">Хакатон с таким ID номером не найден.</response>
    /// <response code="500">Внутренняя ошибка, подключение к Базе Данных.</response>
    [HttpPatch]
    public IActionResult Update([FromQuery] int cid, [FromBody] ChakatonDto chakaton)
    {
        try
        {
            ChakatonEntity ue = (ChakatonEntity) chakaton.ToEntity();
            ue.Id = cid;
            ChakatonDto chakatonDto = _services.ChakatonService.Update(ue);
            return Ok(ResponseManager.SendJson(chakatonDto));
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
    
    // DELETE: api/chakatons
    /// <summary>
    /// Удаление хакатона.
    /// </summary>
    /// <remarks>
    /// Возвращает удаленные данные хакатона.
    /// </remarks>
    /// <param name="cid">Уникальный ID номер удаляемого хакатона.</param>
    /// <returns>Возвращает запись удаленного хакатона.</returns>
    /// <response code="200">Данные успешно удалены.</response>
    /// <response code="404">Хакатон с таким ID номером не найден.</response>
    /// <response code="500">Внутренняя ошибка, подключение к Базе Данных.</response>
    [HttpDelete]
    public IActionResult Remove([FromQuery] int cid)
    {
        try
        {
            ChakatonEntity chakatonEntity = new ChakatonEntity();
            chakatonEntity.Id = cid;
            
            ChakatonDto result = _services.ChakatonService.Remove(chakatonEntity);
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
    
    // GET: api/chakatons
    /// <summary>
    /// Получение хакатонов.
    /// </summary>
    /// <remarks>
    /// Возвращает полученные данные хакатона.
    /// </remarks>
    /// <param name="cid">Уникальный ID номер получаемого хакатона.</param>
    /// <returns>Возвращает запись получаемого хакатона.</returns>
    /// <response code="200">Данные успешно получены.</response>
    /// <response code="404">Хакатон с таким ID номером не найден.</response>
    /// <response code="500">Внутренняя ошибка, подключение к Базе Данных.</response>
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
        catch (KeyNotFoundException e)
        {
            return NotFound(ResponseManager.SendError(e.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, ResponseManager.SendError(e.Message));
        }
    }
    
    // GET: api/chakatons/all
    /// <summary>
    /// Получение всех хакатонов.
    /// </summary>
    /// <remarks>
    /// Возвращает полученные данные всех хакатонов.
    /// </remarks>
    /// <returns>Возвращает все записи хакатонов.</returns>
    /// <response code="200">Данные успешно получены.</response>
    /// <response code="500">Внутренняя ошибка, подключение к Базе Данных.</response>
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
            return StatusCode(500, ResponseManager.SendError(e.Message));
        }
    }
}