using Questao5.Domain.Enumerators;
using Questao5.Domain.Language;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Services;

public class SaldoService : ISaldoService
{
    private readonly IContaCorrenteRepository _contaCorrenteRepository;
    private readonly ISaldoRepository _saldoRepository;
    
    public SaldoService(
        IContaCorrenteRepository contaCorrenteRepository,
        ISaldoRepository saldoRepository)
    {
        _contaCorrenteRepository = contaCorrenteRepository;
        _saldoRepository = saldoRepository;
    }
    
    public async Task<SaldoResponse> GetSaldoByIdAsync(string idContaCorrente)
    {
        var conta = await _contaCorrenteRepository.GetByIdAsync(idContaCorrente);
        
        if (conta == null)
        {
            throw new InvalidOperationException($"{TipoErro.INVALID_ACCOUNT}:Apenas contas correntes cadastradas podem consultar o saldo.");
        }

        if (!conta.Ativo)
        {
            throw new InvalidOperationException($"{TipoErro.INACTIVE_ACCOUNT}:Apenas contas correntes ativas podem consultar o saldo.");
        }

        var saldo = await _saldoRepository.GetSaldoByIdAsync(idContaCorrente);

        return new SaldoResponse
        (
            conta.Numero,
            conta.Nome,
            DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
            saldo
        );
    }
}