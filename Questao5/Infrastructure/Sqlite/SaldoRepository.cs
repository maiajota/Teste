using Dapper;
using Microsoft.Data.Sqlite;

namespace Questao5.Infrastructure.Sqlite;

public class SaldoRepository : ISaldoRepository
{
    
    private readonly DatabaseConfig _databaseConfig;

    public SaldoRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
    
    public async Task<decimal> GetSaldoByIdAsync(string idContaCorrente)
    {
        using var connection = new SqliteConnection(_databaseConfig.Name);
        var query = @"
                SELECT 
                    COALESCE(SUM(CASE WHEN tipomovimento = 'C' THEN valor ELSE -valor END), 0) as Saldo
                FROM movimento 
                WHERE idcontacorrente = @IdContaCorrente";
            
        var saldo = await connection.QueryFirstOrDefaultAsync<decimal>(query, new { IdContaCorrente = idContaCorrente });
            
        return saldo;
    }
}