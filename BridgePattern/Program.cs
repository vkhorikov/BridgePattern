using System;

namespace BridgePattern
{
    public class Program
    {
        public static void Main()
        {
            DateTime now = DateTime.Now;

            var noDiscount = new NoDiscount();
            var license1 = new TwoDaysLicense("Secret Life of Pets", now, noDiscount);
            var license2 = new LifeLongLicense("Matrix", now, noDiscount);

            PrintLicenseDetails(license1);
            PrintLicenseDetails(license2);

            var militaryDiscount = new MilitaryDiscount();
            var seniorDiscount = new SeniorDiscount();
            var license3 = new LifeLongLicense("Secret Life of Pets", now, militaryDiscount);
            var license4 = new TwoDaysLicense("Matrix", now, seniorDiscount);

            PrintLicenseDetails(license3);
            PrintLicenseDetails(license4);

            Console.ReadKey();
        }

        private static void PrintLicenseDetails(MovieLicense license)
        {
            Console.WriteLine($"Movie: {license.Movie}");
            Console.WriteLine($"Price: {GetPrice(license)}");
            Console.WriteLine($"Valid for: {GetValidFor(license)}");

            Console.WriteLine();
        }

        private static string GetPrice(MovieLicense license)
        {
            return $"${license.GetPrice():0.00}";
        }

        private static string GetValidFor(MovieLicense license)
        {
            DateTime? expirationDate = license.GetExpirationDate();

            if (expirationDate == null)
                return "Forever";

            TimeSpan timeSpan = expirationDate.Value - DateTime.Now;

            return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
        }
    }
}
