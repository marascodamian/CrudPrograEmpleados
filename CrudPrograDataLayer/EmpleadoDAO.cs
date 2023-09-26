using CrudPrograEmpleadoLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudPrograDataLayer
{
    public class EmpleadoDAO : IEmpleadoDAO
    {
        public bool Crear(Empleado empleado)
        {
            bool respueta = false;

            using (SqlConnection conexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = conexion.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CrearEmpleado";
                cmd.Parameters.AddWithValue("@Nombre",empleado.Nombre);
                cmd.Parameters.AddWithValue("@FechaNacimiento",empleado.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Email",empleado.Email);
                cmd.Parameters.AddWithValue("@IdDepartamento",empleado.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Puesto",empleado.Puesto);
                cmd.Parameters.AddWithValue("@Sueldo",empleado.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato",empleado.FechaContrato);
                cmd.Parameters.AddWithValue("@Activo",empleado.Activo);


                try
                {
                    conexion.Open();
                    int filas  = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        respueta = true;
                    }

                    return respueta;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }


        }

        public bool Delete(int id)
        {
            bool respueta = false;

            using (SqlConnection conexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = conexion.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_EliminarEmpleado";
                cmd.Parameters.AddWithValue("@IdEmpleado", id);


                try
                {
                    conexion.Open();
                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        respueta = true;
                    }

                    return respueta;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public bool Editar(Empleado empleado)
        {
            bool respueta = false;

            using (SqlConnection conexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = conexion.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_EditarEmpleado";
                cmd.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Email", empleado.Email);
                cmd.Parameters.AddWithValue("@IdDepartamento", empleado.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Puesto", empleado.Puesto);
                cmd.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", empleado.FechaContrato);
                cmd.Parameters.AddWithValue("@Activo", empleado.Activo);


                try
                {
                    conexion.Open();
                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        respueta = true;
                    }

                    return respueta;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public Empleado GetById(int id)
        {
            Empleado empleado = new Empleado();

            using (SqlConnection conexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = conexion.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM fn_empleado(@IdEmpleado)";
                cmd.Parameters.AddWithValue("@IdEmpleado", id);

                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            empleado.IdEmpleado = Convert.ToInt32(reader["IdEmpleado"].ToString());
                            empleado.Nombre = reader["Nombre"].ToString();
                            empleado.Apellido = reader["Apellido"].ToString();
                            empleado.FechaNacimiento = reader["FechaNacimiento"].ToString();
                            empleado.Email = reader["email"].ToString();
                            empleado.Departamento = new Departamento
                            {
                                IdDepartamento = Convert.ToInt32(reader["IdDepartamento"].ToString()),
                                Nombre = reader["Departamento"].ToString()
                            };
                            empleado.Puesto = reader["Puesto"].ToString();
                            empleado.Sueldo = Convert.ToDecimal(reader["Sueldo"]);
                            empleado.FechaContrato = reader["FechaContrato"].ToString();
                            empleado.Activo = Convert.ToBoolean(reader["Activo"].ToString());
                        }
                    }

                    return empleado;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public List<Empleado> GetEmpleados()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();

            using (SqlConnection conexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = conexion.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM fn_empleados()";

                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empleado empleado = new Empleado
                            {
                                IdEmpleado = Convert.ToInt32(reader["IdEmpleado"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                FechaNacimiento = reader["FechaNacimiento"].ToString(),
                                Email = reader["email"].ToString(), 
                                Departamento = new Departamento
                                {
                                    IdDepartamento = Convert.ToInt32(reader["IdDepartamento"].ToString()),
                                    Nombre = reader["Departamento"].ToString()
                                },
                                Puesto = reader["Puesto"].ToString(),
                                Sueldo = Convert.ToDecimal(reader["Sueldo"]),
                                FechaContrato = reader["FechaContrato"].ToString(),
                                Activo = Convert.ToBoolean(reader["Activo"].ToString())
                            };

                            listaEmpleados.Add(empleado);
                        }
                    }

                    return listaEmpleados;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
