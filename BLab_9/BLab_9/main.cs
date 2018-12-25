using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
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
    static List<string> Expand(List<string> peptide)
    {
        List<string> expandPeptides = new List<string>();
        for (int i = 0; i < peptide.Count; i++)
        {
            for (int j = 0; j < aminoacidMassTable.Count; j++)
            {
                expandPeptides.Add(peptide[i] + aminoacidMassTable.ElementAt(j).Key);
            }
        }
        return expandPeptides;
    }

    static string CycloSpectrum(string peptide)
    {
        if (peptide.Length == 1) return aminoacidMassTable[peptide[0]].ToString();

        List<int> resmas = new List<int>() { 0 };

        StringBuilder buf = new StringBuilder(peptide);

        for (int i = 0; i < peptide.Length; i++)
        {
            buf.Append(peptide[i]);
        }
        for (int i = 0; i < peptide.Length; i++)
        {
            resmas.Add(aminoacidMassTable[peptide[i]]);
        }
        resmas.Add(getMass(peptide));


        string cyclePeptide = peptide + peptide;

        for (int i = 2; i < peptide.Length; i++)
        {
            for (int j = 0; j < peptide.Length; j++)
            {
                resmas.Add(getMass(buf.ToString().Substring(j, i)));
            }
        }

        resmas.Sort();

        return string.Join(" ", resmas);
    }

    static string LinearSpectrum(string peptide)
    {
        if (peptide.Length == 1) return aminoacidMassTable[peptide[0]].ToString();

        List<int> resmas = new List<int>() { 0 };

        StringBuilder buf = new StringBuilder(peptide);

        for (int i = 0; i < peptide.Length; i++)
        {
            buf.Append(peptide[i]);
        }
        for (int i = 0; i < peptide.Length; i++)
        {
            resmas.Add(aminoacidMassTable[peptide[i]]);
        }
        resmas.Add(getMass(peptide));

        string cyclePeptide = peptide + peptide;

        for (int i = 2; i < peptide.Length; i++)
        {
            for (int j = 0; j < peptide.Length - i; j++)
            {

                resmas.Add(getMass(buf.ToString().Substring(j, i)));

            }
        }

        resmas.Sort();

        return string.Join(" ", resmas);
    }

    static bool IsAgree(string peptide, string spectrum)
    {
        List<string> specmas = spectrum.Split(' ').ToList();
        List<string> peptidemas = LinearSpectrum(peptide).Split(' ').ToList();
        for (int i = 0; i < peptidemas.Count; i++)
        {
            if (!specmas.Contains(peptidemas[i])) return false;
        }
        return true;
    }
    static void Main(string[] args)
    {
        string spectrum = Console.ReadLine();
        int parentmas = int.Parse(spectrum.Split(' ').Last());

        List<string> peptides = new List<string>() { "" };
        List<string> respeptides = new List<string>();

        while (peptides.Count != 0)
        {
            peptides = Expand(peptides);
            List<string> constPeptides = new List<string>(peptides);
            for (int i = 0; i < constPeptides.Count; i++)
            {
                if (getMass(constPeptides[i]) == parentmas)
                {
                    if (CycloSpectrum(constPeptides[i]) == spectrum)
                    {
                        respeptides.Add(constPeptides[i]);
                    }
                    peptides.Remove(constPeptides[i]);
                }
                else if (!IsAgree(constPeptides[i], spectrum))
                {
                    peptides.Remove(constPeptides[i]);
                }
            }
        }
        List<string> resmas = new List<string>();
        for (int i = 0; i < respeptides.Count; i++)
        {
            List<string> tmp = new List<string>();
            for (int j = 0; j < respeptides[i].Length; j++)
            {
                tmp.Add(aminoacidMassTable[respeptides[i][j]].ToString());
            }
            resmas.Add(string.Join("-", tmp));
        }



        Console.WriteLine(string.Join(" ", resmas.Distinct()));
        Console.ReadKey();
    }
}
