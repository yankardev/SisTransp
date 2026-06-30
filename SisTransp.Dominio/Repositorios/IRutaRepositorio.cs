using SisTransp.Dominio.Entidades;
using System.Collections.Generic;

namespace SisTransp.Dominio.Repositorios
{
    public interface IRutaRepositorio
    {
        List<Ruta> Listar();

        Ruta Obtener(int id);

        void Registrar(Ruta ruta);

        void Editar(Ruta ruta);

        void Eliminar(int id);
    }
}