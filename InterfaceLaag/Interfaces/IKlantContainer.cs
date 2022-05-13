using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.DTO;

namespace InterfaceLaag.Interfaces
{
    public interface IKlantContainer
    {
        public KlantDTO FindByID(long ID);
        public List<KlantDTO> FindAll();
        public List<KlantDTO> FindByName(string Voornaam);
        public void Create(KlantDTO klant);
    }
}
