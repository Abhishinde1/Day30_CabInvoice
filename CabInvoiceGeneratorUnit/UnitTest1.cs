using CabInvoiceGenerator;

namespace CabInvoiceGeneratorUnit
{
    [TestClass]
    public class UnitTest1
    {
        InvoiceGenerator invoiceGenerator = null;
        [TestMethod]
        public void TestMethod1()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            double distance = 2.0;
            int time = 5;

            double fare  = invoiceGenerator.CalculateFare(distance , time);
            double excepted = 25;

            Assert.AreEqual(excepted, fare);
        }

        [TestMethod]

        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 2) };

            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);

            InvoiceSummary excepted = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(excepted, invoiceSummary);



        }
    }
}