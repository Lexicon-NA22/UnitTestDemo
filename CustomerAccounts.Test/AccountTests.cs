using System;
using UnitTestDemo;
using Xunit;

namespace CustomerAccounts.Test
{
    public class AccountTests
    {
        [Fact]
        public void SpendMoney_AmountIsLessThanZero_Throws()
        {
            // Arrage
            var startingBalance = 0;
            var spendingAmount = -100.0;
            var account = new Account("Test Testsson", startingBalance);

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.SpendMoney(spendingAmount));
        }

        [Fact]
        public void SpendPoints_AmountIsLessThanBalance_Throws()
        {
            // Arrage
            var startingBalance = 10;
            var spendingAmount = 20;
            var account = new Account("Test Testsson", startingBalance);
            var expected = "Amount of points spent is more than current point balance. (Parameter 'nrOfPoints')";

            // Act and Assert
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => account.SpendPoints(spendingAmount));
            Assert.Equal(expected, error.Message);

        }

        [Fact]
        public void SpendPoints_ReducePointBalance()
        {
            // Arrage
            var startingBalance = 10;
            var spendingAmount = 5;
            var expected = 5;
            var account = new Account("Test Testsson", startingBalance);

            // Act
            account.SpendPoints(spendingAmount);
            var actual = account.PointBalance;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SpendMoney_GetOnePointPer100Crowns()
        {
            var startingBalance = 10;
            var spendingAmount = 500.0;
            var expected = 15;
            var account = new Account("Test Testsson", startingBalance);

            account.SpendMoney(spendingAmount);
            var actual = account.PointBalance;

            Assert.Equal(expected, actual);

        }
    }
}
