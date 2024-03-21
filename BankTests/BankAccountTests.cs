using BankAccountNS;

namespace BankTests;

public class BankAccountTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Debit_WithValidAmount_UpdatesBalance()
    {
        // Arrange
        double beginningBalance = 11.99;
        double debitAmount = 4.55;
        double expected = 7.44;
        BankAccount account = new("Mr. Bryan Walton", beginningBalance);

        // Act
        account.Debit(debitAmount);

        // Assert
        double actual = account.Balance;
        Assert.That(actual, Is.EqualTo(expected).Within(0.001), "Account not debited correctly");
    }

    [Test]
    public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
    {
        // Arrange
        double beginningBalance = 11.99;
        double debitAmount = -100.00;
        BankAccount account = new("Mr. Bryan Walton", beginningBalance);

        // Act
        try
        {
            account.Debit(debitAmount);
        }
        catch (ArgumentOutOfRangeException e)
        {
            // Assert
            StringAssert.Contains(BankAccount.DebitAmountLessThanZeroMessage, e.Message);
            return;
        }

        Assert.Fail("The expected exception was not thrown.");
    }

    [Test]
    public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
    {
        // Arrange
        double beginningBalance = 11.99;
        double debitAmount = 20.0;
        BankAccount account = new("Mr. Bryan Walton", beginningBalance);

        // Act
        try
        {
            account.Debit(debitAmount);
        }
        catch (ArgumentOutOfRangeException e)
        {
            // Assert
            StringAssert.Contains(BankAccount.DebitAmountExceedsBalanceMessage, e.Message);
            return;
        }

        Assert.Fail("The expected exception was not thrown.");
    }
}