using NUnit.Framework;

namespace PatternMatchingSample;

/// <remarks>
/// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/is
/// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(is_CSharpKeyword)%3Bk(DevLang-csharp)%26rd%3Dtrue#is-operator
/// </remarks>
public class PatternMatchingSample
{
    public bool MatchType(object o)
    {
        return o is Person;
        // return (o as Person) != null;
        // return o.GetType() == typeof(Person);
    }

    public bool MatchBaseType(WebDeveloperPerson wd)
    {
        return wd is Person; // ==> true
        // return wd.GetType() == typeof(Person); // ==> false
    }

    public bool MatchPropertyPattern_Constant(Person p)
    {
        return p is { Name: "Jack" };
    }

    public bool MatchPropertyPattern_Relational(DateTime d)
    {
        return d is { Month: 6, Day: <= 7 };
    }

    public bool MatchPropertyPattern_Logical(Person p)
    {
        return p is { BirthDate.DayOfWeek: not DayOfWeek.Saturday and not DayOfWeek.Sunday };
    }

    public bool MatchPropertyPattern_Combined(object o)
    {
        return o is Person
        {
            Name: "Jane",
            BirthDate: { Month: >= 6 and <= 8, Year: 1969 },
            BirthDate.DayOfWeek: DayOfWeek.Monday or DayOfWeek.Friday,
        };
        // var p = (o as Person);
        // return (p != null && p.Name == "Jane" && p.BirthDate.Year == 1069 && ...);
    }

    public int MatchPatternToVariable(object o)
    {
        if (o is int i)
            return i;
        if (o is Person { BirthDate.Month: 1 } p)
            return p.BirthDate.Day;
        return 0;
    }

    public string MatchPatternWithSwitch(Person person)
    {
        return person switch
        {
            { Name: "Markus" } => "nice",
            { BirthDate.DayOfWeek: DayOfWeek.Sunday } => "holy",
            { BirthDate.Year: < 1993 } => "old",
            _ => "nothing special"
        };
    }

    [Test]
    public void MatchNull()
    {
        Person? person = null;
        Assert.That(person is null, Is.True);
        Assert.That(person == null, Is.False); // (as Person overloaded equals operator)
    }
}