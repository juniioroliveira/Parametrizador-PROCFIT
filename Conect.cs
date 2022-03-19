using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace Parametrizador_PROCFIT
{
    internal class Conect
    {
        public static SqlConnection con = new SqlConnection();
        public static SqlConnection Conectar(string servidor, string database, string senhaBanco)
        {
            con = new SqlConnection();

            #region METODO CONECTAR
            try
            {

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    ///CONSTRUTOR
                    con.ConnectionString = @"DATA SOURCE=" + servidor + "; INITIAL CATALOG=" + database + @"; USER ID=SA; PASSWORD=" + senhaBanco + ";";
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

            return con;
        }
    }
}
