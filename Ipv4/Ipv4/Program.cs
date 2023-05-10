using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipv4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creazione di un oggetto AddressGenerator con 32 bit a 1 per il bit di rete
            IpCalculator bit = new IpCalculator("11000000101010000000101000000101");
            Console.WriteLine(bit.generateIPv4());
            Console.WriteLine(bit.generateSubnet());

            Console.ReadLine();
        }
    }
}
