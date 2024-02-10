namespace HelloWorld.Test;

public class Tests
{
    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    [TestCase(4, 2)]
    [TestCase(6, 3)]
    public void Test2(
        int arg1
        , int arg2
    )
    {
        Assert.AreEqual(
            0
            , (arg1 % arg2)
        );
    }
}