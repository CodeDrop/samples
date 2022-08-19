// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record
// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records

namespace RecordClassSample
{
    #region Mutable

    public class MutableClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }

    #endregion Mutable

    #region Immutable

    public class ImmutableClass
    {
        public ImmutableClass(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }

    #endregion Immutable

    #region Immutable with init

    public class ImmutableClassWithInit
    {
        public int Id { get; init; }
        public string Name { get; init; } = "";
    }

    #endregion Immutable with init

    #region Immutable record

    public record ImmutableRecord(int Id, string Name);

    #endregion Immutable record

    #region Extended immutable record

    public record ExtendedRecord : ImmutableRecord
    {
        public ExtendedRecord(ImmutableRecord original)
            : base(original)
        { }

        public double Price { get; init; }
    }

    #endregion Extended immutable record

    #region Copiable record (without auto-mapper)

    public record class CopiableRecord(int Id, string Name)
    {
        public CopiableRecord Copy()
        {
            return new CopiableRecord(this);
        }

        public bool IsSold { get; set; }
    }

    #endregion Copiable record
}

// Java has it, too: https://docs.oracle.com/en/java/javase/15/language/records.html
