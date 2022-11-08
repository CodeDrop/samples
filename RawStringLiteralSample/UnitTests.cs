namespace RawStringLiteralSample;

public class UnitTests
{
    [Test]
    public void Test()
    {
        string sister = "Léna";
        string brother = "Paul";
        Console.WriteLine(
            $$"""
            {

            "sister": "{{sister}}",
            "brother": "{{brother}}",

            }
            """);
     }
}