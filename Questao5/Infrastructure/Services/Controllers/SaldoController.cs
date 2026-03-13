using Microsoft.AspNetCore.Mvc;

namespace Questao5.Infrastructure.Services.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaldoController : ControllerBase
{
    private readonly ISaldoService _saldoService;
    
    public SaldoController(ISaldoService saldoService)
    {
        _saldoService = saldoService;
    }
    
    [HttpGet("{idContaCorrente}")]
    public async Task<IActionResult> GetSaldoByIdAsync(string idContaCorrente)
    {
        try
        {
            var response = await _saldoService.GetSaldoByIdAsync(idContaCorrente);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new {Tipo = "INVALID_REQUEST", Mensagem = ex.Message });
        }
    }
}