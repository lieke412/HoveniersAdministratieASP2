using InterfaceLaag.DTO;
using System.Collections.Generic;

namespace InterfaceLaag.Interfaces
{
    public interface IGebruikerContainer
    {
        public GebruikerDTO FindByID(long ID);
        public List<GebruikerDTO> FindAll();
        public List<GebruikerDTO> FindByName(string Naam);
        public void Create(GebruikerDTO gebruiker);
        GebruikerDTO GetGebruiker(string Gebruikersnaam, string Wachtwoord);
        GebruikerDTO FindByUserNameAndPassword(string gebruikersnaam, string wachtwoord);
    }
}