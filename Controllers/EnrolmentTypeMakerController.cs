using Entities.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenFinanceWebApi.Data;
using OpenFinanceWebApi.NLogService;

namespace NPSSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolmentTypeMakerController : Controller
    {
        private readonly NPSSDbContext _context;
        private readonly NLogWebApiService _logger;
        public EnrolmentTypeMakerController(NPSSDbContext context, NLogWebApiService logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrolmentMain>>> GetEnrolmentMain()
        {
            try
            {
                return await _context.EnrolmentMain.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
        [HttpGet("GetFileTypes")]
        public async Task<ActionResult<IEnumerable<EnrolmentMain>>> GetEnrolmentMainByUserType(string userType)
        {
            try
            {
                var enrolmentMain = await _context.EnrolmentMain
               .Where(a => a.UserType == userType && a.Enrolment_Status == true)
               .ToListAsync();

                if (enrolmentMain.Count == 0)
                {
                    return NotFound("No enrolment records found for the specified user type.");
                }

                return enrolmentMain;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnrolmentMain>> GetEnrolmentMain(int id)
        {
            try
            {
                var enrolmentMain = await _context.EnrolmentMain.FindAsync(id);

                if (enrolmentMain == null)
                {
                    return NotFound();
                }

                return enrolmentMain;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrolmentMain(int id, EnrolmentMain enrolmentMain)
        {
            if (id != enrolmentMain.Enrolment_ID)
            {
                return BadRequest();
            }

            _context.Entry(enrolmentMain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EnrolmentMainExists(id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.Error(ex);
                    throw;
                }
            }

            return NoContent();
        }

        private bool EnrolmentMainExists(int id)
        {
            try
            {
                return _context.EnrolmentMain.Any(e => e.Enrolment_ID == id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }
}

