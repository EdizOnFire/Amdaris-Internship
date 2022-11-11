using LINQ;

List<Computer> computers = new List<Computer>
            {
                new Computer { Id = 1, OS = "Windows 11", Brand = "HP", ReleaseDate = 2021},
                new Computer { Id = 2, OS = "Linux", Brand = "Lenovo", ReleaseDate = 2020},
                new Computer { Id = 3, OS = "Windows 10", Brand = "Asus", ReleaseDate = 2021},
                new Computer { Id = 4, OS = "macOS", Brand = "Apple", ReleaseDate = 2022},
                new Computer { Id = 5, OS = "Windows 10", Brand = "Acer", ReleaseDate = 2020},
                new Computer { Id = 6, OS = "macOS", Brand = "Apple", ReleaseDate = 2022},
            };

var twentyTwentyComputers = computers.Any(c => c.ReleaseDate == 2020);

var windows10Computers = computers
    .Where(c => c.OS == "Windows 10")
    .Select(c => new
    {
        Brand = c.Brand,
        ReleaseDate = c.ReleaseDate,
    })
    .OrderByDescending(c => c.ReleaseDate)
    .ToList();

var appleComputers = computers
    .Where(c => c.OS == "Apple")
    .FirstOrDefault();

var reversedComputers = computers
    .Where(c => c.Brand == "Apple")
    .Reverse()
    .ToList();

var firstFourComputers = computers
    .Where(c => c.ReleaseDate == 2020)
    .Take(4)
    .OrderByDescending(c => c.Id)
    .ToList();

var containsAL = computers
    .Where(c =>
    {
        return c.Brand.Contains("A") && c.Brand.Contains("L");
    })
    .ToList();

var containsTK = from c in computers where c.OS.Contains("T") && c.OS.Contains("K") select c.OS;

var groupByBrand = computers
    .GroupBy(s => s.OS)
    .OrderByDescending(c => c.Key)
    .Select(sd => new
    {
        Key = sd.Key,
        Computers = sd.OrderBy(x => x.Brand)
    })
    .ToList();