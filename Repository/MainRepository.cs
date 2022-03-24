using DesafioWebMotors.Models;
using System;
using System.Collections.Generic;
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
        public List<Anuncio> ListarAnuncios()
        {
            _sqlConnection = new SqlConnection(CONNECTIONSTRING);
            string comando = $"select * from  {_tabela}";

            var sqlComando = new SqlCommand(comando, _sqlConnection);

            List<Anuncio> anuncios = new List<Anuncio>();


            _sqlConnection.Open();

            var resultado = sqlComando.ExecuteReader();
            while (resultado.Read())
            {
                var anuncio = new Anuncio()
                {
                    Id = (int)resultado["Id"],
                    Marca = resultado["Marca"].ToString(),
                    Modelo = resultado["Modelo"].ToString(),
                    Versao = resultado["Versao"].ToString(),
                    Ano = (int)resultado["Ano"],
                    Quilometragem = (int)resultado["Quilometragem"]
                };

             anuncios.Add(anuncio);
                         
            }
            _sqlConnection.Close();
            return anuncios;
            
        }

        public void ExcluirAnuncio(int idAnuncio)
        {
            _sqlConnection = new SqlConnection(CONNECTIONSTRING);
            var comando = $"DELETE FROM {_tabela} WHERE Id = @id";
            var sqlCommand = new SqlCommand(comando, _sqlConnection);
            var parametro = new SqlParameter()
            {
                ParameterName = "@id",
                Value = idAnuncio
            };

            sqlCommand.Parameters.Add(parametro);

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public Anuncio SelecionarAnuncio(int idAnuncio)
        {
            _sqlConnection = new SqlConnection(CONNECTIONSTRING);

            string comando = $"SELECT * FROM {_tabela} WHERE Id = @id";
            var sqlCommand = new SqlCommand(comando, _sqlConnection);
            var selecionadoAnuncio = new Anuncio();
            var parametro = new SqlParameter()
            {
                ParameterName = "@id",
                Value = idAnuncio
            };
            sqlCommand.Parameters.Add(parametro);
            _sqlConnection.Open();

            var resultado = sqlCommand.ExecuteReader();

            while (resultado.Read())
            {
                var anuncio = new Anuncio()
                {
                    Id = (int)resultado["Id"],
                    Marca = resultado["Marca"].ToString(),
                    Modelo = resultado["Modelo"].ToString(),
                    Versao = resultado["Versao"].ToString(),
                    Ano = (int)resultado["Ano"],
                    Quilometragem = (int)resultado["Quilometragem"]
                };
                selecionadoAnuncio=anuncio;

            }

            _sqlConnection.Close();
            return selecionadoAnuncio;



        }

        public void AtualizarAnuncio(Anuncio anuncio, int idAnuncio )
        {
            _sqlConnection = new SqlConnection(CONNECTIONSTRING);
            var comandoUpdate = $@"update {_tabela}
                                   set 
                                       marca=@Marca,
                                       modelo=@Modelo,
                                       versao=@Versao
                                   where id=@Id";
            var comando = new SqlCommand(comandoUpdate, _sqlConnection);

            var paramID = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = idAnuncio
            };
            var paramMarca = new SqlParameter()
            {
                ParameterName = "@Marca",
                Value = anuncio.Marca
            };
            var paramModelo = new SqlParameter()
            {
                ParameterName = "@Modelo",
                Value = anuncio.Modelo
            };
            var paramVersao = new SqlParameter()
            {
                ParameterName = "@Versao",
                Value = anuncio.Versao
            };
            comando.Parameters.Add(paramID);
            comando.Parameters.Add(paramMarca);
            comando.Parameters.Add(paramModelo);
            comando.Parameters.Add(paramVersao);





            _sqlConnection.Open();
            comando.ExecuteNonQuery();
            _sqlConnection.Close();

        }

    }
}

    

