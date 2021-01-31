using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace GuidUtility.Test
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var sequence = new List<System.Guid>();

            for (var i = 0; i < 10; i++)
            {
                var guid = Guid.SequentialGuid();
                sequence.Add(guid);

                Console.WriteLine(guid);
            }

            Console.WriteLine();

            sequence = sequence.OrderBy(x=>x).ToList();

            foreach (var guid in sequence)
            {
                Console.WriteLine(guid);
            }
        }
    }
}
