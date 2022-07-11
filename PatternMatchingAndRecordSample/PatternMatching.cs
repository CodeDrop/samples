namespace PatternMatchingAndRecordSample;

/// <summary>
/// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/is
/// </summary>
class PatternMatching
{
    public static bool IsNull(object o)
    {
        return o is null;
    }

    public static bool IsFirstWeekInJuly(DateTime date)
    {
        return date is { Month: 6, Day: <= 7 };
    }
}
