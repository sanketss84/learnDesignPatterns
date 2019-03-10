using System;

namespace InterfaceFactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Interface Factory Method!");

            var factory = new SavingsAccountFactory() as ICreditUnionFactory;
            var citiAccount = factory.GetSavingsAccount("CITI-123");
            var nationalAccount = factory.GetSavingsAccount("NATIONAL-456");

            Console.WriteLine($"My citi balance is ${citiAccount.Balance}");
            Console.WriteLine($"My national balance is ${nationalAccount.Balance}");
        }
    }

        //Product
    public interface ISavingsAccount 
    {
        decimal Balance { get; set; }
    }

    //Concrete Product
    public class CitiSavingsAccount : ISavingsAccount
    {   
        public CitiSavingsAccount ()
        {
            Balance = 4000;
        }

        public decimal Balance { get; set; }
    }

    //Concrete Product
    public class NationalSavingsAccount : ISavingsAccount
    {   
        public NationalSavingsAccount ()
        {
            Balance = 1000;
        }

        public decimal Balance { get; set; }
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
