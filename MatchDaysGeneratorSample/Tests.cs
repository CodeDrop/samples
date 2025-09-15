namespace MatchDaysGeneratorSample
{
    public class Tests
    {
        [Test]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(10)]
        [TestCase(12)]
        [TestCase(16)]
        public void MatchDaysTest(int teamsCount)
        {
            var generator = new MatchdayGenerator(teamsCount);
            var _matchdays = generator.Generate();

            Assert.That(_matchdays, Has.Count.EqualTo(teamsCount - 1));
            Assert.That(_matchdays[0], Has.Count.EqualTo(teamsCount / 2));

            foreach (var matchday in _matchdays)
            {
                Console.WriteLine($"--- {_matchdays.IndexOf(matchday) + 1} ---");
                foreach (var match in matchday)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}