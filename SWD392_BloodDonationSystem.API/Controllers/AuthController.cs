using SWD392_BloodDonationSystem.BLL.Services.Interfaces;
using SWD392_BloodDonationSystem.Constants;
using SWD392_BloodDonationSystem.DAL.Data.Metadatas;
using SWD392_BloodDonationSystem.DAL.Data.RequestDto.Auth;
using Microsoft.AspNetCore.Mvc;

namespace SWD392_BloodDonationSystem.Controllers;

public class AuthController(
    ILogger<AuthController> logger,
    IAuthService authService
) : BaseController<AuthController>(logger)
{
    [HttpPost(APIEndpointsConstant.AuthEndpoints.LOGIN_ENDPOINT)]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO requestDto)
    {
        return Ok(ApiResponseBuilder.BuildResponse(
            statusCode: StatusCodes.Status200OK,
            isSuccess: true,
            message: "Login successful",
            data: await authService.HandleLogin(requestDto)
        ));
    }
   
}