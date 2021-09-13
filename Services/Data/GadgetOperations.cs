using LogDAO.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogDAO.Services.Data
{
    public class GadgetOperations
    {
        string constring = @"Data Source=DESKTOP-1IIFCOO\SQLEXPRESS;Initial Catalog=BondGadget;Integrated Security=True";
        internal List<GadgetModel> FetchAll()
        {
            List<GadgetModel> ReturnList = new List<GadgetModel>();

            string query = "select * from dbo.Gadget";

            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GadgetModel gad = new GadgetModel();
                        gad.Id = reader.GetInt32(0);
                        gad.Name = reader.GetString(1);
                        gad.Description = reader.GetString(2);
                        gad.AppearsIn = reader.GetString(3);
                        gad.WithThisActor = reader.GetString(4);

                        ReturnList.Add(gad);
                    }
                }
            }
            return ReturnList;
        }

        internal GadgetModel FetchOne(int id)
        {
            string query = "select * from dbo.Gadget where Id=@id";

            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GadgetModel gd = new GadgetModel();

                if (reader.HasRows)
                {
                    reader.Read();

                    gd.Id = reader.GetInt32(0);
                    gd.Name = reader.GetString(1);
                    gd.Description = reader.GetString(2);
                    gd.AppearsIn = reader.GetString(3);
                    gd.WithThisActor = reader.GetString(4);
                }
                return gd;
            }
        }

        internal GadgetModel Edit(int id)
        {
            string query = "select * from dbo.Gadget where Id=@id";
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GadgetModel gad = new GadgetModel();
                if (reader.HasRows)
                {
                    reader.Read();
                    gad.Id = reader.GetInt32(0);
                    gad.Name = reader.GetString(1);
                    gad.Description = reader.GetString(2);
                    gad.AppearsIn = reader.GetString(3);
                    gad.WithThisActor = reader.GetString(4);
                }
                return gad;
            }
        }

        internal GadgetModel Update(GadgetModel ad)
        {
            string query = "Update dbo.Gadget set Name=@name,Description=@description,ApperarsIn=@appearsin,WithThisActor=@with where Id=@id";
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ad.Id;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 50).Value = ad.Name;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar, 50).Value = ad.Description;
                cmd.Parameters.Add("@appearsin", System.Data.SqlDbType.VarChar, 50).Value = ad.AppearsIn;
                cmd.Parameters.Add("@with", System.Data.SqlDbType.VarChar, 50).Value = ad.WithThisActor;

                con.Open();
                int st = cmd.ExecuteNonQuery();

            }
            return null;
        }

        internal void DeleteOperation(int id)
        {
            string query = "Delete from dbo.Gadget  where Id=@id";
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        internal void InsertGadget(GadgetModel gadget)
        {
            string query = "Insert into dbo.Gadget(Name,Description,ApperarsIn,WithThisActor) values (@name,@description,@appearsin,@with)";
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 50).Value = gadget.Name;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar, 50).Value = gadget.Description;
                cmd.Parameters.Add("@appearsin", System.Data.SqlDbType.VarChar, 50).Value = gadget.AppearsIn;
                cmd.Parameters.Add("@with", System.Data.SqlDbType.VarChar, 50).Value = gadget.WithThisActor;

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        internal List<GadgetModel> SearchAll(string searchByName)
        {
            string query = "select * from dbo.Gadget where Name LIKE @search";
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@search", System.Data.SqlDbType.VarChar).Value = "%" + searchByName + "%";

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<GadgetModel> gadlist = new List<GadgetModel>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GadgetModel gad = new GadgetModel();
                        gad.Id = reader.GetInt32(0);
                        gad.Name = reader.GetString(1);
                        gad.Description = reader.GetString(2);
                        gad.AppearsIn = reader.GetString(3);
                        gad.WithThisActor = reader.GetString(4);

                        gadlist.Add(gad);
                    }
                }
                return gadlist;
            }
        }
    }
}