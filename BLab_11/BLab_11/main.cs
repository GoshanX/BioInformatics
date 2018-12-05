using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Bio_try
    {
    static Dictionary<char, int> aminoacidMassTable = new Dictionary<char, int>()
        {
                                        {'G', 57},
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
                                        {'W', 186}
        };

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
    static List<string> Expand(List<string> peptides)
        {
            List<string> newPeptides = new List<string>();

            foreach (var peptide in peptides)
            {
                foreach (var p in aminoacidMassTable.Keys)
                {
                    newPeptides.Add(peptide + p);
                }
            }
            return newPeptides;
        }
    static string LinearSpectrum(string peptide)
    {
        if (peptide.Length == 1) return aminoacidMassTable[peptide[0]].ToString();

        StringBuilder buf = new StringBuilder(peptide);

        for (int i = 0; i < peptide.Length; i++)
        {
            buf.Append(peptide[i]);
        }

        List<int> masses = new List<int>();
        masses.Add(0);

        string cyclePeptide = peptide + peptide;

        for (int i = 1; i < peptide.Length; i++)
        {
            for (int j = 0; j < peptide.Length; j++)
            {
                masses.Add(getMass(buf.ToString().Substring(j, i)));
            }
        }

        masses.Add(getMass(peptide));

        masses.Sort();

        return string.Join(" ", masses);
    }

    static int Score(string peptide, string spectrum)
    {
        List<string> pmas = LinearSpectrum(peptide).Split(' ').ToList();
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
    static List<string> Trim(List<string> lboard, string spectrum, int n)
        {
            lboard.Sort((a, b) => Score(b, spectrum).CompareTo(Score(a, spectrum)));
            if (lboard.Count > n)
            {
                int last = n;
                for (int i = n; i < lboard.Count; i++)
                {
                    if (Score(lboard[n - 1], spectrum) == Score(lboard[i], spectrum))
                    {
                        last = i;
                    }
                    else break;
                }

                lboard = lboard.Take(last + 1).ToList();
            }

            return lboard;
        }

        static void Main(string[] args)
        {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(),
                         Console.InputEncoding,
                         false,
                         bufferSize: 1024));

        int n = int.Parse(Console.ReadLine());
            string spectrum = Console.ReadLine();
            int parentMass = int.Parse(spectrum.Split(' ').Last());

            List<string> lboard = new List<string>() { "" };
            string lPeptide = "";

            while (lboard.Count() > 0)
            {
                lboard = Expand(lboard);
                List<string> constPeptides = new List<string>(lboard);
                foreach (var peptide in constPeptides)
                {
                    if (getMass(peptide) == parentMass)
                    {
                        if (Score(peptide, spectrum) > Score(lPeptide, spectrum))
                        {
                            lPeptide = peptide;
                        }
                    }
                    else if (getMass(peptide) > parentMass)
                    {
                        lboard.Remove(peptide);
                    }
                }

                lboard = Trim(lboard, spectrum, n);
            }

            List<string> outMasses = new List<string>();
            foreach (var s in lPeptide)
            {
                outMasses.Add(aminoacidMassTable[s].ToString());
            }

            Console.WriteLine(string.Join("-", outMasses));
            Console.ReadLine();
        }
    }
