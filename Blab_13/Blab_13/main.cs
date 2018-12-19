using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class main
    {
    static void Get_words(string set_of_letters, int length, string prev)
    {
        StringBuilder sb = new StringBuilder();
        private bool find_in_text(string f, string s1, string s2, string s3)
        {
            sb.Clear();
            if ((!string.IsNullOrWhiteSpace(s1)) && (!string.IsNullOrWhiteSpace(s2)) && (!string.IsNullOrWhiteSpace(s3)))
            {
                if (!string.IsNullOrWhiteSpace(f)) sb.Append(f).Append(" ");
                sb.Append(sb.ToString()).Append(s1).Append(" ").Append(s2).Append(" ").Append(s3);
                if (text.Contains(sb.ToString()))
                    return true;
            }
            return false;
        }
        static int Hammings_distance(string s1, string s2)
        {
            int distance = 0;
            int length = s1.Length;

            for (int i = 0; i < length; i++)
            {
                if (s1[i] != s2[i])
                {
                    distance++;
                }
            }

            return distance;
        }
        
        static int d(string pattern, string[] dna)
        {
            int sum = 0;

            foreach (string dnai in dna)
            {
                sum += min_dist(pattern, dnai);
            }

            return sum;
        }
        static string MedianString(string[] dna, int k)
        {
            int distance = int.MaxValue;
            string median = "";
            List<string> allKmers = Get_words("AGCT", k);

            foreach (string kmer in allKmers)
            {
                if (distance > d(kmer, dna))
                {
                    distance = d(kmer, dna);
                    median = kmer;
                }
            }

            return median;
        }
        static void Main(string[] args)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            
           
            
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
        Console.WriteLine(MedianString(dna, k));
            Console.ReadLine();
        }
    }
