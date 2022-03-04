using System;
using System.Text;
using System.Collections.Generic;
using BankingSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankingSystemTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class BankingSystemTest
    {
        [TestMethod]
        public void CreateCheckingAccount_WhenPassedValidDetails_ShouldCreateUserAccount()
        {
            // Arrange

            var mockRepository = new Mock<IBankAccount>();
            mockRepository.Setup(x => x.CreateAccount(new User(11, "anc", "tgt", "tcd@gmail.com", 97662990)));

            // Act
            var controller = new CheckingAccount(mockRepository.Object);
            var user = new User(11, "any", "ppp", "any@gmail.com", 97662990);
            controller.CreateAccount(user);

            // Assert
            Assert.IsNotNull(user.UserAccount[0].AccountNo);
            Assert.AreEqual('C', user.UserAccount[0].AccountType);
        }

        [TestMethod]
        public void CreateSavingsAccount_WhenPassedValidDetails_ShouldCreateUserAccount()
        {
            // Arrange

            var mockRepository = new Mock<IBankAccount>();
            mockRepository.Setup(x => x.CreateAccount(new User(11, "xxx", "ppp", "ll@gmail.com", 97662990)));

            // Act
            //IBankAccount currentAccount = new CheckingAccount();
            //var user = new User(11, "any", "ppp", "any@gmail.com", 97662990);
            //currentAccount.CreateAccount(user);

            var controller = new SavingAccount(mockRepository.Object);
            var user = new User(11, "any", "ppp", "any@gmail.com", 97662990);
            controller.CreateAccount(user);


            // Assert
            Assert.IsNotNull(user.UserAccount[0].AccountNo);
            Assert.AreEqual('S', user.UserAccount[0].AccountType);
        }

        
        [TestMethod]
        public void SetupAccount_WhenPassedValidDetails_ShouldCreateUserAccount()
        {
            // Arrange

            var mockRepository = new Mock<IBankAccount>();
            mockRepository.Setup(x => x.CreateAccount(new User(11, "xxx", "ppp", "ll@gmail.com", 97662990)));

            // Act
            var controller = new CheckingAccount(mockRepository.Object);
            var user = new User(11, "any", "ppp", "any@gmail.com", 97662990);
            controller.CreateAccount(user);

            // Assert
            Assert.IsNotNull(user.UserAccount[0].AccountNo);
            Assert.AreEqual('C', user.UserAccount[0].AccountType);
        }

        [TestMethod]
        public void GetAccountBalance_WhenProvidedWithAccountInformation_WhenDepositedWithSomeAmount_ShouldReturnTheValidAmount()
        {
            // Arrange

            var mockRepository = new Mock<IBankAccount>();
            mockRepository.Setup(x => x.Balance).Returns(100);

            // Act

            var controller = new CheckingAccount(mockRepository.Object);
            var user = new User(11, "any", "ppp", "any@gmail.com", 97662990);
            controller.CreateAccount(user);

            controller.Deposit(100, user);

            var bal = controller.Balance;

            // Assert
            Assert.IsNotNull(user.GetAccountBalance);
            Assert.AreEqual(100, bal);
        }

        [TestMethod]
        public void WithdrawBalance_WhenAccountContainsOnlyHundredDollars_ShouldNotWithdrawBalanceLessThanLimit()
        {
            // Arrange

            var mockRepository = new Mock<IBankAccount>();
            mockRepository.Setup(x => x.Balance).Returns(100);

            // Act

            var controller = new CheckingAccount(mockRepository.Object);
            var user = new User(11, "dha", "skkk", "aiy@yahoo.com", 97662990);
            controller.CreateAccount(user);

            controller.Deposit(100, user);
            controller.Withdraw(100, user); // can't withdraw the max 100 amount.

            // Assert
            Assert.IsNotNull(user.GetAccountBalance);
            Assert.AreEqual(100, controller.Balance);
        }

        [TestMethod]
        public void WithdrawBalance_WhenAccountContainsOnlyThousandDollarsAndWithdrawalAmountIsMoreThanNinetyPercent_ShouldNotBeWithdrawn()
        {
            // Arrange

            var mockRepository = new Mock<IBankAccount>();
            mockRepository.Setup(x => x.Balance).Returns(1000);

            // Act

            var controller = new CheckingAccount(mockRepository.Object);
            var user = new User(11, "dha", "skkk", "aiy@yahoo.com", 97662990);
            controller.CreateAccount(user);

            controller.Deposit(1000, user);
            controller.Withdraw(950, user); // can't withdraw the max 100 amount.

            // Assert
            Assert.IsNotNull(user.GetAccountBalance);
            Assert.AreEqual(1000, controller.Balance);
        }
    }
}
