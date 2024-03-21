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

        // Act and assert
        Assert.That(() => account.Debit(debitAmount), Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}