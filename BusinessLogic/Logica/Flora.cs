using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.DTO;

namespace BusinessLogic.Logica
{
    public class Flora
    {
        public readonly string Naam;
        public readonly long ID;

        public Flora(string naam, long iD)
        {
            Naam = naam;
            ID = iD;
        }

        public Flora (FloraDTO dto)
        {
            Naam = dto.Naam;
            ID = dto.ID;
        }

        public FloraDTO GetDTO()
        {
            FloraDTO dto = new FloraDTO(Naam, ID);
            return dto;
        }
    }
}
