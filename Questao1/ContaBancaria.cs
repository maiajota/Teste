using System.Globalization;

namespace Questao1
{
    class ContaBancaria {
        public int Numero { get; init; }
        public string NomeTitular { get; set; }
        public double Saldo { get; private set; }
        
        public ContaBancaria(int numero, string nomeTitular, double depositoInicial = 0) {
            Numero = numero;
            NomeTitular = nomeTitular;
            Saldo = depositoInicial;
        }
        
        public void Deposito(double valor) {
            Saldo += valor;
        }
        
        public void Saque(double valor) {
            Saldo -= valor + 3.50;
        }

        public override string ToString()
        {
            return $"Conta {Numero}, Titular: {NomeTitular}, Saldo: ${Saldo.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
