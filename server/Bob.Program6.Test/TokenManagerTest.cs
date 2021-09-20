using Bob.Program6.Api.Core.Utils;
using Moq;
using NUnit.Framework;
using System;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace Bob.Program6.Test
{
    public class TokenManagerTest
    {
        private TokenManager _ATokenProvider;
        private TokenManager _BTokenProvider;
        [SetUp]
        public void Setup() {
            var Amock = new Mock<IOptions<AppSettings>>();
            Amock.SetupGet(a=>a.Value).Returns(new AppSettings
            {
                Secret = "this is a test, so don't be mad. this is a test, so don't be mad. this is a test, so don't be mad."
            });

            var Bmock = new Mock<IOptions<AppSettings>>();
            Bmock.SetupGet(a => a.Value).Returns(new AppSettings
            {
                Secret = "this is a test, so don't be mad #2. this is a test, so don't be mad #2. this is a test, so don't be mad #2."
            });

            this._ATokenProvider = new TokenManager(Amock.Object);
            this._BTokenProvider = new TokenManager(Bmock.Object);
        }

        [Test]
        public void should_be_a_valid_token()
        {
            var claim = new Claim[] { new Claim("key","value")};
            var date = DateTime.Now.AddHours(1);
            var token = this._ATokenProvider.GetToken(claim,date);
            Assert.That(this._ATokenProvider.IsValid(token));
        }

        [Test]
        public void should_not_have_a_valid_token_when_key_is_different()
        {
            var claim = new Claim[] { new Claim("key", "value") };
            var date = DateTime.Now.AddDays(1);
            var token = this._ATokenProvider.GetToken(claim, date);
            Assert.That(!this._BTokenProvider.IsValid(token));
        }
    }
}