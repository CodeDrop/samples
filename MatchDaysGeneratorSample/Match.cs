namespace MatchDaysGeneratorSample
{
    public class Match : Tuple<int, int>
    {
        public static readonly Match Empty = new Match(0, 0);

        public Match(int item1, int item2) : base(item1, item2)
        {
        }

        override public string ToString()
        {
            return $"P{Item1:00}\tP{Item2:00}";
        }
    }
}
