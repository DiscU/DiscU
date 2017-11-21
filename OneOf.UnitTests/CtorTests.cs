using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Reflection;

namespace OneOf.UnitTests
{
    [TestFixture]
    public class CtorTests : OneOfTestBase
    {
        [Test]
        public void IntValueCreatesOneOf()
        {
            var oo = new OneOf<int, string>(123);
            Assert.AreEqual("123", oo.ToString());
        }

        [Test]
        public void StringValueCreatesOneOf()
        {
            var oo = new OneOf<int, string>("abc");
            Assert.AreEqual("abc", oo.ToString());
        }

        [Test]
        public void NullValueThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new OneOf<int, string>(null));
        }

        [Test]
        public void WrongTypeThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new OneOf<int, string>(123.456));
        }
    }
}
