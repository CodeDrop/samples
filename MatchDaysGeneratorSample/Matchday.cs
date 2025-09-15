

namespace MatchDaysGeneratorSample
{
    public class Matchday : List<Match>
    {
        public bool ContainsPlayerIn(Match match)
        {
            return this.Any(m => 
                m.Item1 == match.Item1 || 
                m.Item1 == match.Item2 ||
                m.Item2 == match.Item1 || 
                m.Item2 == match.Item2
            );
        }

        public IEnumerable<Match> MatchesWithPlayersFrom(Match match)
        {
            return this.Where(m => 
                m.Item1 == match.Item1 || 
                m.Item1 == match.Item2 ||
                m.Item2 == match.Item1 || 
                m.Item2 == match.Item2
            );
        }
    }
}
