using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    public AuthController()
    {
    }

    [HttpPost]
    public bool Login([FromBody] LoginDto loginDto)
    {
        return loginDto.Username == "root" && loginDto.Password == "root";
        Response.Cookies.Append("accessToken", "yes");
    }
}
