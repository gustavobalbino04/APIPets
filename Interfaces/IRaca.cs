using PetsApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsApi.Interfaces
{
    interface IRaca
    {
        List<Raca> ListarTodos();
        Raca BuscarPorID(int IdRaca);
        Raca Cadastrar(Raca a);
        Raca Alterar(int id, Raca a);
        Raca Excluir(int id);
    }
}
