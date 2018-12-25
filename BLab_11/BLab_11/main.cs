using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


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

    static int Score(string peptide, string spectrum)
    {
        List<string> pmas = LinearSpectrum(peptide).Split(' ').ToList();
        List<string> spmas = spectrum.Split(' ').ToList();

        int score = 0;
        for(int i=0;i<pmas.Count;i++)
        {
            if (spmas.Contains(pmas[i]))
            {
                spmas.Remove(pmas[i]); //Для подсчёта повторных масс
                score++;
            }
        }
        return score;
      
    }
    static List<string> Trim(List<string> lboard, string spec, int n)
        {
            lboard.Sort((p, q) => Score(q, spec).CompareTo(Score(p, spec)));

            if (lboard.Count >= n+1)
            {
                int last = n;
                 for (int i = n; i < lboard.Count; i++)
                {

                    if (Score(lboard[n - 1], spec) == Score(lboard[i], spec))
                    {
                              last = i;
                    }

                else break;
                }
            int size = last + 1;

                lboard = lboard.Take(size).ToList();
            }

            return lboard;
        }

        static void Main()
        {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(),
                         Console.InputEncoding,
                         false,
                         bufferSize: 1024));

        int n = int.Parse(Console.ReadLine());
            string spectrum = Console.ReadLine();
            int parentmas = int.Parse(spectrum.Split(' ').Last());

            List<string> lboard = new List<string>() { "" };
            string lPeptide = "";

            while (lboard.Count() > 0)
            {
                lboard = Expand(lboard);
                List<string> constPeptides = new List<string>(lboard);

            for (int i = 0; i < constPeptides.Count; i++)
            {
                if (getMass(constPeptides[i]) == parentmas)
                {
                   
                        if (Score(constPeptides[i], spectrum) > Score(lPeptide, spectrum))
                        {
                            lPeptide = constPeptides[i];
                        }
                    }
                    else if (getMass(constPeptides[i]) > parentmas)
                    {
                        lboard.Remove(constPeptides[i]);
                    }
                }

                lboard = Trim(lboard, spectrum, n);
            }

            List<string> resmas = new List<string>();

        for(int i = 0; i < lPeptide.Length; i++)
        {
            resmas.Add(aminoacidMassTable[lPeptide[i]].ToString());
        }
            for(int i = 0; i < resmas.Count-1; i++)
        {
            Console.Write(resmas[i]+"-");
        }
        Console.WriteLine(resmas[resmas.Count-1]);

            
            Console.ReadLine();
        }
    }
