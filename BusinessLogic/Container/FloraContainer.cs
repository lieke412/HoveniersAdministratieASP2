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
    public class FloraContainer
    {
        public readonly IFloraContainer container;

        public FloraContainer(IFloraContainer container)
        {
            this.container = container;
        }

        public Flora FindByID(long ID)
        {
            FloraDTO dto = container.FindByID(ID);
            return new Flora(dto);
        }
    }
}
