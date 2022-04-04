using FluentAssertions;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;

namespace Kata.Tests
{
    public class A_PortfolioService
    {
        [Fact]
        public void Prints_A_Portfolio()
        {

            // Arrange
            var mockDateTime = new Mock<DateTimeProvider>();
            var mockPrinter = new Mock<PortfolioPrinter>();

            var operationService = new OperationBroker();
            var portfolioService =
                new PortfolioService(operationService, mockPrinter.Object, mockDateTime.Object);

            mockDateTime.Setup(x => x.Now()).Returns(new DateTime(1990, 2, 14));
            portfolioService.Buy(CompanyConstants.OLD_SCHOOL_WATERFALL, 1000);

            mockDateTime.Setup(x => x.Now()).Returns(new DateTime(2016, 6, 9));
            portfolioService.Buy(CompanyConstants.CRAFTER_MASTERS, 400);

            mockDateTime.Setup(x => x.Now()).Returns(new DateTime(2018, 12, 10));
            portfolioService.Buy(CompanyConstants.XP_PRACTITIONERS, 700);

            mockDateTime.Setup(x => x.Now()).Returns(new DateTime(2018, 12, 11));
            portfolioService.Sell(CompanyConstants.OLD_SCHOOL_WATERFALL, 500);

            // Act
            portfolioService.Print();
            // Assert
            mockPrinter.Verify(
                mock => mock.PrintItems(
                    It.IsAny<IEnumerable<PortfolioItem>>()), Times.Once()
                    );
        }
    }
}
