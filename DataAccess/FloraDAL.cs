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
    public class FloraDAL : IFloraContainer
    {
        private readonly SqlConnection conn = new SqlConnection(@"Data Source = P-STUDSQL02; Initial Catalog = dbi485207; User ID = dbi485207; Password = Welkom123");

        public void Create(FloraDTO flora)
        {
            throw new NotImplementedException();
        }

        public List<FloraDTO> FindAll()
        {
            string query = "SELECT Voornaam, id FROM Flora";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            List<FloraDTO> LijstAlleKlanten = new List<FloraDTO>();
            SqlDataAdapter DataAdapter = new();
            DataAdapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            DataAdapter.Fill(ds, "Flora");

            foreach (DataRow row in ds.Tables["Flora"].Rows)
            {
                long id = Convert.ToInt64(row["ID"].ToString());
                LijstAlleKlanten.Add(new(row["Naam"].ToString(), id));
            }

            conn.Close();

            return LijstAlleKlanten;

        }

        public FloraDTO FindByID(long ID)
        {
            string query = "SELECT Voornaam, ID FROM Flora WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            FloraDTO dto = new(dr["Naam"].ToString(), ID);
            conn.Close();

            return dto;
        }

        public List<FloraDTO> FindByName(string Naam)
        {
            string query = "SELECT Naam, ID FROM Flora WHERE Naam LIKE @Naam";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Naam", Naam);

            conn.Open();
            List<FloraDTO> LijstNaamKlant = new List<FloraDTO>();
            SqlDataAdapter DataAdapter = new();
            DataAdapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            DataAdapter.Fill(ds, "Gebruiker");
            foreach (DataRow row in ds.Tables["Gebruiker"].Rows)
            {
                long id = Convert.ToInt64(row["ID"].ToString());
                LijstNaamKlant.Add(new(row["Naam"].ToString(), id));
            }
            conn.Close();

            return LijstNaamKlant;
        }
    }
}
