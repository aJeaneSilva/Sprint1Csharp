using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(string titular, int numeroConta, decimal saldoInicial)
            : base(titular, numeroConta, saldoInicial) { }

        public void Rendimento(decimal percentual)
        { decimal rendimento = Saldo * (percentual / 100);
            Saldo += rendimento;
            Console.WriteLine($"Rendimento de {percentual}% aplicado. Agora seu saldo é de: R${Saldo:F2}");
        }
    }
}
