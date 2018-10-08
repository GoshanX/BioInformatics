using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string s1;
        StringBuilder sb = new StringBuilder();
        s1 = Console.ReadLine();
        char[] sReverse = s1.ToCharArray();
        Array.Reverse(sReverse);
        s1 = new string(sReverse);
       for (int i = 0; i < s1.Length; i++)
        {
            
            if(s1[i]=='T')
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
        
      Console.WriteLine(s1);
        Console.Read();
    }
}