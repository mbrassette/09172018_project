using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Archon.Interview
{
	class Program
	{
		static void Main(string[] args)
		{
			string file = Path.Combine(AppContext.BaseDirectory, "ClientData.txt");
            // list that will hold all of the properties that the code reads from file: ClientData.txt
            List<Property> Properties = new List<Property>();

            using (StreamReader reader = new StreamReader(File.OpenRead(file)))
			{
                while (!reader.EndOfStream)
                {
                    // Read one line of the input file
                    var line = reader.ReadLine();

                    // This if statement is for not processing the last line which will be blank
                    if (!string.IsNullOrEmpty(line))
                    {
                        // Variables used to collect what's read from each line in the file
                        String AccountNumber = line.Substring(0, 9);
                        String AddressLine1 = line.Substring(9, 100);
                        String AddressLine2 = line.Substring(109, 100);

                        // Create new object with the data read from the current line of the file
                        Property PropertyObj = new Property(AccountNumber, AddressLine1, AddressLine2);

                        // Stash this object into the list of property objects
                        Properties.Add(PropertyObj);
                    }
                }
            }

            // Now, let's answer the questions in the README.md
            // 1. How many properties are in the file?
            Console.WriteLine("1. How many properties are in the file?: " + Properties.Count + " properties are in the file.");
            // 2. How many properties are apartments?
            Console.WriteLine("2. How many properties are apartments?: " + Properties.Where(p => p.IsApartment).ToList().Count + " properties are apartments.");
            // 3. How many properties are in the third district?
            Console.WriteLine("3. How many properties are in the third district?: " + Properties.Where(p => p.District == '3').ToList().Count + " properties are in the third district.");
            // 4. How many properties are on Tchoupitoulas Street?
            Console.WriteLine("4. How many properties are on Tchoupitoulas Street?: " + Properties.Where(p => p.IsOnStreet("Tchoupitoulas")).ToList().Count + " properties are on Tchoupitoulas Street.");

            Console.WriteLine("Done.");
			Console.ReadKey();
		}
	}
}