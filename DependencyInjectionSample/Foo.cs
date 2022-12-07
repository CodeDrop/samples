namespace DependencyInjectionSample;

public class Foo
{
    public Foo()
    {
        NumberOfInstances += 1;
    }

    public static int NumberOfInstances { get; set; }
}
