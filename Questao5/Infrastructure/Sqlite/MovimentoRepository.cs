using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Sqlite
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public MovimentoRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<string> CreateAsync(Movimento movimento)
        {
            using var connection = new SqliteConnection(_databaseConfig.Name);
            var query = @"INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) 
                         VALUES (@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor)";
            
            await connection.ExecuteAsync(query, movimento);
            
            return movimento.IdMovimento;
        }

        public async Task<bool> TemMovimentoAsync(string idContaCorrente)
        {
            using var connection = new SqliteConnection(_databaseConfig.Name);
            var query = @"SELECT 1
                            FROM movimento
                            WHERE idcontacorrente = @idContaCorrente
                            LIMIT 1";
            
            var temMovimento = await connection.QueryFirstOrDefaultAsync<int?>(query, new { idContaCorrente });
            
            return temMovimento.HasValue;
        }
    }
}