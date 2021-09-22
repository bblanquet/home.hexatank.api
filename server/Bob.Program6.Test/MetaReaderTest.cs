using Bob.Program6.Api.Core.Model;
using Bob.Program6.Dao.Core;
using NUnit.Framework;
using System;
using System.Linq.Expressions;

namespace Bob.Program6.Test
{
    public class MetaReaderTest
    {
        [Test]
        public void should_retrieve_prop_name()
        {
            Expression<Func<Player, Object>> exp = (Player p) => p.Name;
            var propName = MetaReader.GetMemberName(exp);
            Assert.That(propName == "Name");
        }
    }
}
