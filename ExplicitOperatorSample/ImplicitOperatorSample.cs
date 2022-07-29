using NUnit.Framework;

namespace ExplicitOperatorSample;

public class ImplicitOperatorSample
{
    private class EmailAddress
    {
        public EmailAddress(string emailAddressString)
        {
            if (!emailAddressString.Contains("@"))
                throw new ArgumentException($"Invalid email address \"{emailAddressString}\"");
            Value = emailAddressString;
        }

        public string Value { get; }

        public static implicit operator string(EmailAddress emailAddress)
        {
            return emailAddress.Value;
        }

        public static implicit operator EmailAddress(string emailAddressString)
        {
            return new EmailAddress(emailAddressString);
        }
    }

    [Test]
    public void ImplicitAssignmentToString()
    {
        var emailAddress = new EmailAddress("someone@mailer.com");
        string emailAddressString = emailAddress;
        Assert.That(emailAddressString, Is.EqualTo("someone@mailer.com"));
    }

    [Test]
    public void ImplicitAssignmentToClassTest()
    {
        EmailAddress emailAddress = "someone@mailer.com";
        Assert.That(emailAddress.Value, Is.EqualTo("someone@mailer.com"));
    }

    [Test]
    public void ImplicitAssignmentToClassFailsForInvalidAddress()
    {
        static void code() { EmailAddress emailAddress = "somemailer.com"; }
        Assert.Throws<ArgumentException>(code);
    }
}