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

public class MilitaryTwoDaysLicense : TwoDaysLicense
{
    public MilitaryTwoDaysLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
    {
    }

    public override decimal GetPrice()
    {
        return base.GetPrice() * 0.9m;
    }
}

public class SeniorCitizenTwoDaysLicense : TwoDaysLicense
{
    public SeniorCitizenTwoDaysLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
    {
    }

    public override decimal GetPrice()
    {
        return base.GetPrice() * 0.8m;
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

public class MilitaryLifeLongLicense : LifeLongLicense
{
    public MilitaryLifeLongLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
    {
    }

    public override decimal GetPrice()
    {
        return base.GetPrice() * 0.9m;
    }
}

public class SeniorCitizenLifeLongLicense : LifeLongLicense
{
    public SeniorCitizenLifeLongLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
    {
    }

    public override decimal GetPrice()
    {
        return base.GetPrice() * 0.8m;
    }
}