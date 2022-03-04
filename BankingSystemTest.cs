using BankingSystem;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankingSystemTest
{
    /// <summary>
    /// Summary description for Banking Unit Tests.
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
        public void DepositToYourAccount_WhenProvidedWithUserDetailsAndDepositAmountIsGreaterThanDailyLimit_ShouldNotDepositToUserAccount()
        {
            // Arrange

            var mockRepository = new Mock<IBankAccount>();
            mockRepository.Setup(x => x.Balance).Returns(100);

            // Act

            var controller = new CheckingAccount(mockRepository.Object);
            var user = new User(11, "any", "ppp", "any@gmail.com", 97662990);
            controller.CreateAccount(user);

            controller.Deposit(100001, user);

            var bal = controller.Balance;

            // Assert
            Assert.IsNotNull(user.GetAccountBalance);
            Assert.AreEqual(0, bal);
        }

        [TestMethod]
        public void DepositToYourAccount_WhenProvidedWithUserDetailsAndDepositAmountIsNegative_ShouldNotDepositToUserAccount()
        {
            // Arrange

            var mockRepository = new Mock<IBankAccount>();
            mockRepository.Setup(x => x.Balance).Returns(100);

            // Act

            var controller = new CheckingAccount(mockRepository.Object);
            var user = new User(11, "any", "ppp", "any@gmail.com", 97662990);
            controller.CreateAccount(user);

            controller.Deposit(-11, user);

            var bal = controller.Balance;

            // Assert
            Assert.IsNotNull(user.GetAccountBalance);
            Assert.AreEqual(0, bal);
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
        public void WithDrawAmountFromAccount_WhenProvidedWithValidDetails_ShouldWithdrawRequestedAmount()
        {
            // Arrange

            var user = new User(99, "yui", "dds", "aihhuy@rediff.com", 97662990);
            var accountType = 'S';

            // Act
            AccountOperations.WithdrawBalance(ref user, 100, accountType);

            // Assert
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

        [TestMethod]
        public void SetupCheckingAccount_WhenProvidedWithUserDetailsAndAccountType_ShouldSetupUserAccount()
        {
            // Arrange

            var user = new User(11, "dha", "skkk", "aiy@yahoo.com", 97662990);
            var accountType = 'C';

            // Act
            AccountOperations.SetupAnAccount(ref user, accountType);

            // Assert
            Assert.IsNotNull(user.UserAccount[0].AccountNo);
            Assert.AreEqual('C', user.UserAccount[0].AccountType);
        }

        [TestMethod]
        public void SetupSavingsAccount_WhenProvidedWithUserDetailsAndAccountType_ShouldSetupUserAccount()
        {
            // Arrange

            var user = new User(99, "yui", "dds", "aihhuy@rediff.com", 97662990);
            var accountType = 'S';

            // Act
            AccountOperations.SetupAnAccount(ref user, accountType);

            // Assert
            Assert.IsNotNull(user.UserAccount[0].AccountNo);
            Assert.AreEqual('S', user.UserAccount[0].AccountType);
        }

        [TestMethod]
        public void DepositToYourCurrentAccount_WhenProvidedWithUserDetails_ShouldDepositIFProvidedAmountIsInLimit()
        {
            // Arrange

            var user = new User(99, "yui", "dds", "aihhuy@rediff.com", 97662990);
            var accountType = 'C';

            // Act
            AccountOperations.DepositToYourAccount(ref user, 1000, 'C');

            // Assert
        }
    }
}