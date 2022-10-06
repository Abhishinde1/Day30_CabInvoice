namespace CabInvoiceGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Program");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double fare = invoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine("Total fare for normal Ride is " + fare);

            InvoiceGenerator invoiceGenerator1 = new InvoiceGenerator(RideType.PREMIUM);
            double fare1 = invoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine("Total fare for normal Ride is " + fare1);
        }
    }
}