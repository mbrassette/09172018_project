using System;
using System.IO;

namespace Archon.Interview
{
	class Program
	{
		static void Main(string[] args)
		{
			string file = Path.Combine(AppContext.BaseDirectory, "ClientData.txt");

			using (StreamReader reader = new StreamReader(File.OpenRead(file)))
			{
				// TODO: Read file using one of:
				// reader.ReadLine();
				// reader.ReadToEnd();
				// reader.Read(...
			}

			Console.WriteLine("Done.");
			Console.ReadKey();
		}
	}
}