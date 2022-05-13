using InterfaceLaag.Interfaces;
using InterfaceLaag.DTO;
using BusinessLogic.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Container
{
    public class GebruikerContainer
    {
        private readonly IGebruikerContainer container;

        public GebruikerContainer(IGebruikerContainer container)
        {
            this.container = container;
        }

        public Gebruiker FindByID(long ID)
        {
            GebruikerDTO dto = container.FindByID(ID);
            return new Gebruiker(dto);
        }
        
        public Gebruiker GetGebruiker(string gebruikersnaam, string email)
        {
            GebruikerDTO gebruikerDTO;

            gebruikerDTO = container.GetGebruiker(gebruikersnaam, email);
            Gebruiker gebruiker = new Gebruiker(gebruikerDTO.Voornaam, gebruikerDTO.ID, gebruikerDTO.Gebruikersnaam);

            return gebruiker;
        }

        public Gebruiker FindByUserNameAndPassword(string Gebruikersnaam, string Wachtwoord)
        {
            GebruikerDTO dto = container.FindByUserNameAndPassword(Gebruikersnaam, Wachtwoord);
            if (dto == null)
            {
                return null;
            }
            return new Gebruiker(dto);
        }
    }
}
