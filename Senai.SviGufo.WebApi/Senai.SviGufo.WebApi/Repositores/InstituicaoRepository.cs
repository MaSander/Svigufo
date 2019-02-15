using Senai.SviGufo.WebApi.Domais;
using Senai.SviGufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositores
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private string StringConexao = @"Data Source=.\SqlExpress;initial catalog=SENAI_SVIGUFU_TARDE;user id=sa;password=132";

        public void Alterar(InstituicaoDomain instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryAlteracao = "UPDATE INSTITUICOES SET " +
                    "RAZA_SOCIAL = @RAZAO_SOCIAL" +
                    ",NOME_FANTASIA = @NOME_FANTASIA" +
                    ",CNPJ = @CNPJ" +
                    ",LOGRADOURO = @LOGRADOURO" +
                    ",CEP = @CEP" +
                    ",UF = @UF" +
                    ",CIDADE = @CIDADE" +
                    "WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(QueryAlteracao, con);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                cmd.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                cmd.Parameters.AddWithValue("@CNPJ", instituicao.CNPJ);
                cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", instituicao.CEP);
                cmd.Parameters.AddWithValue("@UF", instituicao.UF);
                cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Cadastrar(InstituicaoDomain instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO INTITUICOES (RAZAO_SOCIAL,NOME_FANTASIA,CNPJ,LOGRADOURO,CEP,UF,CIDADE) VALUES (@RAZAO_SOCIAL),(@NOME_FANTASIA),(@CNPJ),(@LOGRADOURO),(@CEP),(@UF),(@CIDADE)";
                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                cmd.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                cmd.Parameters.AddWithValue("@CNPJ", instituicao.CNPJ);
                cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", instituicao.CEP);
                cmd.Parameters.AddWithValue("@UF", instituicao.UF);
                cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryDelete = "DELETE FROM INSTITUICOES WHERE ID =@ID";

                SqlCommand cmd = new SqlCommand(QueryDelete, con);

                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<InstituicaoDomain> Listar()
        {
            List<InstituicaoDomain> instituicoes = new List<InstituicaoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT ID, RAZAO_SOCIAL, NOME_FANTASIA, CNPJ, LOGRADOURO, CEP, UF, CIDADE FROM INSTITUICOES";

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        InstituicaoDomain instituicao = new InstituicaoDomain
                        {
                            Id = Convert.ToInt32(rdr["ID"])
                            ,
                            RazaoSocial = rdr["RAZAO_SOCIAL"].ToString()
                            ,
                            NomeFantasia = rdr["NOME_FANTASIA"].ToString()
                            ,
                            CNPJ = Convert.ToChar(rdr["CNPJ"]).ToString()
                            ,
                            Logradouro = rdr["LOGRADOURO"].ToString()
                            ,
                            CEP = rdr["CEP"].ToString()
                            ,
                            UF = rdr["UF"].ToString()
                            ,
                            Cidade = rdr["CIDADE"].ToString()
                        };

                        instituicoes.Add(instituicao);
                    }
                }
            }

            return instituicoes;
        }
    }
}
