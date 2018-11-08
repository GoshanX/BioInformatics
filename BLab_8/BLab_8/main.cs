using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class Program
{
    static void Main(string[] args)
    {
	int mas;
    mas = int.Parse(Console.ReadLine());
	
	int [] Masses = new int[] { 57, 71, 87, 97, 99, 101, 103, 113, 114, 115, 128, 129, 131, 137, 147, 156, 163, 186 };
    Dictionary<int, ulong> count = new Dictionary<int, ulong> (){ { 0, 1 } };

    for (int i = 57; i <= mas; i++)
    {
        count[i] = 0;

        for (int j = 0; j < 18; j++)
        {
            if (count.ContainsKey(i - Masses[j]))
            {
                count[i] += count[i - Masses[j]];
            }
        }
    }

	Console.WriteLine( count[mas]);
    Console.Read();
}
}