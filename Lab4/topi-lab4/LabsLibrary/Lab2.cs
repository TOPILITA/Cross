namespace LabsLibrary
{
	public static class Lab2
	{
		private static int[] a;
		private static int[,] d;
		private static int n, k;

		public static string Execute(string pathInpFile = "INPUT.TXT")
		{
			var inputNumbers = File.ReadLines(pathInpFile).First().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => Convert.ToInt32(n)).ToList();

			if (inputNumbers[0] < 1 || inputNumbers[0] > 180)
			{
				return "Out of range exception!";
			}
			else
			{
				n = inputNumbers.First();
				k = inputNumbers.Last();
				a = inputNumbers.Skip(1).SkipLast(1).ToArray();
				d = new int[k + 1, n + 1];
				return GetMaxNumberOfCoins().ToString();
			}
		}

		private static int GetMaxNumberOfCoins()
		{
			return f(k, 0);
		}

		private static int f(int k, int i)
		{
			if (d[k, i] == 0)
			{
				d[k, i] = l(Math.Min(k, n - i), 0, i);
			}
			return d[k, i];
		}

		private static int l(int j, int r, int i)
		{
			return j <= 0 ? r : l(j - 1, Math.Max(r, s(i) - f(j, i + j)), i);
		}

		private static int s(int i)
		{
			return i >= n ? 0 : a[i] + s(i + 1);
		}
	}
}