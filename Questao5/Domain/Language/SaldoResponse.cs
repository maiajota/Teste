namespace Questao5.Domain.Language;

public record SaldoResponse(
    int Numero,
    string Nome,
    string DataMovimento,
    decimal Saldo
);