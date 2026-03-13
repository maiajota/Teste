using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Language;
using Questao5.Infrastructure.Sqlite;
using System.Text.Json;

namespace Questao5.Infrastructure.Services
{
    public class MovimentoService : IMovimentoService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IMovimentoRepository _movimentoRepository;

        public MovimentoService(
            IContaCorrenteRepository contaCorrenteRepository,
            IMovimentoRepository movimentoRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _movimentoRepository = movimentoRepository;
        }

        public async Task<MovimentacaoResponse> ProcessarMovimentacaoAsync(MovimentacaoRequest request)
        {
            
            var conta = await _contaCorrenteRepository.GetByIdAsync(request.IdContaCorrente);
            if (conta == null)
            {
                throw new InvalidOperationException($"{TipoErro.INVALID_ACCOUNT}:Apenas contas correntes cadastradas podem receber movimentação.");
            }

            if (!conta.Ativo)
            {
                throw new InvalidOperationException($"{TipoErro.INACTIVE_ACCOUNT}:Apenas contas correntes ativas podem receber movimentação.");
            }

            if (request.Valor <= 0)
            {
                throw new InvalidOperationException($"{TipoErro.INVALID_VALUE}:Apenas valores positivos podem ser recebidos.");
            }

            if (request.TipoMovimento != "C" && request.TipoMovimento != "D")
            {
                throw new InvalidOperationException($"{TipoErro.INVALID_TYPE}:Apenas os tipos 'débito' ou 'crédito' podem ser aceitos.");
            }

            var movimento = new Movimento
            {
                IdMovimento = Guid.NewGuid().ToString().ToUpper(),
                IdContaCorrente = request.IdContaCorrente,
                DataMovimento = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                TipoMovimento = request.TipoMovimento,
                Valor = request.Valor
            };

            var idMovimento = await _movimentoRepository.CreateAsync(movimento);

            var response = new MovimentacaoResponse(idMovimento);

            return response;
        }
    }
}