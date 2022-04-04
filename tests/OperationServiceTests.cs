using FluentAssertions;
using System;
using Xunit;

namespace Kata.Tests
{
    public class A_OperationService
    {
        private readonly DateTime _defaultDateTime;
        private readonly OperationBroker _service;
        private Operation _defaultBuyOperation;
        private Operation _defaultSellOperation;

        public A_OperationService()
        {
            _defaultDateTime = new DateTime(2000, 1, 1);
            _service = new OperationBroker();

            _defaultBuyOperation = new OperationParser().CreateOperation(
                                        CompanyConstants.OLD_SCHOOL_WATERFALL,
                                        1000,
                                        _defaultDateTime);
            _defaultSellOperation = new OperationParser().CreateOperation(
                                        CompanyConstants.OLD_SCHOOL_WATERFALL,
                                        -500,
                                        _defaultDateTime);
        }

        [Fact]
        public void Buys_A_Stock()
        {
            // Arrange

            // Act
            _service.SaveOperation(_defaultBuyOperation);
            // Assert
            _service.GetHistory().Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Sells_A_Stock()
        {
            // Arrange

            // Act
            _service.SaveOperation(_defaultBuyOperation);
            _service.SaveOperation(_defaultSellOperation);
            // Assert
            _service.GetHistory().Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Gets_Quantity_Of_A_OwnedStock()
        {
            // Arrange

            // Act
            _service.SaveOperation(_defaultBuyOperation);
            _service.SaveOperation(_defaultSellOperation);
            // Assert
            _service.GetStockQuantity(CompanyConstants.OLD_SCHOOL_WATERFALL).Should().Be(500);
        }

        [Fact]
        public void Gets_Last_Operation_Of_A_Stock()
        {
            // Arrange
            var expectedOperation = new OperationParser().CreateOperation(
                CompanyConstants.OLD_SCHOOL_WATERFALL,
                -500,
                new DateTime(2018, 12, 11));
            var buyOperation = new OperationParser().CreateOperation(
                CompanyConstants.OLD_SCHOOL_WATERFALL,
                1000,
                new DateTime(1990, 2, 14));
            var sellOperation = new OperationParser().CreateOperation(
                CompanyConstants.OLD_SCHOOL_WATERFALL,
                -500,
                new DateTime(2018, 12, 11));

            // Act
            _service.SaveOperation(buyOperation);
            _service.SaveOperation(sellOperation);
            // Assert
            _service.GetLastOperation(CompanyConstants.OLD_SCHOOL_WATERFALL).Should().Be(expectedOperation);
        }

        [Fact]
        public void Gets_Value_Of_A_Owned_Stock()
        {
            // Arrange

            // Act
            _service.SaveOperation(_defaultBuyOperation);
            _service.SaveOperation(_defaultSellOperation);
            // Assert
            _service.GetStockTotalValue(CompanyConstants.OLD_SCHOOL_WATERFALL).Should().Be(2875m);
        }

        [Fact]
        public void Gets_Stock_Types()
        {
            // Arrange
            var buyOperation = new OperationParser().CreateOperation(
                CompanyConstants.OLD_SCHOOL_WATERFALL,
                1000,
                _defaultDateTime);
            var sellOperation = new OperationParser().CreateOperation(
                CompanyConstants.CRAFTER_MASTERS,
                -500,
                _defaultDateTime);
            // Act
            _service.SaveOperation(buyOperation);
            _service.SaveOperation(sellOperation);
            // Assert
            _service.GetStockTypes().Should().NotBeEmpty().And.HaveCount(2);
            _service.GetStockTypes().Should().ContainInOrder(Stock.WaterFall, Stock.Crafter);
        }

        [Fact]
        public void Gets_Portfolio()
        {
            // Arrange
            var portfolioItem = new PortfolioItem(
                CompanyConstants.OLD_SCHOOL_WATERFALL,
                500,
                5.75m,
                2875m,
                new Operation(
                    Stock.WaterFall,
                    -500,
                    new DateTime(2018, 12, 11))
                );

            var buyOperation = new OperationParser().CreateOperation(
                                        CompanyConstants.OLD_SCHOOL_WATERFALL,
                                        1000,
                                        new DateTime(1990, 2, 14));
            var sellOperation = new OperationParser().CreateOperation(
                                        CompanyConstants.OLD_SCHOOL_WATERFALL,
                                        -500,
                                        new DateTime(2018, 12, 11));

            // Act
            _service.SaveOperation(buyOperation);
            _service.SaveOperation(sellOperation);
            // Assert
            _service.GetPortfolio().Should().NotBeEmpty().And.HaveCount(1);
            _service.GetPortfolio().Should().Equal(portfolioItem);
        }
    }
}
