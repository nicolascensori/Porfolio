using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DAL
    {
        public DataSet GetPersonas()
        {
            DataSet ds = new DataSet("TimeRanges");

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString()))
            {
                SqlCommand sqlComm = new SqlCommand("GetPersonas", conn);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            return ds;

        }

        public DataSet get_usuario()
        {
            DataSet ds = new DataSet("TimeRanges");

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString()))
            {
                SqlCommand sqlComm = new SqlCommand("get_usuario", conn);                

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            return ds;

        }

        public void alta_usuario(String email, String nombre, String clave)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString()))
            {
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@nombre";
                param1.Value = nombre;
                param1.DbType = DbType.AnsiStringFixedLength;

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@email";
                param2.Value = email;
                param2.DbType = DbType.AnsiStringFixedLength;

                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@clave";
                param3.Value = clave;
                param3.DbType = DbType.AnsiStringFixedLength;

                SqlCommand sqlComm = new SqlCommand("alta_usuario", conn);

                sqlComm.CommandType = CommandType.StoredProcedure;

                sqlComm.Parameters.Add(param1);
                sqlComm.Parameters.Add(param2);
                sqlComm.Parameters.Add(param3);

                conn.Open(); //se agrega en los procedures de insercion

                sqlComm.ExecuteNonQuery();

            }

        }

        public void alta_persona(String nombre, String direccion)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString()))
            {

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@nombre";
                param1.Value = nombre;
                param1.DbType = DbType.AnsiStringFixedLength;

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@direccion";
                param2.Value = direccion;
                param2.DbType = DbType.AnsiStringFixedLength;


                SqlCommand sqlComm = new SqlCommand("alta_persona", conn);

                sqlComm.CommandType = CommandType.StoredProcedure;

                sqlComm.Parameters.Add(param1);
                sqlComm.Parameters.Add(param2);

                conn.Open();

                sqlComm.ExecuteNonQuery();
            }
        }

        public void baja_persona(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString()))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = id;
                param.DbType = DbType.Int32;

                SqlCommand sqlComm = new SqlCommand("baja_persona", conn);

                sqlComm.CommandType = CommandType.StoredProcedure;

                sqlComm.Parameters.Add(param);

                conn.Open();

                sqlComm.ExecuteNonQuery();
            }
        }

        public void modificacion_persona(int id, String nombreNuevo, String direccionNueva)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString()))
            {
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@id";
                param1.Value = id;
                param1.DbType = DbType.Int32;

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@nombre_nuevo";
                param2.Value = nombreNuevo;
                param2.DbType = DbType.AnsiStringFixedLength;

                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@direccion_nueva";
                param3.Value = direccionNueva;
                param3.DbType = DbType.AnsiStringFixedLength;

                SqlCommand sqlComm = new SqlCommand("modificacion_persona", conn);

                sqlComm.CommandType = CommandType.StoredProcedure;

                sqlComm.Parameters.Add(param1);
                sqlComm.Parameters.Add(param2);
                sqlComm.Parameters.Add(param3);

                conn.Open();

                sqlComm.ExecuteNonQuery();
            }
        }
    }
}
