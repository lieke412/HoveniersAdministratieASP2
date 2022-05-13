using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.DTO;

namespace InterfaceLaag.Interfaces
{
    public interface IFloraContainer
    {
        public FloraDTO FindByID(long ID);
        public List<FloraDTO> FindAll();
        public List<FloraDTO> FindByName(string Naam);
        public void Create(FloraDTO flora);
    }
}
