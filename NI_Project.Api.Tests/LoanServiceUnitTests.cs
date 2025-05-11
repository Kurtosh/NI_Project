using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NI_Project.Api.Services;
using NI_Project.Shared;

namespace NI_Project.Api.Tests
{
    public class LoanServiceUnitTests
    {
        [Fact]
        public void InvalidLoan_ShouldThrowArgumentNullException_ThrowsArgumentNullException()
        {
            var service = new LoanService();
            Assert.Throws<ArgumentNullException>(() => service.Add(null));
        }

        [Theory]
        [InlineData(null, "b1")]
        [InlineData("r1", null)]
        [InlineData("", "b1")]
        [InlineData("r1", "")]
        public void NullOrEmptyReaderIdOrBookId_ShouldThrowArgumentNullException_ThrowsArgumentNullException(string readerId, string bookId)
        {
            var service = new LoanService();
            Assert.Throws<ArgumentNullException>(() => service.Get(readerId, bookId));
        }

        [Fact]
        public void NotExistingLoan_ShouldThrowKeyNotFoundException_ThrowsKeyNotFoundException()
        {
            var service = new LoanService();
            Assert.Throws<KeyNotFoundException>(() => service.Get("notexist", "missingbook"));
        }
    }
}
