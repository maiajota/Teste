using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Sqlite;

public interface IContaCorrenteRepository
{
    public Task<ContaCorrente?> GetByIdAsync(string id);
}