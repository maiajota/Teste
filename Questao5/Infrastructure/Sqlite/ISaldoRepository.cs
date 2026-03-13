namespace Questao5.Infrastructure.Sqlite;

public interface ISaldoRepository
{
    public Task<decimal> GetSaldoByIdAsync(string idContaCorrente);
}