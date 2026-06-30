using SisTransp.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisTransp.Dominio.Repositorios
{
    public interface IUnidadRepositorio
    {
        List<Unidad> Listar();
        Unidad Obtener(int id);
        void Registrar(Unidad unidad);
        void Editar(Unidad unidad);
        void Eliminar(int id);
        void CambiarEstado(int id,string estado);
    }
}
