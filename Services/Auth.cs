using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataFlow.Dto;
using DataFlow.Entities;
using DataFlow.Models;
using Microsoft.IdentityModel.Tokens;

namespace Services;

public class AuthService
{
    private readonly Repositories.Repositories _repositories;
    
    public AuthService(Repositories.Repositories repositories)
    {
        _repositories = repositories;
    }
    
    public string Login(UserEntity user)
    {
        if (user.Password == null)
            throw new Exception("password is not presented");
        
        User um = (User) user.ToModel();
        UserDto userDto = (UserDto) _repositories.UserRepository.GetEmail(um).ToDto();
        if (CreateMd5(user.Password) != userDto.Password)
        {
            throw new Exception("password is incorrect");
        }

        if (userDto.Id == null)
        {
            throw new Exception("internal error, user dto id is null");
        }
        
        int uid = userDto.Id.Value;
        string jwt = CreatJwt(uid);
        return jwt;
    }
    
    private string CreateMd5(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes).ToLower();
        }
    }

    private ClaimsIdentity GetIdentity(int uid)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, Convert.ToString(uid)),
        };
        ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }
    
    private string CreatJwt(int uid)
    {
        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            notBefore: now,
            claims: GetIdentity(uid).Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }
}

public class AuthOptions
{
    public const string Issuer = "SHACT"; // издатель токена
    public const string Audience = "SHACT_user"; // потребитель токена
    private const string Key = "YIO@#!VF*Y2hcc2ub3&Csabg2389hASJ2lx,zfc#";   // ключ для шифрации
    public const int Lifetime = 60 * 12; // время жизни токена - 12 часов
    
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}