using System;
using System.Diagnostics;

namespace Fibonacci
{
	static class Program
	{
		static Stopwatch s = new Stopwatch();
	
		static void Main(string[] args)
		{
			int nth = 50;
			MeasureFibonacciTime(FibonacciIterative, nth);
			MeasureFibonacciTime(FibonacciRecursive, nth);
			MeasureFibonacciTime(FibonacciFormula, nth);
		}
		/// <summary>
		/// Method that calculates fibonacci n-th number iteratively.
		/// </summary>
		/// <param name="nth">Number of digit in fibonacci sequence</param>
		/// <returns>n-th digit in fibonacci sequence</returns>
		static long FibonacciIterative(int nth)
		{
			if (nth <= 1)
				return nth;

			long a = 0, b = 1;

			for (int i = 2; i <= nth; i++)
				(a, b) = (b, a+b);

			return b;
		}
		/// <summary>
		/// Method that calculates fibonacci n-th number by recursive call. Recommended to use Iterative version
		/// </summary>
		/// <param name="nth">Number of digit in fibonacci sequence</param>
		/// <returns>n-th digit in fibonacci sequence</returns>
		static long FibonacciRecursive(int nth)
		{
			if (nth <= 1)
				return nth;
			return FibonacciRecursive(nth - 1) + FibonacciRecursive(nth - 2);
		}
		/// <summary>
		/// Method that calculates fibonacci n-th number by formula [floor(((1 + sqrt(5)) / 2) ^ n / sqrt(5) + 0.5)]. The best choice for fibonacci
		/// </summary>
		/// <param name="nth">Number of digit in fibonacci sequence</param>
		/// <returns>n-th digit in fibonacci sequence</returns>
		static long FibonacciFormula(int nth)
		{
			var phi = (1 + Math.Sqrt(5)) / 2;
			return (int)Math.Floor(Math.Pow(phi, nth) / Math.Sqrt(5) + 0.5);
		}

		static void MeasureFibonacciTime(this Func<int, long> fibFunc, int nth)
		{
			Console.WriteLine(new string('-', Console.WindowWidth));
			Console.WriteLine($"Method - {fibFunc.Method.Name}");
			s.Restart();
			Console.WriteLine(fibFunc(nth));
			s.Stop();
			Console.WriteLine($"Elapsed ticks: {s.ElapsedTicks}");
		}
	}
}
