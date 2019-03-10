using System;
using System.Collections.Generic;

namespace InterfaceFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            Console.WriteLine("Hello Abstract Factory!");

            List<string> accountNumbers = new List<string> { "CITI-456", "NATIONAL-987", "CHASE-222" };

            foreach (var accountNumber in accountNumbers)
            {
                ICreditUnionFactory creditUnionFactory = CreditUnionFactoryProvider.GetCreditUnionFactory(accountNumber);

                if (creditUnionFactory == null)
                {
                    Console.WriteLine("Sorry. This credit union account number" + " ' {0} ' is invalid.", (accountNumber));
                }
                else
                {
                    ILoanAccount loan = creditUnionFactory.CreateLoanAccount();
                    ISavingsAccount savings = creditUnionFactory.CreateSavingsAccount();
                }
            }

            Console.ReadLine();           

        }
    }


}
