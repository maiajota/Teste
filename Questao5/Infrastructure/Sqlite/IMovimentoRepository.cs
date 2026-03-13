using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Sqlite;

public interface IMovimentoRepository
{
    Task<string> CreateAsync(Movimento movimento);
    Task<bool> TemMovimentoAsync(string idContaCorrente);
}