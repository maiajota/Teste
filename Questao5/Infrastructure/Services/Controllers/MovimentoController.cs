using Microsoft.AspNetCore.Mvc;
using Questao5.Domain.Language;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentoController : ControllerBase
    {
        private readonly IMovimentoService _movimentoService;

        public MovimentoController(IMovimentoService movimentoService)
        {
            _movimentoService = movimentoService;
        }

        [HttpPost]
        public async Task<IActionResult> MovimentarConta([FromBody] MovimentacaoRequest request)
        {
            try
            {
                var resultado = await _movimentoService.ProcessarMovimentacaoAsync(request);
                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new {Tipo = "INVALID_REQUEST", Mensagem = ex.Message });
            }
        }
    }
}