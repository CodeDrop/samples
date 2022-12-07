using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace DependencyInjectionSample;

public class DependencyInjectionTests
{
    [Test]
    public async Task SingletonInstanceTest()
    {
        // arrange
        await using var provider = new ServiceCollection()
            .AddSingleton<Foo>()
            .BuildServiceProvider();

        // act
        var foo1 = provider.GetService<Foo>();
        var foo2 = provider.GetService<Foo>();
        var foo3 = provider.GetService<Foo>();

        // assert
        Assert.That(Foo.NumberOfInstances, Is.EqualTo(1));
        Assert.That(foo1, Is.SameAs(foo2));
        Assert.That(foo1, Is.SameAs(foo3));
    }
}