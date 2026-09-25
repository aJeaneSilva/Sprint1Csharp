using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario
{
    public abstract class ContaBancaria
    {
        public string Titular { get; set; }
        public int NumeroConta { get; set; }
        public decimal Saldo { get; protected set; }

        public ContaBancaria(string titular, int numeroConta, decimal saldoInicial)
        {
            Titular = titular;
            NumeroConta = numeroConta;
            Saldo = saldoInicial;
        }

        public virtual void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Adicione um valor maior que zero.");
            }
            Saldo += valor;
            Console.WriteLine($"Depósito de R${valor} realizado com sucesso! Novo saldo: R${Saldo}");
        }
        public virtual bool Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Adicione um valor maior que zero.");
            }
            if (Saldo >= valor)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de R${valor} realizado com sucesso! Novo saldo: R${Saldo}");
                return true;
            }
            else
            {
                Console.WriteLine($"Seu saldo é de R${Saldo}. Infelizmente não é possivel sacar.");
                return false;

            }
        }
        public virtual void ExtratoAtual()
        {
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Número da Conta: {NumeroConta}");
            Console.WriteLine($"Saldo Atual: R${Saldo}");
            //Talvez seja criativo colocar sobre as transações realizadas, data e hora, mas isso é um extra.
        }
    }
   
 }
