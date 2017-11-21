using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OneOf.UnitTests
{
    [TestFixture]
    public class InequalityOperatorTests : OneOfTestBase
    {
        [Test]
        public void InequalityOperatorReturnsFalseWhenSameValue()
        {
            var oo1 = CreateOneOf("A");
            var oo2 = CreateOneOf("A");
            Assert.IsFalse(oo1 != oo2);
        }

        [Test]
        public void InequalityOperatorReturnsTrueWhenDifferingValue()
        {
            var oo1 = CreateOneOf("A");
            var oo2 = CreateOneOf("B");
            Assert.IsTrue(oo1 != oo2);
        }

        [Test]
        public void InequalityOperatorReturnsTrueWhenNullValue()
        {
            var oo1 = CreateOneOf("A");
            Assert.IsTrue(oo1 != null);
        }
    }
}
