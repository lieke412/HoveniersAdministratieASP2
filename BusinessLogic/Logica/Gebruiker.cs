using InterfaceLaag.DTO;

namespace BusinessLogic.Logica
{
    public class Gebruiker
    {
        public readonly string Voornaam;
        public readonly string TussenVoegsels;
        public readonly string Achternaam;
        public readonly bool isManager;
        public readonly long ID;
        public readonly string Gebruikersnaam;

        public Gebruiker(string voornaam, string tussenVoegsels, string achternaam, bool isManager, long id, string gebruikersnaam)
        {
            Voornaam = voornaam;
            TussenVoegsels = tussenVoegsels;
            Achternaam = achternaam;
            this.isManager = isManager;
            ID = id;
            Gebruikersnaam = gebruikersnaam;
        }

        public Gebruiker(string naam, long iD, string gebruikersnaam)
        {
            Voornaam = naam;
            ID = iD;
            Gebruikersnaam = gebruikersnaam;
        }

        public Gebruiker (GebruikerDTO dto)
        {
            Voornaam = dto.Voornaam;
            ID = dto.ID;
            Gebruikersnaam = dto.Gebruikersnaam;
        }

        public GebruikerDTO GetDTO()
        {
            GebruikerDTO dto = new GebruikerDTO(Voornaam, ID);
            return dto;
        }

        public override string ToString()
        {
            return Gebruikersnaam;
        }
    }
}