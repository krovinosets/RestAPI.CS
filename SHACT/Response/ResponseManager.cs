using DataFlow.Dto;

namespace SHACT.Response;

public static class ResponseManager
{
    public static string SendError(string message)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(new {Message = message});
        return json;
    }
    
    public static string SendJson(Object dto)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
        return json;
    }
}