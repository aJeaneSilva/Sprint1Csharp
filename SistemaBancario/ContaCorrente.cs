using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario
{
    public class ContaCorrente : ContaBancaria, ITributavel
    {
        public decimal TaxaParaSaque { get; private set; }
        = 2.50m;
        public ContaCorrente(string titular, int numeroConta, decimal saldoInicial)
            : base(titular, numeroConta, saldoInicial) { }

        public override bool Sacar(decimal valor)
        {
            decimal valorTotal = valor + TaxaParaSaque;
            Console.WriteLine($"\nValor do saque: R${valor:F2}. Taxa de saque: R${TaxaParaSaque}. Valor total a ser debitado: R${valorTotal:F2}.");
            return base.Sacar(valorTotal);
        }

        public decimal CalcularTributo()
        {
            return TaxaParaSaque;
        }
    }
}
