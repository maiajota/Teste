using Questao5.Domain.Language;

namespace Questao5.Infrastructure.Services;

public interface ISaldoService
{
    public Task<SaldoResponse> GetSaldoByIdAsync(string idContaCorrente);
}