namespace RawStringLiteralSample;

public class UnitTests
{
    [Test]
    public void Test()
    {
        string sister = "L�na";
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