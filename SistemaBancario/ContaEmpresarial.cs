using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace SistemaBancario
{
    public class ContaEmpresarial : ContaBancaria
    {
        public decimal LimiteEmprestimo { get; set; }
        public ContaEmpresarial(string titular, int numeroConta, decimal saldoInicial)
            : base(titular, numeroConta, saldoInicial) 
        {
            LimiteEmprestimo = 10000;

        }

        public void SolicitarEmprestimo(decimal valor)
        {
            if (valor <= LimiteEmprestimo)
            {
                Saldo += valor;
                LimiteEmprestimo -= valor;
                Console.WriteLine($"Empréstimo de R${valor:F2} aprovado!");
                Console.WriteLine($"Novo saldo: R${Saldo:F2}");
            }
            else
            {
                Console.WriteLine($"Solicitação de emprestimo recusada. Valor acima do limite permitido.");
            }
        }
    }
}
