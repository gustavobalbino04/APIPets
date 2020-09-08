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
        Raca BuscarPorID(int id);
        Raca Cadastrar(Raca a);
        Raca Alterar(Raca a);
        Raca Excluir(Raca a);
    }
}
