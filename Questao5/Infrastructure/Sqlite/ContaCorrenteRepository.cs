using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Sqlite;

public class ContaCorrenteRepository : IContaCorrenteRepository
{
    private readonly DatabaseConfig _databaseConfig;
    
    public ContaCorrenteRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
    
    public async Task<ContaCorrente?> GetByIdAsync(string id)
    {
        using var connection = new SqliteConnection(_databaseConfig.Name);
        var query = @"SELECT idcontacorrente as IdContaCorrente, 
                            numero as Numero, 
                            nome as Nome, 
                            ativo as Ativo 
                        FROM contacorrente WHERE idcontacorrente = @IdContaCorrente";
        var result = await connection.QueryFirstOrDefaultAsync<ContaCorrente>(query, new { IdContaCorrente = id });
            
        return result;
    }
}