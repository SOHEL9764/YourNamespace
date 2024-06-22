using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YourNamespace.Services;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyVaultController : ControllerBase
    {
        private readonly KeyVaultService _keyVaultService;

        public KeyVaultController(KeyVaultService keyVaultService)
        {
            _keyVaultService = keyVaultService;
        }

        [HttpGet("GetConnectionString")]
        public async Task<IActionResult> GetConnectionString()
        {
            string secretName = "KeyVaultDemo-ConnectionStrings--DefaultConnection";
            string connectionString = await _keyVaultService.GetSecretAsync(secretName);
            return Ok(connectionString);
        }
    }
}
