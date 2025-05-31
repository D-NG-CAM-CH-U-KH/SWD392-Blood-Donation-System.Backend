using Microsoft.AspNetCore.Mvc;
using SWD392_BloodDonationSystem.BLL.Services.Implements;
using SWD392_BloodDonationSystem.BLL.Services.Interfaces;
using SWD392_BloodDonationSystem.Constants;
using SWD392_BloodDonationSystem.DAL.Data.Metadatas;
using SWD392_BloodDonationSystem.DAL.Data.RequestDTO.AvailableDonateDate;

namespace SWD392_BloodDonationSystem.Controllers;

public class AvailableDonationDateController(
  IAvailableDonationDateService availableDonationDateService, 
  ILogger<AvailableDonationDateController> logger) : BaseController<AvailableDonationDateController>(logger)
{
  [HttpPost(APIEndpointsConstant.DateEndpoints.DATE_ENDPOINT)]
  public async Task<IActionResult> CreateAvailableDonateDate([FromBody] AvailableDonateDateDTO dto)
  {
    var createResult = await availableDonationDateService.CreateAvailableDonateDate(dto);
    return Ok(ApiResponseBuilder.BuildResponse(
      statusCode: StatusCodes.Status200OK,
      isSuccess:true,
      message: createResult != null ? "Date created successfully." : "Date create failed",
      data: createResult
      ));
  }
}