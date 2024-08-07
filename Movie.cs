public class MovieLicense
{
    public string Movie { get; }
    public DateTime PurchaseTime { get; }
    private readonly Discount _discount;
    private readonly LicenseType _licenseType;

    public MovieLicense(string movie, DateTime purchaseTime, Discount discount, LicenseType licenseType)
    {
        Movie = movie;
        PurchaseTime = purchaseTime;
        _discount = discount;
        _licenseType = licenseType;
    }

    public decimal GetPrice()
    {
        int discount = GetDiscount();
        decimal multiplier = 1 - discount / 100m;
        return GetBasePrice() * multiplier;
    }

    private int GetDiscount()
    {
        return _discount switch
        {
            Discount.None => 0,
            Discount.Military => 10,
            Discount.SeniorCitizen => 20,
            _ => throw new ArgumentOutOfRangeException(nameof(Discount))
        };
    }

    private decimal GetBasePrice()
    {
        return _licenseType switch
        {
            LicenseType.TwoDays => 4,
            LicenseType.LifeLong => 8,
            _ => throw new ArgumentOutOfRangeException(nameof(_licenseType))
        };
    }
    public DateTime? GetExpirationDate()
    {
        return _licenseType switch
        {
            LicenseType.TwoDays => PurchaseTime.AddDays(2),
            LicenseType.LifeLong => null,
            _ => throw new ArgumentOutOfRangeException(nameof(_licenseType))
        };
    }
}

public enum LicenseType
{
    TwoDays,
    LifeLong
}