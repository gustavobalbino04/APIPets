using PetsApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsApi.Interfaces
{
    interface ITipoPet
    {
        List<TipoPet> ListarTodos();
        TipoPet BuscarPorID(int id);
        TipoPet Cadastrar(TipoPet a);
        TipoPet Alterar(int id, TipoPet a);
        TipoPet Excluir(int id);

    }
}
