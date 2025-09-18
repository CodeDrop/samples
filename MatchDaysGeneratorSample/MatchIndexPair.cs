namespace MatchDaysGeneratorSample
{
    public class MatchIndexPair : Tuple<int, int>
    {
        public static readonly MatchIndexPair Empty = new(0, 0);

        public MatchIndexPair(int item1, int item2) : base(item1, item2)
        {
        }

        override public string ToString()
        {
            return $"P{Item1:00}\tP{Item2:00}";
        }
    }
}
