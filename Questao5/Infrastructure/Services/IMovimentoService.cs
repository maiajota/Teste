using Questao5.Domain.Language;

namespace Questao5.Infrastructure.Services
{
    public interface IMovimentoService
    {
        Task<MovimentacaoResponse> ProcessarMovimentacaoAsync(MovimentacaoRequest request);
    }
}