using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Ipv4
{
    interface IAddressConverter
    {
        string generateIPv4();
        string generateSubnet();
    }
    /// <summary>
    /// classe utilizzata per convertire 32 bit in un indirizzo ipv4 con la sua corrispettiva subnet
    /// </summary>
    public class IpCalculator : IAddressConverter
    {
        string binaryAddress;
        string networkBits;
        string hostBits;
        /// <summary>
        /// costruttore  
        /// </summary>
        /// <param name="binar">chiede in input i 32 bit</param>
        public IpCalculator(string binar)
        {
            binaryAddress = binar;
            //Estrae i primi 24 bit dell'indirizzo IP
            networkBits = binaryAddress.Substring(0, 24);

            // Estrae gli ultimi 8 bit dell'indirizzo IP
            hostBits = binaryAddress.Substring(24, 8);

        }

        /// <summary>
        /// Genera un indirizzo IPv4 a partire dai 32 bit impostati in fase di configurazione.
        /// </summary>
        /// <returns>L'indirizzo IPv4 generato come stringa nel formato "xxx.xxx.xxx.xxx".</returns>


        public string generateIPv4()
        {
            // Verifica che l'indirizzo IP binario contenga 32 bit
            if (binaryAddress.Length != 32)
            {
                throw new ArgumentException("L'indirizzo IP binario deve contenere 32 bit");
            }


            // Converte i primi 24 bit in decimale per ottenere l'indirizzo IP
            uint networkAddress = Convert.ToUInt32(networkBits, 2);
            IPAddress ipAddress = new IPAddress(BitConverter.GetBytes(networkAddress));
            return "Indirizzo IP: " + ipAddress.ToString();


        }

        /// <summary>
        /// Genera  l'indirizzo di subnet a partire dall'indirizzo ip inserito in precedenza.
        /// </summary>
        /// <returns>L'indirizzo di subnet generato come stringa nel formato "xxx.xxx.xxx.xxx".</returns>


        public string generateSubnet()
        {

            // Calcola il prefisso di rete dalla lunghezza dei bit di rete
            int netMaskLength = networkBits.Length;
            uint netMask = 0xFFFFFFFF << (32 - netMaskLength);

            // Converte il prefisso di rete in decimale
            IPAddress subnetMask = new IPAddress(BitConverter.GetBytes(netMask));

            // Restituisce l'indirizzo IP e la subnet in formato decimale
            return "Subnet:" + subnetMask.ToString();
        }
    }
}
