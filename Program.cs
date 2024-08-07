DateTime now = DateTime.Now;

var license1 = new MovieLicense("Secret Life of Pets", now, Discount.None, LicenseType.TwoDays);
var license2 = new MovieLicense("Matrix", now, Discount.None, LicenseType.LifeLong);

PrintLicenseDetails(license1);
PrintLicenseDetails(license2);

var license3 = new MovieLicense("Secret Life of Pets", now, Discount.Military, LicenseType.LifeLong);
var license4 = new MovieLicense("Matrix", now, Discount.SeniorCitizen, LicenseType.TwoDays);

PrintLicenseDetails(license3);
PrintLicenseDetails(license4);

Console.ReadKey();

static void PrintLicenseDetails(MovieLicense license)
{
    Console.WriteLine($"Movie: {license.Movie}");
    Console.WriteLine($"Price: {GetPrice(license)}");
    Console.WriteLine($"Valid for: {GetValidFor(license)}");

    Console.WriteLine();
}

static string GetPrice(MovieLicense license)
{
    return $"${license.GetPrice():0.00}";
}

static string GetValidFor(MovieLicense license)
{
    DateTime? expirationDate = license.GetExpirationDate();

    if (expirationDate == null)
        return "Forever";

    TimeSpan timeSpan = expirationDate.Value - DateTime.Now;

    return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
}