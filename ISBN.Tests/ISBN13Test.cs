using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ISBN.Tests
{
    public class ISBN13Test
    {
        // [Fact(Skip = "skipping this test should get a Green azure build")]
        [Fact]
        public void Failing_Test_To_Demo_CI_Automation()
        {
            // This test fails
            // Fix it and commit to trunk and observe the CI build starts and passes
            Assert.True(false, "Remove this test or change 'false' to true'");
        }
    }
}
