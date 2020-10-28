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
    public class RacaRepositories : IRaca
    {
        PetsContext conexao = new PetsContext();
        SqlCommand cmd = new SqlCommand();


        public Raca Alterar(int id, Raca a)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "UPDATE raca SET" +
                "Descricao = @descricao WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public Raca BuscarPorID(int IdRaca)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", IdRaca);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca a = new Raca();

            while (dados.Read())
            {
                a.IdRaca = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();
            }
            conexao.Desconectar();
            return a;


        }

        public Raca Cadastrar(Raca a)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "INSERT INTO raca" +
                "(Descricao)" +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.Parameters.AddWithValue("@IdRaca", a.IdRaca);
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Raca> ListarTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM raca";
            SqlDataReader dados = cmd.ExecuteReader();

            List<Raca> racas = new List<Raca>();

            while (dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                );
            }

            //Fechamos a conexao
            conexao.Desconectar();
            return racas;
        }

        Raca IRaca.Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
