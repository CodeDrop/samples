namespace RecordClassSample
{
    #region Classic

    public class ClassicProduct
    {
        public ClassicProduct(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }

    #endregion Classic

    #region Immutable

    public class ImmutableProduct
    {
        public ImmutableProduct(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }

    #endregion Immutable

    #region Immutable with init

    public record class ImmutableInitProduct
    {
        public int Id { get; init; } = 0;
        public string Name { get; init; } = "";
    }

    #endregion Record

    #region Immutable record

    public record class RecordProduct(int Id, string Name);

    #endregion Immutable record

    #region Extended record

    public record class ExtendedRecordProduct : RecordProduct
    {
        public ExtendedRecordProduct(RecordProduct original)
            : base(original)
        { }

        public double Price { get; init; }
    }

    #endregion Extended record

    #region Copiable record (without auto-mapper)

    public record class CopiableProduct(int Id, string Name)
    {
        public CopiableProduct Copy()
        {
            return new CopiableProduct(this);
        }

        public bool IsSold { get; set; }
    }

    #endregion Extended record
}