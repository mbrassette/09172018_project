using System;
using Xunit;

namespace Archon.Interview.Tests
{
    public class PropertyTests
    {
        [Theory]
        [InlineData("208100736", "1018 ROYAL ST                                                                                       ", "#3                                                                                                  ")]
        [InlineData("208100730", "1023 CHARTRES ST                                                                                    ", "#5                                                                                                  ")]
        public void IsApartmentTrue(string accountNumber, string address1, string address2)
        {
            String AccountNumber = accountNumber;
            String AddressLine1 = address1;
            String AddressLine2 = address2;
            Property property = new Property(AccountNumber, AddressLine1, AddressLine2);
            Assert.True(property.IsApartment);
        }

        [Theory]
        [InlineData("102100701", "1000 S PETERS ST                                                                                    ", "                                                                                                    ")]
        [InlineData("208100601", "1001 DECATUR ST                                                                                     ", "                                                                                                    ")]
        public void IsApartmentFalse(string accountNumber, string address1, string address2)
        {
            String AccountNumber = accountNumber;
            String AddressLine1 = address1;
            String AddressLine2 = address2;
            Property property = new Property(AccountNumber, AddressLine1, AddressLine2);
            Assert.False(property.IsApartment);
        }

        [Theory]
        [InlineData("208100736", "1018 ROYAL ST                                                                                       ", "#3                                                                                                  ")]
        [InlineData("208100713", "1026 ROYAL ST                                                                                       ", "                                                                                                    ")]
        public void IsOnStreetTrue(string accountNumber, string address1, string address2)
        {
            String AccountNumber = accountNumber;
            String AddressLine1 = address1;
            String AddressLine2 = address2;
            Property property = new Property(AccountNumber, AddressLine1, AddressLine2);
            Assert.True(property.IsOnStreet("Royal"));
        }

        [Theory]
        [InlineData("208100736", "1018 ROYAL ST                                                                                       ", "#3                                                                                                  ")]
        [InlineData("208100713", "1026 ROYAL ST                                                                                       ", "                                                                                                    ")]
        public void IsOnStreetFalse(string accountNumber, string address1, string address2)
        {
            String AccountNumber = accountNumber;
            String AddressLine1 = address1;
            String AddressLine2 = address2;
            Property property = new Property(AccountNumber, AddressLine1, AddressLine2);
            Assert.False(property.IsOnStreet("Decatur"));
        }

        [Theory]
        [InlineData("208100736", "1018 ROYAL ST                                                                                       ", "#3                                                                                                  ")]
        [InlineData("208100713", "1026 ROYAL ST                                                                                       ", "                                                                                                    ")]
        public void IsOnStreetExceptions(string accountNumber, string address1, string address2)
        {
            String AccountNumber = accountNumber;
            String AddressLine1 = address1;
            String AddressLine2 = address2;
            Property property = new Property(AccountNumber, AddressLine1, AddressLine2);
            Assert.Throws<ArgumentException>(() => property.IsOnStreet("   "));
            Assert.Throws<ArgumentException>(() => property.IsOnStreet(null));
        }
    }
}
