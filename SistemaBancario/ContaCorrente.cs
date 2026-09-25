using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario
{
    public class ContaCorrente : ContaBancaria
    {
        public decimal TaxaParaSaque { get; private set; }
        = 2.50m;
        public ContaCorrente(string titular, int numeroConta, decimal saldoInicial)
            : base(titular, numeroConta, saldoInicial) { }

        public override bool Sacar(decimal valor)
        {
            decimal valorTotal = valor + TaxaParaSaque;
            Console.WriteLine($"\nValor do saque: R${valor}. Taxa de saque: R${TaxaParaSaque}. Valor total a ser debitado: R${valorTotal}.");
            return base.Sacar(valorTotal);

        }

    }
}
