using CrudPrograDataLayer;
using CrudPrograEmpleadoLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CrudPrograServiceLayer
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoDAO _empleadoDAO;

        public EmpleadoService(IEmpleadoDAO empleadoDAO)
        {
            _empleadoDAO = empleadoDAO; 
        }

        public bool Crear(Empleado empleado)
        {
            bool respuesta = false;

            try
            {
                respuesta = _empleadoDAO.Crear(empleado);

                return respuesta;

            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            bool respuesta = false;
            Empleado empleadoBase = new Empleado();
            try
            {
                empleadoBase = _empleadoDAO.GetById(id);

                if (empleadoBase == null)
                    throw new Exception("El empleado que se quiere eliminar no se encuentra en la base");

                respuesta = _empleadoDAO.Delete(id);

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(Empleado empleado)
        {
            bool respuesta = false;
            Empleado empleadoBase = new Empleado();
            try
            {
                empleadoBase = _empleadoDAO.GetById(empleado.IdEmpleado);

                if (empleadoBase == null)
                    throw new Exception("El empleado que se quiere modificar no se encuentra en la base");
                
                respuesta = _empleadoDAO.Editar(empleado);

                return respuesta;   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Empleado GetById(int id)
        {
            Empleado empleado = new Empleado();
            
            try
            {
                empleado = _empleadoDAO.GetById(id);    

                return empleado;    

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Empleado> GetEmpleados()
        {
            List<Empleado>empleados = new List<Empleado>();
            try
            {
                empleados = _empleadoDAO.GetEmpleados();

                return empleados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
