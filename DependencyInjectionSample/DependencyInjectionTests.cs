using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace DependencyInjectionSample;

public class DependencyInjectionTests
{
    [TearDown]
    public void TearDown()
    {
        Foo.NumberOfInstances = 0;
    }
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
        Assert.That(foo2, Is.SameAs(foo3));
    }

    [Test]
    public async Task TransientInstancesTest()
    {
        // arrange
        await using var provider = new ServiceCollection()
            .AddTransient<Foo>()
            .BuildServiceProvider();

        // act
        var foo1 = provider.GetService<Foo>();
        var foo2 = provider.GetService<Foo>();
        var foo3 = provider.GetService<Foo>();

        // assert
        Assert.That(Foo.NumberOfInstances, Is.EqualTo(3));
        Assert.That(foo1, Is.Not.SameAs(foo2));
        Assert.That(foo2, Is.Not.SameAs(foo3));
    }
}