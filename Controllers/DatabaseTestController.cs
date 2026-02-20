using asp.net_core_8._0_web_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_core_8._0_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseTestController : ControllerBase
    {
        private readonly IDatabaseTestService _dbTest;

        public DatabaseTestController(IDatabaseTestService dbTest)
        {
            _dbTest = dbTest;
        }

        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            var (success, message) = await _dbTest.TestConnectionAsync();
            if (success) return Ok(new { success = true, message });
            return StatusCode(503, new { success = false, message });
        }

    }
}
