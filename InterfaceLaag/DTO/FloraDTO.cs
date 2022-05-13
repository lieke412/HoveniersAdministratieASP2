using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.DTO
{
    public class FloraDTO
    {
        public readonly string Naam;
        public readonly long ID;

        public FloraDTO(string naam, long iD)
        {
            Naam = naam;
            ID = iD;
        }
    }
}
