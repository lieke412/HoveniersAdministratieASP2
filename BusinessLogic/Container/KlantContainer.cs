using InterfaceLaag.Interfaces;
using BusinessLogic.Logica;
using InterfaceLaag.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Container
{
    public class KlantContainer
    {
        private readonly IKlantContainer container;

        public KlantContainer(IKlantContainer container)
        {
            this.container = container;
        }

        public Klant FindByID(long ID)
        {
            KlantDTO dto = container.FindByID(ID);
            return new Klant(dto);
        }
    }
}
