using System.Security.Cryptography;

namespace BankingApplication___Error_Handling;

public static class BankingTransactions
{
    public static void WithdrawFunds(float withdrawalAmount, Account bankAccount)
    {
        try
        {
            Console.WriteLine("Attempting to withdraw funds...");
            
            int networkError = RandomNumberGenerator.GetInt32(1, 10);
            if (networkError == 10)
                throw new NetworkErrorException("A network error occurred. Try again");
            
            if (bankAccount.Balance < 0 || withdrawalAmount > bankAccount.Balance)
                throw new InsufficientFundsException($"Insufficient funds. Current balance: {bankAccount.Balance}.");
            
            if (withdrawalAmount <= 0)
                throw new TransactionFailureException("Please enter a valid amount to withdraw.");
            
            bankAccount.Balance -= withdrawalAmount;
            Console.WriteLine($"Withdrawal successful. New balance: {bankAccount.Balance}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void DepositFunds(float depositAmount, Account bankAccount)
    {
        try
        {
            Console.WriteLine("Attempting to deposit funds...");
            
            int networkError = RandomNumberGenerator.GetInt32(1, 10);
            if (networkError == 10)
                throw new NetworkErrorException("A network error occurred. Try again");
            
            if(depositAmount <= 0)
                throw new TransactionFailureException("Please enter a valid amount to deposit.");
            
            bankAccount.Balance += depositAmount;
            Console.WriteLine($"Deposit successful. New balance: {bankAccount.Balance}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}