using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login(UserForLoginDto userForLoginDto)
    {
        IDataResult<User> userToLogin = _authService.Login(userForLoginDto);
        if (!userToLogin.Success)
        {
            return BadRequest(userToLogin.Message);
        }

        IDataResult<AccessToken> result = _authService.CreateAccessToken(userToLogin.Data);
        if (result.Success)
        {
            return Ok(result.Data);
        }

        return BadRequest(result.Message);
    }
    
    [HttpPost("register")]
    public IActionResult Register(UserForRegisterDto userForRegisterDto)
    {
        IResult userExist = _authService.UserExists(userForRegisterDto.Email);
        if (!userExist.Success)
        {
            return BadRequest(userExist.Message);
        }

        IDataResult<User> registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
        IDataResult<AccessToken> result = _authService.CreateAccessToken(registerResult.Data);
        if (result.Success)
        {
            return Ok(result.Data);
        }

        return BadRequest(result.Message);
    }
    
    
}