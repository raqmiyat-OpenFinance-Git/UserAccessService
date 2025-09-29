using Entities.Admi004;
using Entities.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenFinanceWebApi.Data;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admi004Controller(NPSSDbContext context, IAdmi004Service admi004service, NLogWebApiService logger) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseStatus), 200)]
        [ProducesResponseType(typeof(ResponseStatus), 500)]
        public async Task<IActionResult> GetAdmi004(string action, int id = 0)
        {
            try
            {
                if (action == "CHECKER")
                {
                    return Ok(await admi004service.GetAdmi004(id));
                }
                else if (action == "MAKER")
                {
                    return Ok(await admi004service.GetAdmi004Maker(id));
                }
                else if (action == "INWARD")
                {
                    return Ok(await admi004service.GetAdmi004Inward());
                }
                else
                {
                    return Ok(new List<Admi004Checker>());
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseStatus), 200)]
        [ProducesResponseType(typeof(ResponseStatus), 400)]
        [ProducesResponseType(typeof(ResponseStatus), 500)]
        public async Task<ActionResult> AddAdmi004([FromBody] Admi004Checker admi004)
        {
            try
            {
                if (admi004.Action == "INSERT")
                {
                    if (admi004.Description == "PLANNED DOWNTIME INFO")
                    {
                        if (await context.IPP_OWD_Admi004_Checker.AnyAsync(a => a.Status == "PENDING"))
                        {
                            return BadRequest(new ResponseStatus
                            {
                                status = "FAILED",
                                statusMessage = "An approval request is already pending."
                            });
                        }

                        if (await context.IPP_OWD_Admi004_Maker.AnyAsync(a => a.Status == "INPROGRESS"))
                        {
                            return BadRequest(new ResponseStatus
                            {
                                status = "FAILED",
                                statusMessage = "A downtime request is currently in progress. You may extend it instead."
                            });
                        }

                        if (await context.IPP_OWD_Admi004_Maker.AnyAsync(a => a.Status == "SENT_TO_CB"))
                        {
                            return BadRequest(new ResponseStatus
                            {
                                status = "FAILED",
                                statusMessage = "An item is already sent to CB. Please handle it manually."
                            });
                        }
                    }

                    switch (admi004.Description)
                    {
                        case "AVAILABILITY INFO":
                        case "DOWNTIME EXTENSION":
                            {
                                var admi004Maker = await context.IPP_OWD_Admi004_Maker.FirstOrDefaultAsync(a => a.Status == "INPROGRESS");

                                if (admi004Maker != null)
                                {
                                    if (admi004.Description == "AVAILABILITY INFO" && admi004.StartTime.HasValue)
                                    {
                                        admi004.EndTime = admi004.StartTime.Value.AddMinutes(1);
                                    }
                                    else
                                    {
                                        admi004.StartTime = admi004Maker.StartTime;
                                    }
                                }

                                break;
                            }
                    }
                }

                if (admi004.Action == "APPROVEREJECT" && admi004.Status == "APPROVED" && await context.IPP_OWD_Admi004_Maker.AnyAsync(a => a.Status == "INPROGRESS"))
                {
                    var admi004Checker = await context.IPP_OWD_Admi004_Checker.FirstOrDefaultAsync(a => a.Id == admi004.Id);

                    if (admi004Checker != null)
                    {
                        switch (admi004Checker.Description)
                        {
                            case "AVAILABILITY INFO":
                            case "DOWNTIME EXTENSION":
                                {
                                    var uaeTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time");

                                    var admi004Maker = await context.IPP_OWD_Admi004_Maker.FirstOrDefaultAsync(a => a.Status == "INPROGRESS");

                                    if (admi004Maker != null)
                                    {
                                        admi004Maker.Status = admi004Checker.Description == "AVAILABILITY INFO" ? "TERMINATED" : "EXTENDED";
                                        admi004Maker.ModifiedOn = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, uaeTimeZone);
                                        admi004Maker.ModifiedBy = "NPSSWEBAPI";

                                        await context.SaveChangesAsync();
                                    }

                                    break;
                                }
                        }
                    }
                }

                if (admi004service.AddAdmi004(admi004))
                {
                    return Ok(new ResponseStatus
                    {
                        status = "SUCCESS",
                        statusMessage = "The record was successfully added."
                    });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode(500, new ResponseStatus
                {
                    status = "FAILED",
                    statusMessage = "An unexpected error occurred while processing your request."
                });
            }

            return BadRequest(new ResponseStatus
            {
                status = "FAILED",
                statusMessage = "Unable to add the record. Please try again."
            });
        }
    }
}
