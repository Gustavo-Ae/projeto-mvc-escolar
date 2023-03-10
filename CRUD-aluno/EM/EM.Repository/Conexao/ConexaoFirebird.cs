
using EM.Domain.Model;
using FirebirdSql.Data.FirebirdClient;

namespace EM.Repository.Conexao
{
    public abstract class ConexaoFirebird 
    {
        public static FbConnection getConexao()
        {
            string informacoesParaConexaoBanco = "UserID=SYSDBA;Password=masterkey;Host=localhost;Port=3054;Database=C:\\Users\\Escolar Manager\\Documents\\arq-gustavo\\BancoDeDados-CRUD\\DB_ALUNO.FDB;";

            return new FbConnection(informacoesParaConexaoBanco);
        }

    }
}
