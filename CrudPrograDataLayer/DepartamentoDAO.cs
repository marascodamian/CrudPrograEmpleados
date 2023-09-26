using CrudPrograEmpleadoLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text; 

namespace CrudPrograDataLayer
{
    public class DepartamentoDAO : IDepartamentoDAO
    {
        public List<Departamento> GetDepartamentos()
        {
  
            List<Departamento> listaDeptos = new List<Departamento>();

            using (SqlConnection conexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = conexion.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM fn_departamentos()";
                    
                try
                {
                    conexion.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Departamento depto = new Departamento
                            {
                                IdDepartamento = Convert.ToInt32(reader["IdDepartamento"].ToString()),
                                Nombre = reader["Nombre"].ToString()
                            };

                            listaDeptos.Add(depto);
                        }
                    }

                    return listaDeptos;

                }catch(Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
