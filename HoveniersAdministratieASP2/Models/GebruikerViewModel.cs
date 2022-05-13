namespace HoveniersAdministratieASP2.Models
{
    public class GebruikerViewModel
    {
        public int Id { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Email { get; set; }

        public GebruikerViewModel(int id, string gebruikersnaam, string email)
        {
            Id = id;
            Gebruikersnaam = gebruikersnaam;
            Email = email;
        }
    }
}