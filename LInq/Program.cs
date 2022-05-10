using System;
using System.Linq;

namespace LInq
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter text :");

			//var input = Console.ReadLine();
			var input = "The “C# Professional” course includes the topics I discuss in my CLR via C# book and teaches " +
			            "how the CLR works thereby showing you how to develop applications and reusable components for the .NET Framework.";
			
			var groups = input.Split(" ").Distinct().GroupBy(s => s.Length).OrderBy(g => g.Key);
			
			foreach (var group in groups)
			{
				Console.WriteLine($"Words of length: {group.Key}, Count {group.Count()}");
				group.ToList().ForEach(word => Console.WriteLine($"\t {word}"));
			}

		}
	}
}
