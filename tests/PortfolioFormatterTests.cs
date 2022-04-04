using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Kata.Tests
{
    public class A_PortfolioFormatter
    {
        private readonly StandardFormatter _formatter;
        private readonly PortfolioItem _defaultPortfolioItem;
        private readonly List<PortfolioItem> _portfolioItems = new List<PortfolioItem>();

        public A_PortfolioFormatter()
        {
            _formatter = new StandardFormatter();
            _defaultPortfolioItem = new PortfolioItem(
                CompanyConstants.OLD_SCHOOL_WATERFALL,
                500,
                5.75m,
                2875m,
                new Operation(
                    Stock.WaterFall,
                    -500,
                    new DateTime(2018, 12, 11))
                );
        }


        [Fact]
        public void Formats_The_Header_Of_An_Empty_Portfolio()
        {
            // Arrange

            // Act
            var formattedPortfolio = _formatter.FormatItems(_portfolioItems);
            // Assert
            formattedPortfolio.Should().Be(
                "company | shares | current price | current value | last operation\r\n");
        }

        [Fact]
        public void Formats_A_Portfolio()
        {
            // Arrange
            _portfolioItems.Add(_defaultPortfolioItem);
            // Act
            var formattedPortfolio = _formatter.FormatItems(_portfolioItems);
            // Assert
            formattedPortfolio.Should().Be(
                "company | shares | current price | current value | last operation\r\n" +
                "Old School Waterfall Software LTD | 500 | $5,75 | $2875,00 | sold 500 on 11/12/2018\r\n");
        }
    }
}
