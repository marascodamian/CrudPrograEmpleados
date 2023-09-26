using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudPrograEmpleadoLayer;
using CrudPrograDataLayer;

namespace CrudPrograServiceLayer
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoDAO _departamentoDao;

        public DepartamentoService(IDepartamentoDAO departamentoDao)
        {
            _departamentoDao = departamentoDao;
        }

        public List<Departamento> GetDepartamentos()
        {
            List<Departamento> deptos = new List<Departamento>();   

            try
            {
                deptos = _departamentoDao.GetDepartamentos();
                
                return deptos;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
