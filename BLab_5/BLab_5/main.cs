using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static Dictionary<string, char> RNACodonTable = new Dictionary<string, char>(){	
                                        {"AAA", 'K'},
										{"AAC", 'N'},
										{"AAG", 'K'},
										{"AAU", 'N'},
										{"ACA", 'T'},
										{"ACC", 'T'},
										{"ACG", 'T'},
										{"ACU", 'T'},
										{"AGA", 'R'},
										{"AGC", 'S'},
										{"AGG", 'R'},
										{"AGU", 'S'},
										{"AUA", 'I'},
										{"AUC", 'I'},
										{"AUG", 'M'},
										{"AUU", 'I'},
										{"CAA", 'Q'},
										{"CAC", 'H'},
										{"CAG", 'Q'},
										{"CAU", 'H'},
										{"CCA", 'P'},
										{"CCC", 'P'},
										{"CCG", 'P'},
										{"CCU", 'P'},
										{"CGA", 'R'},
										{"CGC", 'R'},
										{"CGG", 'R'},
										{"CGU", 'R'},
										{"CUA", 'L'},
										{"CUC", 'L'},
										{"CUG", 'L'},
										{"CUU", 'L'},
										{"GAA", 'E'},
										{"GAC", 'D'},
										{"GAG", 'E'},
										{"GAU", 'D'},
										{"GCA", 'A'},
										{"GCC", 'A'},
										{"GCG", 'A'},
										{"GCU", 'A'},
										{"GGA", 'G'},
										{"GGC", 'G'},
										{"GGG", 'G'},
										{"GGU", 'G'},
										{"GUA", 'V'},
										{"GUC", 'V'},
										{"GUG", 'V'},
										{"GUU", 'V'},
										{"UAA", ' '},
										{"UAC", 'Y'},
										{"UAG", ' '},
										{"UAU", 'Y'},
										{"UCA", 'S'},
										{"UCC", 'S'},
										{"UCG", 'S'},
										{"UCU", 'S'},
										{"UGA", ' '},
										{"UGC", 'C'},
										{"UGG", 'W'},
										{"UGU", 'C'},
										{"UUA", 'L'},
										{"UUC", 'F'},
										{"UUG", 'L'},
										{"UUU", 'F'}};
    public static string reserve(string s1)
    {
        StringBuilder sb = new StringBuilder();
        char[] sReverse = s1.ToCharArray();
        Array.Reverse(sReverse);
        s1 = new string(sReverse);
        for (int i = 0; i < s1.Length; i++)
        {

            if (s1[i] == 'T')
            {

                sb.Append("A");
            }
            if (s1[i] == 'A')
            {

                sb.Append("T");
            }
            if (s1[i] == 'C')
            {

                sb.Append("G");
            }
            if (s1[i] == 'G')
            {

                sb.Append("C");
            }

        }
        s1 = sb.ToString();
        return s1;
    }

    public static string translation(string pattern)
    {
        char myValue;
        string peptide = "";
        for (int i = 0; i < pattern.Length; i += 3)
        {
            myValue = RNACodonTable[pattern.Substring(i, 3)];
            peptide += myValue;
        }
        return peptide;
    }

    public static string transcription(string dna)
    {
        StringBuilder sb = new StringBuilder();
        string rna;
        for (int i = 0; i < dna.Length; i++)
        {
            if (dna[i] == 'T')
            {
                sb.Append("U");
            }
            else
            {
                sb.Append(dna[i]);
            }
        }
        rna = sb.ToString();
        return rna;
    }

    static void Main(string[] args)
    {

        string data, peptide, gCode="";
        data = Console.ReadLine();
        peptide = Console.ReadLine();
        for (int i = 0; i < data.Length - peptide.Length * 3 + 1; i++)
	{
		string rna = transcription(data.Substring(i, peptide.Length * 3));
		string reserveRNA = transcription(reserve(data.Substring(i, peptide.Length * 3)));

		if (peptide == translation(rna) || peptide == translation(reserveRNA))
		{
			gCode += data.Substring(i, peptide.Length * 3) + "\n";
		}
	}

	if (gCode!="")
	{
		gCode = gCode.Remove(gCode.Length-1);
	}

	Console.WriteLine(gCode);
    Console.Read();
    }



}