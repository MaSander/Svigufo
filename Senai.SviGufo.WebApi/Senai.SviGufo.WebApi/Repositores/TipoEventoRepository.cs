using Senai.SviGufo.WebApi.Domais;
using Senai.SviGufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositores
{
    public class TipoEventoRepository : ITipoEventoRepository
    {

        //Data Source - nome do servidor
        //Inital Catalogo - nome do banco
        //User Id = Usuário]
        //Password = senha
        //Caso seja autenticação do windows não passa usuário e senha e passe  'integrated security=true'
        private string StringConexao = @"Data Source=.\SqlExpress;initial catalog=SENAI_SVIGUFU_TARDE;user id=sa;password=132";

        public void Alterar(TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryAlteracao = "UPDATE TIPOS_EVENTOS SET TITULO = @TITULO ID =@ID";
                SqlCommand cmd = new SqlCommand(QueryAlteracao, con);
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                cmd.Parameters.AddWithValue("@ID", tipoEvento.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Cadastra(TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //
                string QueryInsert = "INSERT INTO TIPOS_EVENTOS(TITULO) VALUES(@TITULO)";
                //Cria um objeto comando passando como parametro a query e a conexão
                SqlCommand cmd = new SqlCommand(QueryInsert, con);
                //Atribui o nome do evento ao parametro
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                //Abre o banco
                con.Open()
                //Executa o comando
;               cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryDelete = "DELETE FROM TIPOS_EVENTOS WHERE ID =@ID";
                SqlCommand cmd = new SqlCommand(QueryDelete, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Listar os tipos de eventos
        /// </summary>
        /// <returns>Retorna um lista de TipoEventoDomain</returns>
        public List<TipoEventoDomain> Listar()
        {
            //Objeto
            List<TipoEventoDomain> TiposEventos = new List<TipoEventoDomain>();

            //Define a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT ID, TITULO FROM TIPOS_EVENTOS";

                //Define o comando que será executado
                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    //Abro a conexão com o Banco de dados
                    con.Open();

                    //Objeto que armazena os dados retornados da execução da instalação
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        //Crio um objeto tipo evento e atribuo os valores da tabela
                        //ao objeto
                        TipoEventoDomain tipoEvento = new TipoEventoDomain
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Nome = rdr["TITULO"].ToString()
                        };

                        //Adiciona o objeto na lista de tipos de eventos
                        TiposEventos.Add(tipoEvento);
                    }
                }
            }

            return TiposEventos;
        }
    }
}
