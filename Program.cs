DateTime now = DateTime.Now;

var license1 = new TwoDaysLicense("Secret Life of Pets", now);
var license2 = new LifeLongLicense("Matrix", now);

PrintLicenseDetails(license1);
PrintLicenseDetails(license2);

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