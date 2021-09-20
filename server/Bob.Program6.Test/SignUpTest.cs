using Bob.Program6.Api.Core.Model;
using Bob.Program6.Api.Core.Utils;
using NUnit.Framework;

namespace Bob.Program6.Test
{
    class SignUpTest
    {
        [TestCase("B","bob")]
        [TestCase("B@b","bob")]
        [TestCase("Bob","")]
        [TestCase(null,"dfefe")]
        [TestCase("fewfew", null)]
        [TestCase("fewfew333333333333333333333333333333333333333", "333333333333333333333333333333333333333333333333")]
        public void should_not_be_correct(string name, string password) {
            var authenticate = new AuthenticateRequest
            { 
                Name=name,
                Password=password
            };
            
            Assert.That(!authenticate.IsValid());
        }

        [TestCase("Bob", "bob")]
        [TestCase("Bo ewdb", " bob")]
        [TestCase("333 ", " 33333")]
        public void should_be_correct(string name, string password)
        {
            var authenticate = new AuthenticateRequest
            {
                Name = name,
                Password = password
            };

            Assert.That(authenticate.IsValid());
        }
    }
}
