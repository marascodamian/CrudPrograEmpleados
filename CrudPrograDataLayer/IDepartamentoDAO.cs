using CrudPrograEmpleadoLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudPrograDataLayer
{
    public interface IDepartamentoDAO
    {
        List<Departamento> GetDepartamentos();

    }
}
