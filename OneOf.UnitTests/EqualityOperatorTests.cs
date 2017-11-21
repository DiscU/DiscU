using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OneOf;

namespace OneOf.UnitTests
{
    [TestFixture]
    public class EqualityOperatorTests : OneOfTestBase
    {
        [Test]
        public void EqualityOperatorReturnsTrueWhenSameValue()
        {
            var oo1 = CreateOneOf("A");
            var oo2 = CreateOneOf("A");
            Assert.IsTrue(oo1 == oo2);
        }

        [Test]
        public void EqualityOperatorReturnsFalseWhenDifferingValue()
        {
            var oo1 = CreateOneOf("A");
            var oo2 = CreateOneOf("B");
            Assert.IsFalse(oo1 == oo2);
        }

        [Test]
        public void EqualityOperatorReturnsFalseWhenNullValue()
        {
            var oo1 = CreateOneOf("A");
            Assert.IsFalse(oo1 == null);
        }
    }
}
