using System.Diagnostics;

namespace BankingApplication___Error_Handling;

public class Account(float balance, string accountNumber)
{
    private float _balance = balance;
    private string _accountNumber = accountNumber;
    public float Balance { get => _balance; set => _balance = value; }

    public string AccountNumber
    {
        get => _accountNumber;
        set {
            if (value.Length == 9)
            {
                _accountNumber = value;
            }
            else
                Console.WriteLine("Account numbers must be 9 digits long.");
        }
    }
}