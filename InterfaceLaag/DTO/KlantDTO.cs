using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.DTO
{
    public class KlantDTO
    {
        public readonly string Voornaam;
        public readonly long ID;

        public KlantDTO(string voornaam, long iD)
        {
            Voornaam = voornaam;
            ID = iD;
        }
    }
}
