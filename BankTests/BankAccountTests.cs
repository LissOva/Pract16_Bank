using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance() //Валидные значения
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange() //Сумма по дебиту меньшу нуля
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
            account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange() //Сумма по дебиту больше баланса
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance() //Валидные значения кредита, больше нуля
        { 
            //Arrage
            double beginningBalance = 0;
            double creditAmount = 500;
            double expected = 500;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            //Act
            account.Credit(creditAmount);
            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.0, "Account not credited correctly");
        }

        [TestMethod]
        public void Credit_WhenCreditEqualZero_UpdatesBalance() //Валидные значения кредита, равен нулю
        {
            //Arrage
            double beginningBalance = 500;
            double creditAmount = 0;
            double expected = 500;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            //Act
            account.Credit(creditAmount);
            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.0, "Account not credited correctly");
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_SholdThrowArgumentOutOfRangeException() { //Кредит меньше нуля
            //Arrage
            double beginningBalance = 0;
            double creditAmount = -1;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            //Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
             account.Credit(creditAmount));
        }
    }
}