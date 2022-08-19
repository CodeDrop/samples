using NUnit.Framework;

namespace RecordClassSample
{
    public class SampleTests
    {
        [Test]
        public void Mutable()
        {
            var o = new MutableClass { Id = 1, Name = "Apple" };
            Assert.That(o.Name, Is.EqualTo("Apple"));
            o.Name = "Cypress";
        }

        [Test]
        public void Immutable()
        {
            var o = new ImmutableClass(1, "Apple");
            Assert.That(o.Name, Is.EqualTo("Apple"));
            //o.Name = "Cypress";
        }

        [Test] public void ImmutableWithInit()
        {
            var o = new ImmutableClassWithInit { Id = 1, Name = "Apple" };
            Assert.That(o.Name, Is.EqualTo("Apple"));
            //o.Name = "Cypress";
        }

        [Test] public void Record()
        {
            var o1 = new ImmutableRecord(1, "Apple");
            Assert.That(o1.Name, Is.EqualTo("Apple"));
            //o1.Name = "Cypress";

            var o2 = new ImmutableRecord(1, "Apple");
            Assert.That(o1 == o2, Is.True);

            var o3 = new ImmutableRecord(3, "Cypress");
            Assert.That(o1 == o3, Is.False);

            o1.Deconstruct(out int id, out string name);
            Assert.That(name, Is.EqualTo("Apple"));
        }

        [Test]
        public void ExtendedRecord()
        {
            var original = new ImmutableRecord(1, "Apple");
            var extendedRecord = new ExtendedRecord(original) { Price = 0.10 };

            Assert.That(extendedRecord.Id, Is.EqualTo(original.Id));
            Assert.That(extendedRecord.Name, Is.EqualTo(original.Name));
        }

        [Test]
        public void CopiableRecord()
        {
            var original = new CopiableRecord(1, "Apple");
            var copy = original.Copy();
            copy.IsSold = true;
            Assert.That(original.IsSold, Is.False);
        }
    }
}