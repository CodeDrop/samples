namespace RecordClassSample
{
    #region Classic

    public class ClassicProduct
    {
        public ClassicProduct(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    #endregion Classic

    #region Immutable

    public class ImmutableProduct
    {
        public ImmutableProduct(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public decimal Price { get; }
    }

    #endregion Immutable

    #region Immutable with init

    public record class ImmutableInitProduct
    {
        public string Name { get; init; } = "";
        public decimal Price { get; init; } = 0m;
    }

    #endregion Record

    #region Immutable record

    public record class RecordProduct(string Name, decimal Price);

    #endregion Immutable record

    #region Extended record

    public record class ExtendedRecordProduct : RecordProduct
    {
        public ExtendedRecordProduct(RecordProduct original)
            : base(original)
        { }

        public double DiscountFactor { get; init; }
    }

    #endregion Extended record

    #region Copy without auto-mapper

    public record class CopiableProduct(string Name, decimal Price)
    {
        public bool IsSold { get; set; }

        public CopiableProduct Copy()
        {
            return new CopiableProduct(this);
        }
    }

    #endregion Extended record
}