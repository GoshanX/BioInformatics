using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Blab_try
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
    
    static string CycloSpectrum(string peptide)
    {
        
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

        static bool IsConsistent(string peptide, string spectrum)
        {
            List<string> specMass = spectrum.Split(' ').ToList();
            List<string> peptideMass = LinearSpectrum(peptide).Split(' ').ToList();

            foreach (var m in peptideMass)
            {
                if (!specMass.Contains(m))
                {
                    return false;
                }

            }

            return true;
        }

        static void Main(string[] args)
        {
            string spectrum = Console.ReadLine();
            int parentMass = int.Parse(spectrum.Split(' ').Last());

            List<string> peptides = new List<string>() { "" };
            List<string> outputPeptides = new List<string>();

            while (peptides.Count > 0)
            {
                peptides = Expand(peptides);
                List<string> immutablePeptides = new List<string>(peptides);
                foreach (var peptide in immutablePeptides)
                {
                    if (getMass(peptide) == parentMass)
                    {
                        if (CycloSpectrum(peptide) == spectrum)
                        {
                            outputPeptides.Add(peptide);
                        }
                        peptides.Remove(peptide);
                    }
                    else if (!IsConsistent(peptide, spectrum))
                    {
                        peptides.Remove(peptide);
                    }
                }
            }

            List<string> outputMasses = new List<string>();
            foreach (var p in outputPeptides)
            {
                List<string> m = new List<string>();
                foreach (var s in p)
                {
                    m.Add(aminoacidMassTable[s].ToString());
                }

                outputMasses.Add(string.Join("-", m));
            }

            Console.WriteLine(string.Join(" ", outputMasses.Distinct()));
            Console.ReadKey();
        }
    }
