﻿using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercicioTryCatch.Entities.Exception;

namespace ExercicioTryCatch.Entities
{
    internal class Account
    {
        public int Number {  get; set; }
        public string Holder {  get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public void Withdraw(double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new DomainException("Valor de saque ultrapassa o limite " +
                    "estabelecido para essa conta");
            }
            if(amount > Balance)
            {
                throw new DomainException($"Saldo insuficiente." +
                    $" Você tem $ {Balance.ToString("F2",CultureInfo.InvariantCulture)}");
            }
            Balance -= amount;
        }
    }
}
