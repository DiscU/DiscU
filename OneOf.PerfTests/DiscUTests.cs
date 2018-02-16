using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OneOf.PerfTests
{
    public static class OneOfPerfTests
    {
        private static Dictionary<string, Func<OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9>>> TestsToRun = new Dictionary<string, Func<OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9>>>
        {
            { "Ctor1", () => (OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9>) new C1() },
            { "Ctor5", () => (OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9>) new C5() },
            { "Ctor9", () => (OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9>) new C9() },
            { "Ctor11",() => (OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9>) new C11() },
            { "Ctor15",() => (OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9>) new C15() },
            { "Ctor19",() => (OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9>) new C19() },
        };

        public static void TestCtor()
        {
            foreach (var func in TestsToRun)
            {
                Warmup(func.Key, func.Value);
            }
            foreach (var func in TestsToRun)
            {
                RunTest(func.Key, func.Value);
            }
        }

        public static void Warmup<T>(string funcKey, Func<T> funcValue)
        {
            foreach (var i in Enumerable.Range(0, 1000))
            {
                funcValue();
            }
        }

        public static void TestMatch()
        {
            OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9> oo1 = new C1();
            RunTest("Match1", () => oo1.Match((C1 v) => 1,(C2 v) => 2,(C3 v) => 3,(C4 v) => 4,(C5 v) => 5,(C6 v) => 6,(C7 v) => 7,(C8 v) => 8,(C9 v) => 9));

            OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9> oo5 = new C5();
            RunTest("Match5", () => oo5.Match((C1 v) => 1,(C2 v) => 2,(C3 v) => 3,(C4 v) => 4,(C5 v) => 5,(C6 v) => 6,(C7 v) => 7,(C8 v) => 8,(C9 v) => 9));

            OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9> oo9 = new C9();
            RunTest("Match9", () => oo9.Match((C1 v) => 1,(C2 v) => 2,(C3 v) => 3,(C4 v) => 4,(C5 v) => 5,(C6 v) => 6,(C7 v) => 7,(C8 v) => 8,(C9 v) => 9));

            OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9> oo11 = new C11();
            RunTest("Match11", () => oo9.Match((C1 v) => 1,(C2 v) => 2,(C3 v) => 3,(C4 v) => 4,(C5 v) => 5,(C6 v) => 6,(C7 v) => 7,(C8 v) => 8,(C9 v) => 9));

            OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9> oo15 = new C15();
            RunTest("Match15", () => oo9.Match((C1 v) => 1,(C2 v) => 2,(C3 v) => 3,(C4 v) => 4,(C5 v) => 5,(C6 v) => 6,(C7 v) => 7,(C8 v) => 8,(C9 v) => 9));

            OneOf<C1, C2, C3, C4, C5, C6, C7, C8, C9> oo19 = new C19();
            RunTest("Match19", () => oo9.Match((C1 v) => 1,(C2 v) => 2,(C3 v) => 3,(C4 v) => 4,(C5 v) => 5,(C6 v) => 6,(C7 v) => 7,(C8 v) => 8,(C9 v) => 9));
        }

        public static void RunTest<T>(string nameOfTest, Func<T> thingToTest)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.Write("{0:15} ... ", nameOfTest);
            thingToTest();
            // and then measure it
            var sw = Stopwatch.StartNew();

            var iterations = 0;
            while (sw.ElapsedMilliseconds < 1000)
            {
                // don't check the clock too often, and
                // unroll the loop 10x to take the cost of looping out of the equation as much as possible
                for (var i = 0; i < 100; i++)
                {
                    thingToTest();
                    thingToTest();
                    thingToTest();
                    thingToTest();
                    thingToTest();
                    thingToTest();
                    thingToTest();
                    thingToTest();
                    thingToTest();
                    thingToTest();
                }

                iterations += 1000;     // 100 loops of 10 tests = 1000
            }

            sw.Stop();
            Console.WriteLine("{0:0.00}M per second", iterations / 1000000d);
        }
    }
}
