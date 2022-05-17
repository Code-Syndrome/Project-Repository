using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;

namespace Digital
{
    class SqlConnect
    {
        public static string connstring = ConfigurationManager.ConnectionStrings["DigitalConnentionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstring);

        public Hashtable Sql_Read()
        {
            string username;
            string password;
            string cmdstring = "select username,password from [user]";
            SqlCommand cmd = new SqlCommand(cmdstring,conn);
            Hashtable h = new Hashtable();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    username = dr.GetString(0);
                    password = dr.GetString(1);
                    h.Add(username, password);
                }
                return h;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
                return null;
            }
            finally
            {
                conn.Close();
            }

        }

        public void Sql_Insert(string username, string password)
        {
            try
            {
                conn.Close();
                conn.Dispose();
                string insertstring = "insert into [user] values('" + username + "','" + password + "')";
                SqlCommand sqlInsert = new SqlCommand(insertstring, conn);
                conn.Open();
                sqlInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
            }
            finally
            {
                conn.Close();
            }

        }

    }
}
