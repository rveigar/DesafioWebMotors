using DesafioWebMotors.Models;
using System;
using System.Data.SqlClient;

namespace DesafioWebMotors.Repository
{
    public class MainRepository
    {
        private SqlConnection _sqlConnection;
        public readonly static string CONNECTIONSTRING = "Server=localhost\\SQLEXPRESS; Database=teste_webmotors;Integrated Security=SSPI";
        // private SqlConnection _sqlConnection;


        private readonly string _tabela = "tb_AnuncioWebmotors";

        public void InsertAnuncio(Anuncio anuncio)
        {
            _sqlConnection = new SqlConnection(CONNECTIONSTRING);
            
            
            var parametroDeMarca = new SqlParameter()
            {
                ParameterName = "@marca",
                Value = anuncio.Marca
            };
            var parametroDeModelo = new SqlParameter()
            {
                ParameterName = "@modelo",
                Value = anuncio.Modelo
            };

            var parametroDeVersao = new SqlParameter()
            {
                ParameterName = "@versao",
                Value = anuncio.Versao
            };

            var parametroDeAno = new SqlParameter()
            {
                ParameterName = "@ano",
                Value = anuncio.Ano
            };
            var parametroDeQuilometragem = new SqlParameter()
            {
                ParameterName = "@quilometragem",
                Value = anuncio.Quilometragem
            };
            var parametroDeObservacao = new SqlParameter()
            {
                ParameterName = "@observacao",
                Value = anuncio.Observacao
            };

            string comando = $"INSERT INTO {_tabela}" +
               $"(marca, modelo, versao, ano, quilometragem, observacao) VALUES " +
               $"(@marca, @modelo, @versao, @ano, @quilometragem, @observacao)";

            var sqlComando = new SqlCommand(comando, _sqlConnection);

            sqlComando.Parameters.Add(parametroDeMarca);
            sqlComando.Parameters.Add(parametroDeModelo);
            sqlComando.Parameters.Add(parametroDeVersao);
            sqlComando.Parameters.Add(parametroDeAno);
            sqlComando.Parameters.Add(parametroDeQuilometragem);
            sqlComando.Parameters.Add(parametroDeObservacao);



            _sqlConnection.Open();

            sqlComando.ExecuteNonQuery();

            _sqlConnection.Close();

        }

       
    }
}
