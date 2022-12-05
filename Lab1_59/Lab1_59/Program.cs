using System.Text;

namespace Lab1_59
{
    public class Program
    {
        public static string InputFilePath = @"..\..\input.txt";
        public static string OutputFilePath = @"..\..\output.txt";

        static void Main(string[] args)
        {
            FileInfo outputFileInfo = new FileInfo(OutputFilePath);
            var n_k = File.ReadLines(InputFilePath).First().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => Convert.ToInt32(n)).ToList();

            using (StreamWriter streamWriter = outputFileInfo.CreateText())
            {
                if (n_k[1] > n_k[0] || n_k[0] > 9)
                {
                    streamWriter.WriteLine("Out of range exception!");
                }
                else
                {
                    streamWriter.WriteLine(GetCountOfPermutation(n_k[0], n_k[1]));
                }
            }
        }

        private static int GetCountOfPermutation(int n, int k)
        {
            int res = 0;
            string s = String.Empty;
            for (int i = 1; i <= n; i++)
            {
                s += $"{i}";
            }
            var permutationList = new Permutations(s).GetPermutationsList();
            foreach (var permutation in permutationList)
            {
                bool b = true;
                for (int i = 0; i < permutation.Length - 1; i++)
                {
                    int t1 = permutation[i] - 48;
                    int t2 = permutation[i + 1] - 48;
                    if (Math.Abs(t1 - t2) > k)
                        b = false;
                }
                if (b)
                    res++;
            }
            return res;
        }
    }

    public class Permutations
    {
        private List<string> _permutationsList;
        private String _str;

        private void AddToList(char[] a)
        {
            var bufer = new StringBuilder("");
            for (int i = 0; i < a.Count(); i++)
            {
                bufer.Append(a[i]);
            }
            if (!_permutationsList.Contains(bufer.ToString()))
            {
                _permutationsList.Add(bufer.ToString());
            }

        }

        private void RecPermutation(char[] a, int n)
        {
            for (var i = 0; i < n; i++)
            {
                var temp = a[n - 1];
                for (var j = n - 1; j > 0; j--)
                {
                    a[j] = a[j - 1];
                }
                a[0] = temp;
                if (i < n - 1) AddToList(a);
                if (n > 0) RecPermutation(a, n - 1);
            }
        }

        public Permutations()
        {
            _str = "";
        }

        public Permutations(String str)
        {
            _str = str;
        }

        public String PermutationStr
        {
            get
            {
                return _str;
            }
            set
            {
                _str = value;
            }
        }

        public List<string> GetPermutationsList()
        {
            _permutationsList = new List<string> { _str };
            RecPermutation(_str.ToArray(), _str.Length);
            return _permutationsList;
        }
    }
}