using SisTransp.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisTransp.Dominio.Repositorios
{
    public  interface IChoferRepositorio
    {
        List<Chofer> Listar();
        Chofer Obtener(int id);
        void Registrar(Chofer chofer);

        void Editar(Chofer chofer);

        void Eliminar(int id);
    }
}
