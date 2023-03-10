using EM.Domain.Enums;
using EM.Domain.Interface;

namespace EM.Domain.Model
{
    public class Aluno : IEntidade
    {
        public int Matricula { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime Nascimento { get; set; }

        public EnumeradorSexo Sexo { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Aluno aluno &&
                   Matricula == aluno.Matricula &&
                   Nome == aluno.Nome &&
                   CPF == aluno.CPF &&
                   Nascimento == aluno.Nascimento &&
                   Sexo == aluno.Sexo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Matricula, Nome, CPF, Nascimento, Sexo);
        }

        public override string? ToString()
        {
            return $"{Matricula},'{Nome}','{CPF}','{Nascimento.ToString("yyyy-MM-dd")}',{(int)Sexo}";
        }
    }
}
