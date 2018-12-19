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
    }
        
        
        

            return true;
        }
        static List<string> Get_KD_Motifs(string kMer, int Real_discrepancies)
        {
    text = text.Replace(",", " ,");//чтобы запятая была словом
    text = text.Replace(".", " .");
    string[] words = text.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
    string pref1 = words[0];
    string pref2 = words[1];
    string pref3 = words[2];
    string suf;
    for (int i = 3; i < words.Count(); i++)
    {
        suf = words[i];
        if (!words_dict.ContainsKey(pref1))
        {
            StringCollection sc = new StringCollection();
            sc.Add(suf);
            Dictionary<string, StringCollection> d1 = new Dictionary<string, StringCollection>();
            d1.Add(pref3, sc);
            Dictionary<string, Dictionary<string, StringCollection>> d2 = new Dictionary<string, Dictionary<string, StringCollection>>();
            d2.Add(pref2, d1);
            words_dict.Add(pref1, d2);
        }
        else if (!words_dict[pref1].ContainsKey(pref2))
        {
            StringCollection sc = new StringCollection();
            sc.Add(suf);
            Dictionary<string, StringCollection> d1 = new Dictionary<string, StringCollection>();
            d1.Add(pref3, sc);
            words_dict[pref1].Add(pref2, d1);
        }
        else if (!words_dict[pref1][pref2].ContainsKey(pref3))
        {
            StringCollection sc = new StringCollection();
            sc.Add(suf);
            words_dict[pref1][pref2].Add(pref3, sc);
        }
        else if (!words_dict[pref1][pref2][pref3].Contains(suf))
            words_dict[pref1][pref2][pref3].Add(suf);
        pref1 = pref2;
        pref2 = pref3;
        pref3 = suf;
    }
}

        static void Main(string[] args)
        {
            string[] letters = Console.ReadLine().Split(' ');
            int k = int.Parse(letters[0]);
            int q = int.Parse(letters[1]);

            string buf = "";
            while (true)
            {
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                    break;

                buf += s + ' ';
            }

            string[] dna = buf.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

    nt hash1 = (5381 << 16) + 5381;
    int hash2 = hash1;

    int* pint = (int*)src;
    int len = this.Length;
    while (len > 0)
    {
        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ pint[0];
        if (len <= 2)
        {
            break;
        }
        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ pint[1];
        pint += 2;
        len -= 4;
    }
    return hash1 + (hash2 * 1566083941);
}

            patterns = patterns.Distinct().ToList();

            Console.WriteLine(string.Join(" ", patterns));
            Console.ReadKey();
        }
    }
