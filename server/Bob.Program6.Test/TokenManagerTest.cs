using NUnit.Framework;
using System;
using System.Security.Claims;
using Bob.Program6.Security.Core;

namespace Bob.Program6.Test
{
    public class TokenManagerTest
    {
        private TokenManager _ATokenProvider;
        private TokenManager _BTokenProvider;
        [SetUp]
        public void Setup() {
            this._ATokenProvider = new TokenManager("this is a test, so don't be mad. this is a test, so don't be mad. this is a test, so don't be mad.");
            this._BTokenProvider = new TokenManager("this is a test, so don't be mad #2. this is a test, so don't be mad #2. this is a test, so don't be mad #2.");
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