using System;

string filePath = @"Data\Countries.txt";

// Check if the file exists
if (File.Exists(filePath))
{
    // Read all lines from the file and convert to a list using Linq
    List<string> lines = File.ReadAllLines(filePath).ToList();
    // Process each line
    foreach (string line in lines)
    {
        // Split the line into parts using the semicolon as a delimiter
        string[] parts = line.Split(';');
        // Check if we have at least 4 parts (Country, Population, GDP, Currency)
        if (parts.Length >= 4)
        {
            string country = parts[0].Trim();
            double.TryParse(parts[1].Trim(), out double population);
            double.TryParse(parts[2].Trim(), out double GDP);
            string currency = parts[3].Trim();

            // Output the parsed information
            //Console.WriteLine($"Country: {country}, Population: {population}, GDP: {GDP}, Currency: {currency}");
        }
        else
        {
            Console.WriteLine($"Invalid line format: {line}");
        }
    }
}
else
    {
    // Handle the case where the file does not exist
    Console.WriteLine($"The file {filePath} does not exist.");
}