namespace BankingApplication___Error_Handling;

public class TransactionFailureException : Exception
{
    public TransactionFailureException(string message) : base(message)
    {
    }
}

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message)
    {
    }
}

public class NetworkErrorException : Exception
{
    public NetworkErrorException(string message) : base(message)
    {
    }
}