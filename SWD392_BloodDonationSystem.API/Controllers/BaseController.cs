using SWD392_BloodDonationSystem.Constants;
using Microsoft.AspNetCore.Mvc;

namespace SWD392_BloodDonationSystem.Controllers;

[Route(APIEndpointsConstant.API_ENDPOINT)]
[ApiController]
public class BaseController<T>
    (ILogger<T> logger)
    : ControllerBase where T : BaseController<T>
{
    
}