namespace Unit_test
{
    public class FailureTest
    {
        //Test if pipeline react as expected
        [Fact]
        public void FailingTest()
        {
            //Assert.False(true); // used to test pipeline for failure
        }
    }

    public class SuccessTest
{
    [Fact]
    public void PassingTest()
    {
        Assert.True(true); // This test will pass
    }
}
}