using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Dublicates
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter sorted array of numbers, split by commas + space (ex: [1, 2]etc)");
			//int[] array = Console.ReadLine().Split(", ").Select(s => Convert.ToInt32(s)).ToArray();
			int[] array = new[] { 1, 2,2,3,3, 3, 4, 4, 56 }; //input array

			List<int> outArray = new List<int>(){array[0]}; // out
			
			for (var index = 1; index < array.Length; index++)
				//if (outArray[^1] != t) // Alternate only for sorted array
				if (!outArray.Contains(array[index])) // Alternate for both variants (sorted and unsorted)
					outArray.Add(array[index]);

			foreach (var i in outArray)
				Console.Write(i + " ");
		}
	}
}
