using CrudPrograEmpleadoLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudPrograServiceLayer
{
    public interface IEmpleadoService
    {
        List<Empleado> GetEmpleados();
        Empleado GetById(int id);
        bool Crear(Empleado empleado);
        bool Editar(Empleado empleado);
        bool Delete(int id);
    }
}
