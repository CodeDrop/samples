using NUnit.Framework.Constraints;

namespace NUnitCustomConstraintsSample
{
    public class ContainMarkusConstraint : Constraint
    {
        public ContainMarkusConstraint()
        {
            Description = "contains \"Markus\"";
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            bool isSuccess = actual is string s && s.Contains("Markus");
            object result = isSuccess ? actual : $"no 'Markus' in \"{actual}\".";
            return new ConstraintResult(this, result, isSuccess);
        }
    }

    public static class ConstraintExtension
    {
        public static ContainMarkusConstraint ContainMarkus(this ConstraintExpression expression)
        {
            var constraint = new ContainMarkusConstraint();
            expression.Append(constraint);
            return constraint;
        }
    }

    public class Does : NUnit.Framework.Does 
    {
        public static ContainMarkusConstraint ContainMarkus()
        {
            return new ContainMarkusConstraint();
        }
    }
}
