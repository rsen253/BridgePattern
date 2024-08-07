DateTime now = DateTime.Now;
var noDiscount = new NoDiscount();

var license1 = new TwoDaysLicense("Secret Life of Pets", now, noDiscount);
var license2 = new LifeLongLicense("Matrix", now, noDiscount);

PrintLicenseDetails(license1);
PrintLicenseDetails(license2);

var license3 = new LifeLongLicense("Secret Life of Pets", now, new MilitaryDiscount());
var license4 = new TwoDaysLicense("Matrix", now, new SeniorCitizenDiscount());

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