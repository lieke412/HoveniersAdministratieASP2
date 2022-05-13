using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.Interfaces;
using InterfaceLaag.DTO;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class KlantDAL : IKlantContainer
    {
        private readonly SqlConnection conn = new SqlConnection(@"Data Source = P-STUDSQL02; Initial Catalog = dbi485207; User ID = dbi485207; Password = Welkom123");

        public void Create(KlantDTO klant)
        {
            throw new NotImplementedException();
        }

        public List<KlantDTO> FindAll()
        {
            string query = "SELECT Voornaam, ID FROM Gebruiker";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            List<KlantDTO> LijstAlleKlanten = new List<KlantDTO>();
            SqlDataAdapter DataAdapter = new();
            DataAdapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            DataAdapter.Fill(ds, "Klant");

            foreach (DataRow row in ds.Tables["Klant"].Rows)
            {
                long id = Convert.ToInt64(row["ID"].ToString());
                LijstAlleKlanten.Add(new(row["Voornaam"].ToString(), id));
            }

            conn.Close();

            return LijstAlleKlanten;

        }

        public KlantDTO FindByID(long ID)
        {
            string query = "SELECT Voornaam, ID FROM Klant WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            KlantDTO dto = new(dr["Voornaam"].ToString(), ID);
            conn.Close();

            return dto;
        }

        public List<KlantDTO> FindByName(string Naam)
        {
            string query = "SELECT * FROM Gebruiker WHERE Voornaam LIKE @Naam";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Voornaam", Naam);

            conn.Open();
            List<KlantDTO> LijstNaamKlant = new List<KlantDTO>();
            SqlDataAdapter DataAdapter = new();
            DataAdapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            DataAdapter.Fill(ds, "Gebruiker");
            foreach (DataRow row in ds.Tables["Gebruiker"].Rows)
            {
                long id = Convert.ToInt64(row["ID"].ToString());
                LijstNaamKlant.Add(new(row["Voornaam"].ToString(), id));
            }
            conn.Close();

            return LijstNaamKlant;
        }
    }
}
