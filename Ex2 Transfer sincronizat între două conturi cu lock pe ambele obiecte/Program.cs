using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex2_Transfer_sincronizat_între_două_conturi_cu_lock_pe_ambele_obiecte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Account1", 1000);
            BankAccount account2 = new BankAccount("Account2", 1000);

            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                if (i % 2 == 0)
                    threads[i] = new Thread(() => Transfer(account1, account2, 100, i + 1));
                else
                    threads[i] = new Thread(() => Transfer(account2, account1, 100, i + 1));
                threads[i].Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine($"Sold final {account1.AccountId}: {account1.Balance}");
            Console.WriteLine($"Sold final {account2.AccountId}: {account2.Balance}");
        }

        static void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount, int threadId)
        {
            Console.WriteLine($"Thread {threadId} încearcă să transfere {amount} de la {fromAccount.AccountId} la {toAccount.AccountId}...");
            lock (fromAccount)
            {
                Console.WriteLine($"Thread {threadId} a blocat {fromAccount.AccountId}.");
                lock (toAccount)
                {
                    Console.WriteLine($"Thread {threadId} a blocat {toAccount.AccountId}.");
                    if (fromAccount.Withdraw(amount))
                    {
                        toAccount.Deposit(amount);
                        Console.WriteLine($"Thread {threadId} a transferat {amount} de la {fromAccount.AccountId} la {toAccount.AccountId}.");
                    }
                    else
                    {
                        Console.WriteLine($"Thread {threadId} nu a putut transfera {amount} de la {fromAccount.AccountId} la {toAccount.AccountId}, sold insuficient.");
                    }
                }
                Console.WriteLine($"Thread {threadId} a eliberat blocarea pentru {toAccount.AccountId}.");
            }
            Console.WriteLine($"Thread {threadId} a eliberat blocarea pentru {fromAccount.AccountId}.");
        }
    }

    class BankAccount
    {
        public string AccountId { get; }
        public decimal Balance { get; private set; }
        public BankAccount(string accountId, decimal initialBalance)
        {
            AccountId = accountId;
            Balance = initialBalance;
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
