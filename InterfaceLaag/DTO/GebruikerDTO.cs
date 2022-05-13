using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.DTO
{
    public class GebruikerDTO
    {
        public readonly string Voornaam;
        public readonly string TussenVoegsels;
        public readonly string Achternaam;
        public readonly bool IsManager;
        public readonly long ID;
        public readonly string Gebruikersnaam;

        public GebruikerDTO(string voornaam, string tussenVoegsels, string achternaam, bool isManager, long iD, string gebruikersnaam)
        {
            Voornaam = voornaam;
            TussenVoegsels = tussenVoegsels;
            Achternaam = achternaam;
            IsManager = isManager;
            ID = iD;
            Gebruikersnaam = gebruikersnaam;
        }

        public GebruikerDTO(string voornaam, string gebruikersnaam, long iD)
        {
            Voornaam = voornaam;
            Gebruikersnaam = gebruikersnaam;
            ID = iD;
        }

        public GebruikerDTO(string naam, long iD)
        {
            Voornaam = naam;
            ID = iD;
        }
    }
}
