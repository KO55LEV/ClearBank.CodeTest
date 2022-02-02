using ClearBank.CodeTest.Application.Interfaces;
using ClearBank.CodeTest.Application.Services;
using ClearBank.CodeTest.Domain.Enums;
using ClearBank.CodeTest.Domain.Models;
using FluentAssertions;
using Xunit;

namespace ClearBank.CodeTest.Application.Tests.Services
{
    public class AccountValidationTests
    {
        private readonly IAccountValidation _accountValidation;

        public AccountValidationTests()
        {
            _accountValidation = new AccountValidation();
        }

        #region Schema Bacs

        [Fact]
        public void ValidateAccount_Account_Bacs_Scheme_Bacs_Returns_True()
        {
            // Arrange 
            var account = new Account()
            {
                AccountNumber = "234",
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
                Balance = 50,
                Status = AccountStatus.Live
            };
            
            // Act
            var result = _accountValidation.ValidateAccount(account, PaymentScheme.Bacs, 10);

            // Assert 
            result.Should().Be(true);
        }

        [Fact]
        public void ValidateAccount_Account_FasterPayments_Scheme_Bacs_Returns_False()
        {
            // Arrange 
            var account = new Account()
            {
                AccountNumber = "234",
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance = 50,
                Status = AccountStatus.Live
            };

            // Act
            var result = _accountValidation.ValidateAccount(account, PaymentScheme.Bacs, 10);

            // Assert 
            result.Should().Be(false);
        }

        [Fact]
        public void ValidateAccount_Account_Chaps_Scheme_Bacs_Returns_False()
        {
            // Arrange 
            var account = new Account()
            {
                AccountNumber = "234",
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance = 50,
                Status = AccountStatus.Live
            };

            // Act
            var result = _accountValidation.ValidateAccount(account, PaymentScheme.Bacs, 10);

            // Assert 
            result.Should().Be(false);
        }

        #endregion


        #region Schema FasterPayments

        [Fact]
        public void ValidateAccount_Account_Bacs_Scheme_FasterPayments_Returns_True()
        {
            // Arrange 
            var account = new Account()
            {
                AccountNumber = "234",
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
                Balance = 50,
                Status = AccountStatus.Live
            };

            // Act
            var result = _accountValidation.ValidateAccount(account, PaymentScheme.Bacs, 10);

            // Assert 
            result.Should().Be(true);
        }

        [Fact]
        public void ValidateAccount_Account_FasterPayments_Scheme_FasterPayments_Returns_False()
        {
            // Arrange 
            var account = new Account()
            {
                AccountNumber = "234",
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance = 50,
                Status = AccountStatus.Live
            };

            // Act
            var result = _accountValidation.ValidateAccount(account, PaymentScheme.Bacs, 10);

            // Assert 
            result.Should().Be(false);
        }

        [Fact]
        public void ValidateAccount_Account_Chaps_Scheme_FasterPayments_Returns_False()
        {
            // Arrange 
            var account = new Account()
            {
                AccountNumber = "234",
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance = 50,
                Status = AccountStatus.Live
            };

            // Act
            var result = _accountValidation.ValidateAccount(account, PaymentScheme.Bacs, 10);

            // Assert 
            result.Should().Be(false);
        }

        #endregion
    }
}
