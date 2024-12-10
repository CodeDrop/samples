namespace NUnitCustomConstraintsSample
{
    public class UnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Where is Markus?")]
        [TestCase("Markus was here.")]
        public void String_contains_Markus(string sut)
        {
            Assert.That(sut, Does.ContainMarkus());
        }

        [Test]
        [TestCase("Where is David?")]
        [TestCase("John sneeked in.")]
        public void String_does_not_contain_Markus(string sut)
        {
            Assert.That(sut, Does.Not.ContainMarkus());
        }
    }
}