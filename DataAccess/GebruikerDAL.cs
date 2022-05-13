using InterfaceLaag.Interfaces;
using InterfaceLaag.DTO;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class GebruikerDAL : IGebruikerContainer
    {
        private readonly SqlConnection conn = new SqlConnection(@"Data Source = P-STUDSQL02; Initial Catalog = dbi485207; User ID = dbi485207; Password = Welkom123");

        public void Create(GebruikerDTO gebruiker)
        {
            throw new NotImplementedException();
        }

        public List<GebruikerDTO> FindAll()
        {
            string query = "SELECT Voornaam, id FROM Gebruiker";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            List<GebruikerDTO> LijstAlleGebruikers = new List<GebruikerDTO>();
            SqlDataAdapter DataAdapter = new();
            DataAdapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            DataAdapter.Fill(ds, "Gebruiker");

            foreach (DataRow row in ds.Tables["Gebruiker"].Rows)
            {
                long id = Convert.ToInt64(row["ID"].ToString());
                LijstAlleGebruikers.Add(new(row["Voornaam"].ToString(), id));
            }

            conn.Close();

            return LijstAlleGebruikers;
        }

        public GebruikerDTO FindByID(long ID)
        {
            string query = "SELECT Voornaam, ID FROM Gebruiker WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GebruikerDTO dto = new(dr["Voornaam"].ToString(), ID);
            conn.Close();

            return dto;
        }

        public List<GebruikerDTO> FindByName(string Naam)
        {
            string query = "SELECT * FROM Gebruiker WHERE Naam LIKE @Naam";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Voornaam", Naam);

            conn.Open();
            List<GebruikerDTO> LijstNaamGebruiker = new List<GebruikerDTO>();
            SqlDataAdapter DataAdapter = new();
            DataAdapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            DataAdapter.Fill(ds, "Gebruiker");
            foreach (DataRow row in ds.Tables["Gebruiker"].Rows)
            {
                long id = Convert.ToInt64(row["ID"].ToString());
                LijstNaamGebruiker.Add(new(row["Voornaam"].ToString(), id));
            }
            conn.Close();

            return LijstNaamGebruiker;
        }

        public GebruikerDTO FindByUserNameAndPassword(string Gebruikersnaam, string Wachtwoord)
        {
            string query = "SELECT ID " +
                "FROM Gebruiker " +
                "WHERE Gebruikersnaam = @Gebruikersnaam AND Wachtwoord = @Wachtwoord";

            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter DataAdapter = new();
            cmd.Parameters.AddWithValue("@Gebruikersnaam", Gebruikersnaam);
            cmd.Parameters.AddWithValue("@Wachtwoord", Wachtwoord);
            object obj = cmd.ExecuteScalar();
            if (obj == null)
            {
                conn.Close();
                return null;
            }
            else
            {
                conn.Close();
                string idstring = obj.ToString();
                int id = Convert.ToInt32(idstring);
                return FindByID(id);
            }
        }

        public GebruikerDTO GetGebruiker(string gebruikersnaam, string email)
        {
            conn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string query = "SELECT Gebruikerid, gebruikersnaam, wachtwoord, email FROM Gebruiker WHERE gebruikersnaam = '" + gebruikersnaam + "'";

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();
            if (!dataReader.HasRows)
            {
                conn.Close();
                return new GebruikerDTO(null, null, 0);
            }
            try
            {
                dataReader.Read();

                int id = Convert.ToInt32(dataReader.GetValue(0));
                string gsebruikersnaam = dataReader.GetValue(1).ToString();
                //string eemail = dataReader.GetValue(4).ToString();
                string wachtwoord = dataReader.GetValue(2).ToString();
                string naamm = dataReader.GetValue(3).ToString();
                //string eemail = dataReader.GetValue(3).ToString();

                GebruikerDTO gebruiker = new GebruikerDTO(naamm, gsebruikersnaam, id);
                conn.Close();
                return gebruiker;

            }
            finally
            {

            }
        }
    }
}