using System;

namespace AbstractFactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Abstract Factory Method!");

            //object creation role lies with the factory it creates the correct objects behind the scene
            //in this case returning the correct savings account, the logic is abstracted from the client
            //all we do here is pass in an account number and it knew whether or not to return a citi or national account.
            var factory = new SavingsAccountFactory() as ICreditUnionFactory; //this can be handled using dependency injection
            var citiAccount = factory.GetSavingsAccount("CITI-123");
            var nationalAccount = factory.GetSavingsAccount("NATIONAL-456");

            Console.WriteLine($"My citi balance is ${citiAccount.Balance}");
            Console.WriteLine($"My national balance is ${nationalAccount.Balance}");
        }
    }

       //Product
    public abstract class ISavingsAccount 
    {
        public decimal Balance { get; set; }
    }

    //Concrete Product
    public class CitiSavingsAccount : ISavingsAccount
    {   
        public CitiSavingsAccount ()
        {
            Balance = 5000;
        }
    }

    //Concrete Product
    public class NationalSavingsAccount : ISavingsAccount
    {   
        public NationalSavingsAccount ()
        {
            Balance = 2000;
        }
    }

    //Creator
    interface ICreditUnionFactory
    {
        ISavingsAccount GetSavingsAccount(string accountNumber);
    }

    //Concrete Creators
    //this is the essense of the factory method because it contains the logic that determines what type is going to be sent back 
    
    public class SavingsAccountFactory : ICreditUnionFactory
    {
        public ISavingsAccount GetSavingsAccount(string accountNumber)
        {
            if(accountNumber.Contains("CITI")) return new CitiSavingsAccount();
            else if(accountNumber.Contains("NATIONAL")) return new NationalSavingsAccount();
            else throw new ArgumentException ("Invalid Account Number");
        }
    }
}
