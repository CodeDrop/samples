namespace MatchDaysGeneratorSample
{
    public class MatchdayGenerator(int _teamsCount = 10)
    {
        private readonly Matchday _matches = [];
        private readonly List<Matchday> _matchdays = [];

        public List<Matchday> Generate()
        {
            _matches.Clear();
            _matches.AddRange(GenerateMatches());
            _matchdays.Clear();
            _matchdays.AddRange(GenerateMatchdays());
            return _matchdays;
        }

        private IEnumerable<Match> GenerateMatches()
        {
            for (int i = 1; i <= _teamsCount; i++)
            {
                for (int j = i + 1; j <= _teamsCount; j++)
                {
                    yield return new Match(i, j);
                }
            }
        }

        private IEnumerable<Matchday> GenerateMatchdays()
        {
            int blockSize = _teamsCount / 2;

            for (int i = 0; i < _teamsCount - 1; i++)
            {
                yield return GenerateMatchday(blockSize);
            }
        }

        private Matchday GenerateMatchday(int blockSize)
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
