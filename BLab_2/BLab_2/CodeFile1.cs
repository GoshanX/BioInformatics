using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class Program
{
    static int func(string s1, string s2, int pos = -1)
    {
      
        int i = 0;
        int count = -1;
        
        while (i != -1)
        {
            i = s1.IndexOf(s2, pos + 1); 
            pos = i;
            count++;
        }
        
        
     
        return count;
    }
    static void Main(string[] args)
    {
    
        int size = 10000,l,count,max_count=1;
        string s1;
        List<int> result= new List<int>();
        string[] tmp = new string[size];

        s1 = Console.ReadLine();
        Console.WriteLine();
        l = int.Parse(Console.ReadLine());

       
        for (int i = 0; i < s1.Length; ++i) 
            {
                if (s1.Length - i > l - 1)
                {
                    tmp[i] = s1.Substring(i, l);

                    if (tmp[i].Length == l)
                    {
                        count = func(s1, tmp[i], i);

                        if (count == max_count)
                        {
                            result.Add(i);

                        }
                        if (count > max_count)
                        {
                            max_count = count;
                            result.Clear();
                            result.Insert(0, i);
                        }
                    }
                }
            }

        foreach (int i in result)
        {
            Console.WriteLine(tmp[i]);
            Console.WriteLine();
        }
 
    }
}