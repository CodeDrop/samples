using NUnit.Framework;

namespace PatternMatchingSample;

/// <remarks>
/// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/is
/// https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
/// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#is-operator
/// </remarks>
public class PatternMatchingSample
{
    #region Type match

    // return o.GetType() == typeof(Person);
    // return (o as Person) != null;
    public bool MatchType(object o)
    {
        return o is Person;
    }

    #endregion Type match

    #region Base type match

    // return wd.GetType() == typeof(Person); // ==> false
    public bool MatchBaseType(WebDeveloperPerson wd)
    {
        return wd is Person; // ==> true
    }

    #endregion Base type match

    #region Property match - discrete value

    public bool MatchPropertyPattern_Constant(Person p)
    {
        return p is { Name: "Jack" };
    }

    #endregion Property match - discrete value

    #region Property match - relational patterns

    public bool MatchPropertyPattern_Relational(DateTime d)
    {
        return d is { Month: > 6, Day: < 8 };
    }

    #endregion Property match - relational pattern

    #region Property match - logical patterns

    public bool MatchPropertyPattern_Logical(Person p)
    {
        return p is { BirthDate.DayOfWeek: not DayOfWeek.Saturday and not DayOfWeek.Sunday };
    }

    #endregion Property match - logical patterns

    #region Property match - combined

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

    #endregion Property match - combined

    #region Declaration pattern

    // var p = o as Person
    // if (p != null) ...
    public string MatchPatternToDeclaration(object o)
    {
        if (o is Person p)
            return p.Name + ": " + p.BirthDate.ToLongDateString();

        return "non-person";
    }

    #endregion Declaration pattern

    #region Pattern matching with switch - enum

    // string dayAbbeviation = "";
    // switch (dayOfWeek)
    // {
    //    case DayOfWeek.Sunday:
    //        dayAbbeviation = "Son";
    //        break;
    //    case DayOfWeek.Monday:
    //        dayAbbeviation = "Mon";
    //        break;
    //    //..
    //    default:
    //        dayAbbeviation = "don't mind"
    // }
    public void MatchEnumWithSwitch(DayOfWeek dayOfWeek)
    {
        var dayAbbeviation = dayOfWeek switch
        {
            DayOfWeek.Sunday => "Son",
            DayOfWeek.Monday => "Mon",
            //..
            _ => "don't mind"
        };
        Console.WriteLine(dayAbbeviation);
    }

    #endregion Pattern matching with switch - enum

    #region Pattern matching with switch - object

    // if (person.Name == "Markus")
    //    return "ok";
    // if (person.BirthDate.DayOfWeek == DayOfWeek.Sunday)
    //    return "holy";
    // if (person.BirthDate.Year < 1993)
    //    return "old";
    // return "nothing special";
    public string MatchObjectWithSwitch(Person person)
    {
        return person switch
        {
            { Name: "Markus" } => "ok",
            { BirthDate.DayOfWeek: DayOfWeek.Sunday } => "holy",
            { BirthDate.Year: < 1993 } => "old",
            _ => "nothing special"
        };
    }

    #endregion Pattern matching with switch - object

    #region Match null

    [Test]
    public void MatchNull()
    {
        Person? person = null;
        Assert.That(person is null, Is.True);
        Assert.That(person == null, Is.False); // (as Person overloaded equals operator)
    }

    #endregion Match null
}