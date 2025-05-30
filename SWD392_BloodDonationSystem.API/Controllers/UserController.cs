using Microsoft.AspNetCore.Mvc;
using SWD392_BloodDonationSystem.BLL.Services.Interfaces;
using SWD392_BloodDonationSystem.Constants;
using SWD392_BloodDonationSystem.DAL.Data;
using SWD392_BloodDonationSystem.DAL.Data.Entities;
using SWD392_BloodDonationSystem.DAL.Data.Metadatas;
using SWD392_BloodDonationSystem.DAL.Data.RequestDTO.Accounts;

namespace SWD392_BloodDonationSystem.Controllers;

public class UserController(IUserService userService, ILogger<UserController> logger) : BaseController<UserController>(logger)
{
    [HttpPost(APIEndpointsConstant.AccountEndpoints.ACCOUNT_ENDPOINT)]
    public async Task<IActionResult> CreateUser([FromBody] CreateAccountRequestDTO requestDto)
    {
        var createResult = await userService.HandleCreateUser(requestDto); 
        
        return Ok(ApiResponseBuilder.BuildResponse(
            statusCode: StatusCodes.Status200OK,
            isSuccess: true,
            message: createResult != null ? "Create user successfully!" : "Create user fail!",
            data: createResult
        ));
    }
}