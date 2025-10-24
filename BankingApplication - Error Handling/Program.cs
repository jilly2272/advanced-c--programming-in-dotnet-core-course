//Objective: Develop a banking application in C# that allows users to deposit and withdraw money from their account. Start with an initial deposit of 1000 and implement advanced error handling to deal with scenarios such as insufficient funds, invalid transactions, and simulated network failures during withdrawals.

using BankingApplication___Error_Handling;

public static class Program
{
    public static void Main(string[] args)
    {
        //initialising bank accounts
        Account exampleAccount1 = new Account(1000, "123456789");
        Account exampleAccount2 = new Account(1000, "987654321");
        Account exampleAccount3 = new Account(1000, "135792468");
        BankAccounts bankAccounts = new BankAccounts([exampleAccount1, exampleAccount2, exampleAccount3]);
        bool running = true;

        Console.WriteLine("Please input your bank account number to proceed:");
        string accountNumberInput = Console.ReadLine();
        while (string.IsNullOrEmpty(accountNumberInput) && !bankAccounts.ValidateAccount(accountNumberInput))
        {
            Console.WriteLine("Please enter a valid account number.");
            accountNumberInput = Console.ReadLine();
        }

        Account account = bankAccounts.GetAccount(accountNumberInput);
        Console.WriteLine($"Welcome to your bank account {account.AccountNumber}. Your current balance is {account.Balance}.");

        while (running)
        {
            Console.WriteLine("Would you like to 1. Deposit, 2. Withdraw, or 3. Exit?");
            string userInput = Console.ReadLine();
            while (string.IsNullOrEmpty(userInput) && (userInput != "1" && userInput != "2" && userInput != "3"))
            {
                Console.WriteLine("Please select option 1, 2, or 3.");
                userInput = Console.ReadLine();
            }

            Console.WriteLine("Please enter the amount you would like to deposit or withdraw:");
            string amountInput = Console.ReadLine();
            while (string.IsNullOrEmpty(amountInput) && !int.TryParse(amountInput, out int amount) && amount <= 0)
            {
                Console.WriteLine("Please enter a valid amount.");
                amountInput = Console.ReadLine();
            }

            switch (userInput)
            {
                case "1":
                    BankingTransactions.DepositFunds(float.Parse(amountInput), account);
                    break;
                case "2":
                    BankingTransactions.WithdrawFunds(float.Parse(amountInput), account);
                    break;
                case "3":
                    running = false;
                    break;
            }
        }
    }
}