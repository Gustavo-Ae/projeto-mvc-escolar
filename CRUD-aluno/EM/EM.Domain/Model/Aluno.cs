using EM.Domain.Enums;
using EM.Domain.Interface;
using System.ComponentModel.DataAnnotations;

namespace EM.Domain.Model
{
    public class Aluno : IEntidade
    {
        public int Matricula { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatorio")]
        [RegularExpression(@"^(?!\s*$)[a-zA-ZÀ-ÿ\s]*$", ErrorMessage = "O campo Nome deve conter apenas letras.")]
        public string Nome { get; set; }

        public string? CPF { get; set; }

        [Required(ErrorMessage= "Informe sua data de nascimento")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "Informe seu sexo")]
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
