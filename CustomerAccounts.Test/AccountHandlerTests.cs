using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using UnitTestDemo;
using Xunit;

namespace CustomerAccounts.Test
{
    public class AccountHandlerTests
    {
        [Fact]
        public void GiveDiscount_BasicCustomer()
        {
            var account = new Account("Test Testsson", 10);
            Mock<ILevelChecker> mockLevelChecker = new Mock<ILevelChecker>();
            mockLevelChecker.Setup(x => x.CheckLevel(account)).Returns(CustomerLevel.Basic);
            var handler = new AccountHandler(mockLevelChecker.Object);

            var expected = 0;
            var actual = handler.GiveDiscount(account);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GiveDiscount_GoldCustomer()
        {
            var account = new Account("Test Testsson", 60);
            Mock<ILevelChecker> mockLevelChecker = new Mock<ILevelChecker>();
            mockLevelChecker.Setup(x => x.CheckLevel(account)).Returns(CustomerLevel.Gold);
            var handler = new AccountHandler(mockLevelChecker.Object);

            var expected = 30;
            var actual = handler.GiveDiscount(account);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HowManyPointsToNextLevel_BasicCustomer()
        {
            // Arrage
            var account = new Account("Test Testsson", 0);
            Mock<ILevelChecker> mockLevelChecker = new Mock<ILevelChecker>();
            mockLevelChecker.Setup(x => x.CheckLevel(account)).Returns(CustomerLevel.Basic);
            mockLevelChecker.Setup(x => x.Gold).Returns(50);
            var handler = new AccountHandler(mockLevelChecker.Object);

            // Act
            var expected = 50;
            int actual = handler.HowManyPointsToNextLevel(account);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HowManyPointsToNextLevel_GoldCustomer()
        {
            // Arrage
            var account = new Account("Test Testsson", 50);
            Mock<ILevelChecker> mockLevelChecker = new Mock<ILevelChecker>();
            mockLevelChecker.Setup(x => x.CheckLevel(account)).Returns(CustomerLevel.Gold);
            mockLevelChecker.Setup(x => x.Platinum).Returns(200);
            var handler = new AccountHandler(mockLevelChecker.Object);

            // Act
            var expected = 150;
            int actual = handler.HowManyPointsToNextLevel(account);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
