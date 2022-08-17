using NUnit.Framework;

namespace RecordClassSample
{
    public class ProductTests
    {
        [Test]
        public void ImmutableTest()
        {
            var classic = new ClassicProduct(1, "Apple");
            var immutable = new ImmutableProduct(1, "Apple");
            var immutableInit = new ImmutableInitProduct { Id = 1, Name = "Apple" };
            var record = new RecordProduct(1, "Apple");
            var extendedRecord = new ExtendedRecordProduct(record) { Price = 0.10 };

            Assert.That(extendedRecord.Name, Is.EqualTo(record.Name));
            Assert.That(extendedRecord.Id, Is.EqualTo(record.Id));

            var copiable = new CopiableProduct(1, "Apple");
            var copy = copiable.Copy();
            copy.IsSold = true;
            Assert.That(copiable.IsSold, Is.False);
        }
    }
}