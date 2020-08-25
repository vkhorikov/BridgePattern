using System;

namespace BridgePattern
{
    public abstract class MovieLicense
    {
        private readonly Discount _discount;

        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        protected MovieLicense(string movie, DateTime purchaseTime, Discount discount)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
            _discount = discount;
        }

        public decimal GetPrice()
        {
            int discount = _discount.GetDiscount();
            decimal multiplier = 1 - discount / 100m;
            return GetPriceCore() * multiplier;
        }

        protected abstract decimal GetPriceCore();
        public abstract DateTime? GetExpirationDate();
    }

    public abstract class Discount
    {
        public abstract int GetDiscount();
    }

    public class NoDiscount : Discount
    {
        public override int GetDiscount() => 0;
    }

    public class MilitaryDiscount : Discount
    {
        public override int GetDiscount() => 10;
    }

    public class SeniorDiscount : Discount
    {
        public override int GetDiscount() => 20;
    }

    public class TwoDaysLicense : MovieLicense
    {
        public TwoDaysLicense(string movie, DateTime purchaseTime, Discount discount)
            : base(movie, purchaseTime, discount)
        {
        }

        protected override decimal GetPriceCore() => 4;
        public override DateTime? GetExpirationDate() => PurchaseTime.AddDays(2);
    }

    public class LifeLongLicense : MovieLicense
    {
        public LifeLongLicense(string movie, DateTime purchaseTime, Discount discount)
            : base(movie, purchaseTime, discount)
        {
        }

        protected override decimal GetPriceCore() => 8;
        public override DateTime? GetExpirationDate() => null;
    }

    //public class SpecialOfferSeniorTwoDaysLicense : SeniorTwoDaysLicense
    //{
    //    public SpecialOfferSeniorTwoDaysLicense(string movie, DateTime purchaseTime)
    //        : base(movie, purchaseTime)
    //    {
    //    }

    //    public override DateTime? GetExpirationDate()
    //    {
    //        DateTime? expirationDate = base.GetExpirationDate();
    //        return expirationDate?.AddDays(2);
    //    }
    //}
}
