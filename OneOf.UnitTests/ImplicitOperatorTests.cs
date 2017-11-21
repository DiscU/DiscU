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
    public class ImplicitOperatorTests : OneOfTestBase
    {
        [Test]
        public void IntValueImplicitlyConverted()
        {
            OneOf<int, string> oo = 123;    // The value is implicitly converted to a OneOf before being assigned to "oo"
            Assert.AreEqual("123", oo.ToString());
        }

        [Test]
        public void StringValueImplicitlyConverted()
        {
            OneOf<int, string> oo = "abc";  // The value is implicitly converted to a OneOf before being assigned to "oo"
            Assert.AreEqual("abc", oo.ToString());
        }
    }
}
