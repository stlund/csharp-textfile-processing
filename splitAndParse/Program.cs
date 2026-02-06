//TEST AV EGEN KOD.
//string filePath = @"Data\Countries.txt";

//// Check if the file exists
//if (File.Exists(filePath))
//{
//    // Read all lines from the file and convert to a list using Linq
//    List<string> lines = File.ReadAllLines(filePath).ToList();
//    // Process each line
//    foreach (string line in lines)
//    {
//        // Split the line into parts using the semicolon as a delimiter
//        string[] parts = line.Split(';');
//        // Check if we have at least 4 parts (Country, Population, GDP, Currency)
//        if (parts.Length >= 4)
//        {
//            string country = parts[0].Trim();
//            double.TryParse(parts[1].Trim(), out double population);
//            double.TryParse(parts[2].Trim(), out double GDP);
//            string currency = parts[3].Trim();

//            //// Output the parsed information
//            //Console.WriteLine($"Country: {country}, Population: {population}, GDP: {GDP}, Currency: {currency}");

//            //// GDP per capita calculation with Linq
//            //double gdpPerCapita = population > 0 ? GDP / population : 0;

//            //// Output the GDP per capita
//            //Console.WriteLine($"GDP per capita for {country}: {gdpPerCapita:F2}");


//        }
//        else
//        {
//            Console.WriteLine($"Invalid line format: {line}");
//        }
//    }
//}
//else
//    {
//    // Handle the case where the file does not exist
//    Console.WriteLine($"The file {filePath} does not exist.");
//}


// Storing the file path in a variable
using System.Globalization;

string filePath = @"Data\Countries.txt";

// Checking if the file exists befor attempting to read it
if (!File.Exists(filePath))
{
    Console.WriteLine($"The file {filePath} does not exist.");
    return;
}

// Using a StreamReader to read the file line by line
using (StreamReader reader = new StreamReader(filePath))
{
    // Creating a list to store all lines from the file
    List<string> allLines = new List<string>();
    // Reading the first line from the file
    StreamReader reader1 = new StreamReader(filePath);
    {
        // Reading the first line from the file
        string line = reader.ReadLine();
        // Looping throught the file until we reach the end (when line is null)
        while (line != null)
        {
            allLines.Add(line);                     // Adding the line to the list
            line = reader.ReadLine();               // Reading the next line from the file
        }

        // Creating a list to store valid countries (With no whitespace or null values)
        List<string> validCountries = new List<string>();
        foreach (string country in allLines)
        {
            if (!string.IsNullOrWhiteSpace(country))   // Checking if the country is not null or whitespace
            {
                validCountries.Add(country);         // Adding the valid country to the list

            }
        }
        // Using Linq to filter countries that start with " S "
        var countriesStartingWithS = validCountries.Where(c => c.StartsWith("S", StringComparison.OrdinalIgnoreCase));
        var euroCountries = validCountries.Where(curr => curr.Contains("EUR", StringComparison.OrdinalIgnoreCase));
        // Print every country that uses EUR as currency and counts them in a variable
        Console.WriteLine("Countries that use EUR as currency:");
        int euroCountryCount = 0;
        foreach (var euroCountry in euroCountries)
        {
            Console.WriteLine(euroCountry);
            euroCountryCount++;
        }
        Console.WriteLine($"Total countries using EUR: {euroCountryCount}");
        //// Go trought every row in validCountries
        //foreach (string lines in validCountries)
        //{
        //    var parts = lines.Split(';');   // Split when " ; "
        //    if (parts[0].StartsWith("S"))   // Select Countries that starts with " S "
        //    {
        //        //Print every part of the string that has " S " as the first letter.
        //        Console.WriteLine($"{parts[0]}, {parts[1]}, {parts[2]}, {parts[3]}");
        //    }
        //}
    }
}
