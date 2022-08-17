using NUnit.Framework;

namespace RecordClassSample
{
    public class ProductTests
    {
        [Test]
        public void ImmutableTest()
        {
            var classic = new ClassicProduct("Apple", 1.23m);
            var immutable = new ImmutableProduct("Apple", 1.23m);
            var immutableInit = new ImmutableInitProduct { Name = "Apple", Price = 1.23m };
            var record = new RecordProduct("Apple", 1.23m);
            var extendedRecord = new ExtendedRecordProduct(record) { DiscountFactor = 0.10 };

            Assert.That(extendedRecord.Name, Is.EqualTo(record.Name));
            Assert.That(extendedRecord.Price, Is.EqualTo(record.Price));

            var copiable = new CopiableProduct("Apple", 1.23m);
            var copy = copiable.Copy();
            copy.IsSold = true;
            Assert.That(copiable.IsSold, Is.False);
        }
    }
}