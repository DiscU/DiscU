using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OneOf.PerfTests
{
    extern alias DiscU;

    

    /// <summary>
    /// Performance tests.  Assumes OneOf is working correctly, per the Unit Tests.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("Debug build, tests will run much slower.");
            Console.WriteLine("");
#endif
            Console.WriteLine("Running DiscU Tests");
            DiscUPerfTests.TestCtor();
            Console.WriteLine("Running OneOf Tests");
            OneOfPerfTests.TestCtor();

            Console.WriteLine("Running DiscU Tests");
            DiscUPerfTests.TestMatch();
            Console.WriteLine("Running OneOf Tests");
            OneOfPerfTests.TestMatch();


            Console.WriteLine("");
            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }
    }
}
