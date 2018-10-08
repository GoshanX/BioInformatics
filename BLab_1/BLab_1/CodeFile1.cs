using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        string s1, s2;
        int i = 0;
        int x = -1;
        int count = -1; 
        Console.WriteLine("Введите строку");
        s1 = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Введите подстроку");
        s2 = Console.ReadLine();
         
        while (i != -1)
        {
            i = s1.IndexOf(s2, x + 1);
            x = i;
            count++;
        }
        Console.WriteLine(count);
        Console.ReadLine();

    }
}