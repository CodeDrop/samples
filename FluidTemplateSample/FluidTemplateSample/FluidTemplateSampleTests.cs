using Fluid;

namespace FluidTemplateSample;

public class FluidTemplateSampleTests
{
    [Test]
    [TestCase("Markus", "Kraus")]
    [TestCase("Abraham", "Eve")]
    public async Task RenderTest(string firstName, string lastName)
    {
        var parser = new FluidParser();
        var model = new { FirstName = firstName, LastName = lastName };
        var source = """Tested by {% if FirstName == "Markus" %}Master {% endif %}{{ FirstName }} {{ LastName }}""";

        if (!parser.TryParse(source, out var template, out var error))
            Assert.Fail($"Error: {error}");

        var context = new TemplateContext(model);
        Console.WriteLine(await template.RenderAsync(context));
    }
}