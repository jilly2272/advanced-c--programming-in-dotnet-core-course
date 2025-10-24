namespace BankingApplication___Error_Handling;

public class BankAccounts(Account[] accounts)
{
    public bool ValidateAccount(string accountNumber)
    {
        if (accounts.Any(a => a.AccountNumber == accountNumber))
        {
            Console.WriteLine("Account found.");
            return true;
        }
        
        Console.WriteLine("Account not found.");
        return false;
    }

    public Account GetAccount(string accountNumber)
    {
        return accounts.First(a => a.AccountNumber == accountNumber);
    }
}