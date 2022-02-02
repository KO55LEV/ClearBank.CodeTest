using ClearBank.CodeTest.Domain.Models;
using ClearBank.CodeTest.Infrastructure.Services;
using FluentAssertions;
using Xunit;

namespace ClearBank.CodeTest.Infrastructure.Tests.Services
{
    public class AccountDataStoreServiceTests
    {
        private readonly AccountDataStoreService _accountDataStoreService;

        public AccountDataStoreServiceTests()
        {
            _accountDataStoreService = new AccountDataStoreService();
        }

        [Fact]
        public void GetAccount_Returns_NewAccount()
        {
            // Arrange 
            var accountNumber = "123432552";

            // Act
            var account = _accountDataStoreService.GetAccount(accountNumber);

            // Assert 
            var expectedResult = new Account();

            account.AccountNumber.Should().Be(expectedResult.AccountNumber);
            account.Balance.Should().Be(expectedResult.Balance);
            account.Status.Should().Be(expectedResult.Status);
            account.AllowedPaymentSchemes.Should().Be(expectedResult.AllowedPaymentSchemes);

        }
    }
}
