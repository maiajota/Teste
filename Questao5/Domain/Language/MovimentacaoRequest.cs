namespace Questao5.Domain.Language;

public record MovimentacaoRequest(
    string IdRequisicao,
    string IdContaCorrente,
    decimal Valor,
    string TipoMovimento
);