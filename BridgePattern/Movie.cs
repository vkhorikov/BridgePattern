using System;

namespace BridgePattern
{
    public abstract class MovieLicense
    {
        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        protected MovieLicense(string movie, DateTime purchaseTime)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
        }

        public abstract decimal GetPrice();
        public abstract DateTime? GetExpirationDate();
    }

    public class TwoDaysLicense : MovieLicense
    {
        public TwoDaysLicense(string movie, DateTime purchaseTime)
            : base(movie, purchaseTime)
        {
        }

        public override decimal GetPrice()
        {
            return 4;
        }

        public override DateTime? GetExpirationDate()
        {
            return PurchaseTime.AddDays(2);
        }
    }

    public class LifeLongLicense : MovieLicense
    {
        public LifeLongLicense(string movie, DateTime purchaseTime)
            : base(movie, purchaseTime)
        {
        }

        public override decimal GetPrice()
        {
            return 8;
        }

        public override DateTime? GetExpirationDate()
        {
            return null;
        }
    }
}
