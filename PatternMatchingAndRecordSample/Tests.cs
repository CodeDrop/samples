namespace PatternMatchingAndRecordSample;

public class Tests
{
    [Test]
    [TestCase("some text")]
    [TestCase(1_000_000)]
    public void TypeMatchingTest(object o)
    {
        if (o is string s)
            Console.WriteLine(s); ;
    }

    [Test]
    [TestCase(null, true)]
    [TestCase("text", false)]
    [TestCase(1_000_000, false)]
    public void NullTest(object o, bool expected)
    {
        Assert.AreEqual(expected, PatternMatching.IsNull(o));
    }

    [Test]
    [TestCase("2022-6-1", true)]
    [TestCase("2022-6-7", true)]
    [TestCase("2022-6-8", false)]
    [TestCase("2022-5-1", false)]
    public void PatterMatchingTest(DateTime date, bool expected)
    {
        Assert.AreEqual(expected, PatternMatching.IsFirstWeekInJuly(date));
    }
}
