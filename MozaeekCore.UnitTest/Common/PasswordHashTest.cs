using FluentAssertions;
using MozaeekCore.Common.Crypto;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MozaeekCore.UnitTest.Common
{
    public class PasswordHashTest
    {
        [Fact]
        public void IsCorrectPassword()
        {
            IPasswordService passwordService = new PasswordService();
            var password = "p@ssw0rd";
            var hashResult = passwordService.GenerateHashPassword(password);
            var verify = passwordService.Verify(password, hashResult.hash,hashResult.salt);
            verify.Should().Be(true);
        }
        [Fact]
        public void IsNotCorrectPassword()
        {
            IPasswordService passwordService = new PasswordService();
            var password = "p@ssw0rd";
            var hashResult = passwordService.GenerateHashPassword(password);
            var incorrectPassword = "p@ssword";
            var verify = passwordService.Verify(incorrectPassword, hashResult.hash,hashResult.salt);
            verify.Should().Be(false);
        }
    }
}
