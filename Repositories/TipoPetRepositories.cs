using PetsApi.Context;
using PetsApi.Domains;
using PetsApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PetsApi.Repositories
{
    public class TipoPetRepositories : ITipoPet
    {
        PetsContext conexao = new PetsContext();
        SqlCommand cmd = new SqlCommand();
        public TipoPet Alterar(int id,TipoPet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE tipospets SET " +
                "Descricao = @descricao, " +
                " WHERE Idtipospests = @id";

            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.Parameters.AddWithValue("@id", a.IdTipoPet);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

      


        public TipoPet BuscarPorID(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * tipospets  FROM  WHERE IdTiposPets= @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

             TipoPet a = new TipoPet();

            while (dados.Read())
            {
                a.IdTipoPet = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();

            return a;
        }

        public TipoPet Cadastrar(TipoPet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO tipospets" +
                "(Descricao)" +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM tipospets WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<TipoPet> ListarTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM tipospets";
            SqlDataReader dados = cmd.ExecuteReader();

            List<TipoPet> tipoPets = new List<TipoPet>();

            while (dados.Read())
            {
                tipoPets.Add(
                    new TipoPet()
                    {
                        IdTipoPet= Convert.ToInt32(dados.GetValue(0)),
                        Descricao = (string)dados.GetValue(1)
,
                    }
                );
            }

            //Fechamos a conexao
            conexao.Desconectar();
            return tipoPets;
        }

        TipoPet ITipoPet.Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
