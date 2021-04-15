using Xunit;

namespace ISBN
{
    public class ISBN13Test
    {
        //[Fact]
        //[Fact]
         [Fact(Skip="Enable this test to see the CI build fail")]
        public void Failing_Test_To_Demo_CI_Automation()
        {
            // This test fails
            // Fix it and commit to trunk and observe the CI build starts and passes
            Assert.True(false, "Remove this test or change 'false' to true'");
        }
    }
}