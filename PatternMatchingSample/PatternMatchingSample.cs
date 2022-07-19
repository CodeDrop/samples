using NUnit.Framework;

namespace PatternMatchingSample;

/// <remarks>
/// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/is
/// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(is_CSharpKeyword)%3Bk(DevLang-csharp)%26rd%3Dtrue#is-operator
/// </remarks>
public class PatternMatchingSample
{
    // return o.GetType() == typeof(Person);
    // return (o as Person) != null;
    public bool MatchType(object o)
    {
        return o is Person;
    }

    // return wd.GetType() == typeof(Person); // ==> false
    public bool MatchBaseType(WebDeveloperPerson wd)
    {
        return wd is Person; // ==> true
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

    // var p = (o as Person);
    // return (p != null && p.Name == "Jane" && p.BirthDate.Year == 1069 && ...);
    public bool MatchPropertyPattern_Combined(object o)
    {
        return o is Person
        {
            Name: "Jane",
            BirthDate:
            { Month: >= 6 and <= 8, Year: 1969, DayOfWeek: DayOfWeek.Monday or DayOfWeek.Friday }
        };
    }

    public string MatchPatternToVariable(object o)
    {
        if (o is Person p)
            return p.Name + ": " + p.BirthDate.ToLongDateString();
        return "";
    }

    public string MatchPatternWithSwitch(Person person)
    {
        return person switch
        {
            { Name: "Markus" } => "ok",
            { BirthDate.DayOfWeek: DayOfWeek.Sunday } => "holy",
            { BirthDate.Year: < 1993 } => "old",
            _ => "nothing special"
        };
    }

    // switch (dayOfWeek)
    // {
    //    case DayOfWeek.Sunday:
    //        return "Son";
    //        break;
    //    case DayOfWeek.Monday:
    //        return "Mon";
    //        break;
    //    //..
    //    default:
    //        return "don't mind"
    //        break;
    // }
    public string MatchEnumWithSwitch(DayOfWeek dayOfWeek)
    {
        return dayOfWeek switch
        {
            DayOfWeek.Sunday => "Son",
            DayOfWeek.Monday => "Mon",
            //..
            _ => "don't mind"
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