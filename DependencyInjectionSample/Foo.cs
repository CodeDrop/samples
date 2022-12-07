namespace DependencyInjectionSample;

public class Foo
{
    private static int numberOfInstances;

    public Foo()
    {
        numberOfInstances += 1;
    }

    public static int NumberOfInstances => numberOfInstances;
}
