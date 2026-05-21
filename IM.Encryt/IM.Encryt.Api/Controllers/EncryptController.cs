using IM.Encryt.Models.Entities;
using IM.Encryt.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace IM.Encryt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptController : ControllerBase
    {
        [HttpPost("Encrypt")]
        public ActionResult<EncryptResponse> Encrypt(
            [FromBody] EncryptRequest request)
        {
            return Ok(new EncryptResponse
            {
                Result = EncryptHelper.Encrypt(
                    request.Text,
                    request.Key,
                    request.Version)
            });
        }

        [HttpPost("Decrypt")]
        public ActionResult<EncryptResponse> Decrypt(
            [FromBody] EncryptRequest request)
        {
            return Ok(new EncryptResponse
            {
                Result = EncryptHelper.Decrypt(
                    request.Text,
                    request.Key)
            });
        }
    }
}
