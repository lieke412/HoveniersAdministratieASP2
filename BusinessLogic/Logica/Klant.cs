using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.DTO;

namespace BusinessLogic.Logica
{
    public class Klant
    {
        public readonly string Voornaam;
        public readonly long ID;

        public Klant(string voornaam, long iD)
        {
            Voornaam = voornaam;
            ID = iD;
        }

        public Klant (KlantDTO dto)
        {
            Voornaam = dto.Voornaam;
            ID = dto.ID;
        }

        public KlantDTO GetDTO()
        {
            KlantDTO dto = new KlantDTO(Voornaam, ID);
            return dto;
        }
    }
}
