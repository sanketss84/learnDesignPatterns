namespace InterfaceFactory
{
    // Abstract Factory - interface
    public interface ICreditUnionFactory
    {
        ISavingsAccount CreateSavingsAccount();

        ILoanAccount CreateLoanAccount();
    }

    // Abstract Product A
    public interface ILoanAccount { }

    // Abstract Product B
    public interface ISavingsAccount { }
}