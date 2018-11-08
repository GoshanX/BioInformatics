using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        char myValue;
        string pattern;
        string peptide = "";
        Dictionary<string, char> RNACodonTable = new Dictionary<string, char>(){	
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
       
        pattern = Console.ReadLine();
        for (int i = 0; i < pattern.Length; i += 3)
        {
            myValue = RNACodonTable[pattern.Substring(i, 3)];
            peptide += myValue;
        }
        Console.WriteLine(peptide);
        Console.Read();

    }
    
}