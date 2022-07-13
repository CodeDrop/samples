namespace PatternMatchingSample;

public class Person
{
    public Person(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public DateTime BirthDate { get; set; }

    public static bool operator ==(Person? a, object? obj)
    {
        return obj is Person b && a?.Name == b.Name;
    }

    public static bool operator !=(Person? a, object? b)
    {
        return !(a == b);
    }

    public override bool Equals(object? obj)
    {
        return this == obj;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
