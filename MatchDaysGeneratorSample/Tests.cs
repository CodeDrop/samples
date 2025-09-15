namespace MatchDaysGeneratorSample
{
    public class Tests
    {
        private const int PLAYERS_COUNT = 12;
        private readonly Matchday _matches = [];
        private readonly List<Matchday> _matchdays = [];

        [OneTimeSetUp]
        public void Setup()
        {
            _matches.Clear();
            _matches.AddRange(GenerateMatches(PLAYERS_COUNT));
            _matchdays.Clear();
            _matchdays.AddRange(GenerateMatchdays());
        }

        [Test]
        [Ignore("This is just to show the generated matches and matchdays in the Test Explorer")]
        public void TuplesTest()
        {
            Assert.That(_matches.Count(), Is.EqualTo(45));
        }

        [Test]
        public void MatchDaysCountTest()
        {
            Assert.That(_matchdays.Count(), Is.EqualTo(9));
            Assert.That(_matchdays[0].Count(), Is.EqualTo(5));
        }

        [Test]
        public void MatchDaysTest()
        {
            foreach (var matchday in _matchdays)
            {
                Console.WriteLine($"--- {_matchdays.IndexOf(matchday) + 1} ---");
                foreach (var match in matchday)
                {
                    Console.WriteLine(match);
                }
            }
        }

        private IEnumerable<Match> GenerateMatches(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    yield return new Match(i, j);
                }
            }
        }

        private IEnumerable<Matchday> GenerateMatchdays()
        {
            int blockSize = _matches.Count / (PLAYERS_COUNT - 1);

            for (int i = 0; i < PLAYERS_COUNT - 1; i++)
            {
                yield return GenerateBlock(blockSize);
            }
        }

        private Matchday GenerateBlock(int blockSize)
        {
            var matchday = new Matchday();
            while (matchday.Count < blockSize)
            {
                var invalidatedMatches = new List<Match>();
                var nextMatch = GetNextMatch(matchday);
                if (nextMatch == Match.Empty)
                {
                    nextMatch = _matches.Except(invalidatedMatches).FirstOrDefault() ?? Match.Empty;
                    invalidatedMatches.AddRange(matchday.MatchesWithPlayersFrom(nextMatch));
                    _matches.AddRange(invalidatedMatches);
                    matchday.RemoveAll(invalidatedMatches.Contains);
                }
                matchday.Add(nextMatch);
                _matches.Remove(nextMatch);
            }
            return matchday;
        }

        private Match GetNextMatch(Matchday matchday)
        {
            if (_matches.Count == 0) return Match.Empty;

            for (int i = 0; i < _matches.Count; i++)
            {
                var match = _matches[i];
                if (!matchday.ContainsPlayerIn(match))
                {
                    return match;
                }
            }

            return Match.Empty;
        }
    }
}