
using Microsoft.AspNetCore.Mvc;

namespace TechChallenge_1.API.Base
{
    [Route("api/[controller]")]
    public class PublicController : ControllerBase
    {
        /// <summary>
        /// Informa para o client que está ativa
        /// Útil para validar tokens e para descobrir o estado da API
        /// </summary>
        [HttpGet]
        [Route("is-alive")]
        public IActionResult IsAlive()
        {
            return Ok(true);
        }

    }
}