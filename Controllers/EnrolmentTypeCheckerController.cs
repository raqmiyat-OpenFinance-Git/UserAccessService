using Entities.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenFinanceWebApi.Data;
using OpenFinanceWebApi.NLogService;

namespace NPSSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolmentTypeCheckerController : Controller
    {
        private readonly NPSSDbContext _context;
        private readonly NLogWebApiService _logger;
        public EnrolmentTypeCheckerController(NPSSDbContext context, NLogWebApiService logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrolmentChecker>>> GetEnrolmentCheckers()
        {
            try
            {
                return await _context.EnrolmentCheckers.Where(a => a.Approval_Status == 0).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnrolmentChecker>> GetEnrolmentChecker(int id)
        {
            try
            {
                var enrolmentChecker = await _context.EnrolmentCheckers.FindAsync(id);

                if (enrolmentChecker == null)
                {
                    return NotFound();
                }

                return enrolmentChecker;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult<EnrolmentChecker>> PostEnrolmentChecker(EnrolmentChecker enrolmentChecker)
        {
            try
            {
                _context.EnrolmentCheckers.Add(enrolmentChecker);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEnrolmentChecker), new { id = enrolmentChecker.Id }, enrolmentChecker);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrolmentChecker(int id, EnrolmentChecker enrolmentChecker)
        {
            if (id != enrolmentChecker.Id)
            {
                return BadRequest();
            }

            _context.Entry(enrolmentChecker).State = EntityState.Modified;

            try
            {
                if (enrolmentChecker.Approval_Status == 1)
                {
                    var enrolmentMain = await _context.EnrolmentMain.SingleOrDefaultAsync(a => a.Operation_Type == enrolmentChecker.Operation_Type);
                    if (enrolmentMain != null)
                    {
                        enrolmentMain.Enrolment_Status = enrolmentChecker.Enrolment_Status;
                        enrolmentMain.Operation_Desc = enrolmentChecker.Operation_Desc;
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EnrolmentCheckerExists(id))
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

        private bool EnrolmentCheckerExists(int id)
        {
            try
            {
                return _context.EnrolmentCheckers.Any(e => e.Id == id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

            
        }
    }
}
