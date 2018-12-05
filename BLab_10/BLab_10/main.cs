using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static Dictionary<char, int> aminoacidMassTable = new Dictionary<char, int>() { {'G', 57},
                                        {'A', 71},
                                        {'S', 87},
                                        {'P', 97},
                                        {'V', 99},
                                        {'T', 101},
                                        {'C', 103},
                                        {'I', 113},
                                        {'L', 113},
                                        {'N', 114},
                                        {'D', 115},
                                        {'K', 128},
                                        {'Q', 128},
                                        {'E', 129},
                                        {'M', 131},
                                        {'H', 137},
                                        {'F', 147},
                                        {'R', 156},
                                        {'Y', 163},
                                        {'W', 186} };
        public static int getMass(string pattern)
        {
            int key;
            int mass = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                char[] c = pattern.ToCharArray();
                key = aminoacidMassTable[c[i]];
                mass += key;
            }

            return mass;
        }
        static string CycloSpectrum(string peptide)
        {
            

            StringBuilder buf = new StringBuilder(peptide);

            for (int i = 0; i < peptide.Length; i++)
            {
                buf.Append(peptide[i]);
            }

            List<int> spectrum = new List<int>();
            spectrum.Add(0);

            string cyclePeptide = peptide + peptide;

            for (int i = 1; i < peptide.Length; i++)
            {
                for (int j = 0; j < peptide.Length; j++)
                {
                    spectrum.Add(getMass(buf.ToString().Substring(j, i)));
                }
            }

            spectrum.Add(getMass(peptide));

            spectrum.Sort();

            return string.Join(" ", spectrum);
        }

        static int Score(string peptide, string spectrum)
        {
            List<string> pmas = CycloSpectrum(peptide).Split(' ').ToList();
            List<string> spmas = spectrum.Split(' ').ToList();

            int score = 0;
            foreach (var mass in pmas)
            {
                if (spmas.Contains(mass))
                {
                    spmas.Remove(mass);
                    score++;
                }
            }

            return score;
        }
        static void Main(string[] args)
        {
            string peptide = Console.ReadLine();
            string spectrum = Console.ReadLine();

            Console.WriteLine(Score(peptide, spectrum));
            Console.ReadKey();
        }
    }
