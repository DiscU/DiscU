using NUnit.Framework;
using OneOf;

namespace OneOf.UnitTests
{
    public abstract class OneOfTestBase
    {
        protected T FailIfCalled<T>() { Assert.Fail(); /* won't get here, but needed for compiler */ return default(T); }
        protected void FailIfCalled() { Assert.Fail(); }
        protected void FailIf(bool cond) { if (cond) Assert.Fail(); }

        protected OneOf<string, int> CreateOneOf(object val) => new OneOf<string, int>(val);

        public class CBase
        {
            public string Value;

            public CBase() { }
            public CBase(string value) { Value = value; }

            public override string ToString() => this.Value?.ToString() ?? "";
        }

        public class C1 : CBase
        {
            public C1() : base() { }
            public C1(string value) : base(value) { }
            public static bool operator ==(C1 a, C1 b) => a.Value == b.Value;
            public static bool operator !=(C1 a, C1 b) => a.Value != b.Value;
            public override bool Equals(object b) => (b is C1) && (b as C1).Value == this.Value;
            public override int GetHashCode() => this.Value?.GetHashCode() ?? 0;
        }
        public class C2 : CBase
        {
            public C2() : base() { }
            public C2(string value) : base(value) { }
            public static bool operator ==(C2 a, C2 b) => a.Value == b.Value;
            public static bool operator !=(C2 a, C2 b) => a.Value != b.Value;
            public override bool Equals(object b) => (b is C2) && (b as C2).Value == this.Value;
            public override int GetHashCode() => this?.GetHashCode() ?? 0;
        }
        public class C3 : CBase
        {
            public C3() : base() { }
            public C3(string value) : base(value) { }
            public static bool operator ==(C3 a, C3 b) => a.Value == b.Value;
            public static bool operator !=(C3 a, C3 b) => a.Value != b.Value;
            public override bool Equals(object b) => (b is C3) && (b as C3).Value == this.Value;
            public override int GetHashCode() => this?.GetHashCode() ?? 0;
        }
        public class C4 : CBase
        {
            public C4() : base() { }
            public C4(string value) : base(value) { }
            public static bool operator ==(C4 a, C4 b) => a.Value == b.Value;
            public static bool operator !=(C4 a, C4 b) => a.Value != b.Value;
            public override bool Equals(object b) => (b is C4) && (b as C4).Value == this.Value;
            public override int GetHashCode() => this?.GetHashCode() ?? 0;
        }
        public class C5 : CBase
        {
            public C5() : base() { }
            public C5(string value) : base(value) { }
            public static bool operator ==(C5 a, C5 b) => a.Value == b.Value;
            public static bool operator !=(C5 a, C5 b) => a.Value != b.Value;
            public override bool Equals(object b) => (b is C5) && (b as C5).Value == this.Value;
            public override int GetHashCode() => this?.GetHashCode() ?? 0;
        }
        public class C6 : CBase
        {
            public C6() : base() { }
            public C6(string value) : base(value) { }
            public static bool operator ==(C6 a, C6 b) => a.Value == b.Value;
            public static bool operator !=(C6 a, C6 b) => a.Value != b.Value;
            public override bool Equals(object b) => (b is C6) && (b as C6).Value == this.Value;
            public override int GetHashCode() => this?.GetHashCode() ?? 0;
        }
        public class C7 : CBase
        {
            public C7() : base() { }
            public C7(string value) : base(value) { }
            public static bool operator ==(C7 a, C7 b) => a.Value == b.Value;
            public static bool operator !=(C7 a, C7 b) => a.Value != b.Value;
            public override bool Equals(object b) => (b is C7) && (b as C7).Value == this.Value;
            public override int GetHashCode() => this?.GetHashCode() ?? 0;
        }
        public class C8 : CBase
        {
            public C8() : base() { }
            public C8(string value) : base(value) { }
            public static bool operator ==(C8 a, C8 b) => a.Value == b.Value;
            public static bool operator !=(C8 a, C8 b) => a.Value != b.Value;
            public override bool Equals(object b) => (b is C8) && (b as C8).Value == this.Value;
            public override int GetHashCode() => this?.GetHashCode() ?? 0;
        }
        public class C9 : CBase
        {
            public C9() : base() { }
            public C9(string value) : base(value) { }
            public static bool operator ==(C9 a, C9 b) => a.Value == b.Value;
            public static bool operator !=(C9 a, C9 b) => a.Value != b.Value;
            public override bool Equals(object b) => (b is C9) && (b as C9).Value == this.Value;
            public override int GetHashCode() => this?.GetHashCode() ?? 0;
        }
    }
}
