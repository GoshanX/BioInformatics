using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        long len;
        len = int.Parse(Console.ReadLine());
        Console.WriteLine(len * (len - 1));
        Console.ReadLine();
    }
}