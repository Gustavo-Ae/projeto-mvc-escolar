
using EM.Domain.Model;
using FirebirdSql.Data.FirebirdClient;

namespace EM.Repository.Conexao
{
    public abstract class ConexaoFirebird 
    {
        public static FbConnection getConexao()
        {
            string informacoesParaConexaoBanco = "UserID=SYSDBA;Password=masterkey;Host=localhost;Port=3050;Database=C:\\Users\\gusta\\OneDrive\\Documents\\PROJETOS-C#\\estagio-escolar-manager\\Banco de dados Firebird_4_0\\DB_ALUNO.FDB;";

            return new FbConnection(informacoesParaConexaoBanco);
        }

    }
}
