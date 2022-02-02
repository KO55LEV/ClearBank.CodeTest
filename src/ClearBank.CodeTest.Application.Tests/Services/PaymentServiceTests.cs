using ClearBank.CodeTest.Application.Interfaces;
using ClearBank.CodeTest.Application.Models.Configuration;
using ClearBank.CodeTest.Application.Models.Requests;
using ClearBank.CodeTest.Application.Services;
using ClearBank.CodeTest.Domain.Enums;
using ClearBank.CodeTest.Domain.Models;
using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using System;
using Xunit;

namespace ClearBank.CodeTest.Application.Tests.Services
{
    public class PaymentServiceTests
    {
        private readonly IAccountValidation _accountValidation;
        private readonly IDataStoreServiceFactory _dataStoreServiceFactory;
        private readonly IPaymentService _paymentService;

        public PaymentServiceTests()
        {
            var serviceConfig = new PaymentServiceSettings()
            {
                DataStoreType = "Backup"
            };

            var options = Substitute.For<IOptions<PaymentServiceSettings>>();
            options.Value.Returns(serviceConfig);

            _accountValidation = Substitute.For<IAccountValidation>();
            _dataStoreServiceFactory = Substitute.For<IDataStoreServiceFactory>();

            _paymentService = new PaymentService(options, _dataStoreServiceFactory, _accountValidation);
        }

        [Fact]
        public void MakePayment_ValidateAccount_True_Returns_Positive_Result()
        {
            // Arrange 
            var request = new MakePaymentRequest()
            {
                CreditorAccountNumber = "1234",
                DebtorAccountNumber = "5485",
                Amount = 12,
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.FasterPayments
            };

            var dataStore = Substitute.For<IDataStore>();
            dataStore.GetAccount(Arg.Any<string>()).Returns(new Account());

            _dataStoreServiceFactory.GetDataStore(Arg.Any<string>()).Returns(dataStore);

            _accountValidation.ValidateAccount(Arg.Any<Account>(), Arg.Any<PaymentScheme>(), Arg.Any<decimal>()).Returns(true);

            // Act
            var result = _paymentService.MakePayment(request);

            // Assert 
            result.Success.Should().Be(true);
        }

        [Fact]
        public void MakePayment_ValidateAccount_False_Returns_Negative_Result()
        {
            // Arrange 
            var request = new MakePaymentRequest()
            {
                CreditorAccountNumber = "8487",
                DebtorAccountNumber = "558df",
                Amount = 12,
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.FasterPayments
            };

            var dataStore = Substitute.For<IDataStore>();
            dataStore.GetAccount(Arg.Any<string>()).Returns(new Account());

            _dataStoreServiceFactory.GetDataStore(Arg.Any<string>()).Returns(dataStore);

            _accountValidation.ValidateAccount(Arg.Any<Account>(), Arg.Any<PaymentScheme>(), Arg.Any<decimal>()).Returns(false);

            // Act
            var result = _paymentService.MakePayment(request);

            // Assert 
            result.Success.Should().Be(false);
        }
    }
}
