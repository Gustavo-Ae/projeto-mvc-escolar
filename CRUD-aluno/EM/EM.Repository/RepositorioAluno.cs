
using EM.Domain.Enums;
using EM.Domain.Model;
using EM.Repository.Conexao;
using FirebirdSql.Data.FirebirdClient;
using System.Reflection.Emit;

namespace EM.Repository
{
    public class RepositorioAluno : RepositorioAbstrato<Aluno>
    {

        //public IEnumerable<Aluno> Get(Predicate<>)
        //{
        //    return null;
        //}

        public IEnumerable<Aluno> GetByContendoNoNome(string parteDoNome)
        {
            FbConnection conexao = ConexaoFirebird.getConexao();

            try
            {
                conexao.Open();

                List<Aluno> Alunos = new();

                //FbCommand comandoSQL = new FbCommand($"SELECT * FROM TB_ALUNO WHERE TBALUNO_NOME LIKE '%{parteDoNome}%';", conexao);
                FbCommand comandoSQL = new FbCommand($"SELECT * FROM TB_ALUNO WHERE UPPER(TBALUNO_NOME) LIKE UPPER('%{parteDoNome}%');", conexao);
                // SELECT * FROM TB_ALUNO WHERE TBALUNO_NOME LIKE '%{parteDoNome}%'  COLLATE UNICODE_CI_AI;
                FbDataReader reader = comandoSQL.ExecuteReader();

                while (reader.Read())
                {
                    Aluno aluno = new();

                    // obtém os valores das colunas usando os índices ou nomes das colunas;

                    aluno.Matricula = reader.GetInt32(0);
                    aluno.Nome = reader.GetString(1);
                    aluno.CPF = reader.GetString(2);
                    aluno.Nascimento = reader.GetDateTime(3);
                    aluno.Sexo = (EnumeradorSexo)reader.GetInt32(4);

                    Alunos.Add(aluno);

                }
                return Alunos;
            }
            catch (FbException e)
            {
                Console.WriteLine($"Ocorreu um erro na classe RepositorioAluno no método GetByContendoNoNome(): {e.Message}");
                throw e;
            }
            finally
            {
                conexao.Close();
            }

        }

        public Aluno GetByMatricula(int matricula)
        {

            FbConnection conexao = ConexaoFirebird.getConexao();

            try
            {
                conexao.Open();

                FbCommand comandoSQL = new FbCommand($"SELECT * FROM TB_ALUNO WHERE PK_TBALUNO_MATRICULA={matricula};", conexao);
                FbDataReader reader = comandoSQL.ExecuteReader();
                Aluno aluno = new();

                while (reader.Read())
                {
                    // obtém os valores das colunas usando os índices ou nomes das colunas;
                    
                    aluno.Matricula = reader.GetInt32(0);
                    aluno.Nome = reader.GetString(1);
                    aluno.CPF = reader.GetString(2);
                    aluno.Nascimento = reader.GetDateTime(3);
                    aluno.Sexo = (EnumeradorSexo)reader.GetInt32(4);
                }
                return aluno;
            }
            catch (FbException e)
            {
                Console.WriteLine($"Ocorreu um erro na classe RepositorioAluno no método GetByMatricula(): {e.Message}");
                throw e;
            }
            finally
            {
                conexao.Close();
            }
        }

        public override void Add(Aluno aluno)
        {
            FbConnection conexao = ConexaoFirebird.getConexao();

            try
            {
                conexao.Open();

                FbCommand comandoSQL = new FbCommand($"INSERT INTO TB_ALUNO(PK_TBALUNO_MATRICULA, TBALUNO_NOME, TBALUNO_CPF, TBALUNO_NASCIMENTO, TBALUNO_SEXO) VALUES(GEN_ID(GEN_TBALUNO, 1), '{aluno.Nome}', '{aluno.CPF}', '{aluno.Nascimento.ToString("yyyy-MM-dd")}', {(int)aluno.Sexo})", conexao);

                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception e) {
                Console.WriteLine($"Ocorreu um erro na classe RepositorioAluno no método Add(): {e.Message}");
            }
            finally{ 
                conexao.Close(); 
            }
        }

        public override void Remove(Aluno aluno)
        {
            FbConnection conexao = ConexaoFirebird.getConexao();

            try
            {
                conexao.Open();

                FbCommand comandoSQL = new FbCommand($"DELETE FROM TB_ALUNO WHERE PK_TBALUNO_MATRICULA={aluno.Matricula};", conexao);

                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro na classe RepositorioAluno no método Add(): {e.Message}");
            }
            finally
            {
                conexao.Close();
            }
        }

        public override void Update(Aluno aluno)
        {
            FbConnection conexao = ConexaoFirebird.getConexao();

            try
            {
                conexao.Open();

                FbCommand comandoSQL = new FbCommand($"UPDATE TB_ALUNO SET TBALUNO_NOME='{aluno.Nome}', TBALUNO_CPF='{aluno.CPF}', TBALUNO_NASCIMENTO='{aluno.Nascimento.ToString("yyyy-MM-dd")}', TBALUNO_SEXO={(int)aluno.Sexo} WHERE PK_TBALUNO_MATRICULA={aluno.Matricula};", conexao);

                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro na classe RepositorioAluno no método Add(): {e.Message}");
            }
            finally
            {
                conexao.Close();
            }
        }

        public override IEnumerable<Aluno> GetAll()
        {

            FbConnection conexao = ConexaoFirebird.getConexao();

            try
            {
                conexao.Open();

                List<Aluno> Alunos = new();

                FbCommand comandoSQL = new FbCommand("SELECT * FROM TB_ALUNO;", conexao);
                FbDataReader reader = comandoSQL.ExecuteReader();
                while (reader.Read())
                {
                    Aluno aluno = new();

                    // obtém os valores das colunas usando os índices ou nomes das colunas;

                    aluno.Matricula = reader.GetInt32(0);
                    aluno.Nome = reader.GetString(1);
                    aluno.CPF = reader.GetString(2);
                    aluno.Nascimento = reader.GetDateTime(3);
                    aluno.Sexo = (EnumeradorSexo) reader.GetInt32(4);

                    Alunos.Add(aluno);

                }
                return Alunos;
            }
            catch(FbException e)
            {
                Console.WriteLine($"Ocorreu um erro na classe RepositorioAluno no método GetAll(): {e.Message}");
                throw e;
            }
            finally
            {
                conexao.Close();
            }
        }

    }
}
