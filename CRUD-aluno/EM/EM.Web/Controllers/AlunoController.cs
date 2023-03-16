using EM.Domain.functions;
using EM.Domain.Model;
using EM.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace EM.Web.Controllers
{
    public class AlunoController : Controller
    {
        private RepositorioAluno _repository = new();

        public IActionResult Index(string texto, string opcaoBusca)
        {

            if (opcaoBusca == "nome")
            {
                try
                {
                    IEnumerable<Aluno> alunos = _repository.GetByContendoNoNome(texto);

                    if (alunos.Count() == 0)
                    {
                        TempData["MensagemAlerta"] = $"⚠️ Aluno com nome {texto} não foi encontrado!";
                        return View(_repository.GetAll());
                    }

                    return View(alunos);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro na escolha da opção : {ex}");
                }

            }
            else if (opcaoBusca == "matricula" && Regex.IsMatch(texto, @"^[0-9]+$"))
            {

                Aluno aluno = _repository.GetByMatricula(int.Parse(texto));

                if (aluno.Matricula == 0)
                {
                    TempData["MensagemAlerta"] = $"⚠️ Aluno com a matricula {texto} não foi encontrado!";
                    return View(_repository.GetAll());
                }

                return View(new List<Aluno> { aluno });
            }
            else
            {
                return View(_repository.GetAll());
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
          
                if (aluno.Nome.Length < 3 || aluno.Nome.Length > 100)
                {
                    TempData["MensagemAlerta"] = $"⚠️ Nome do Aluno tem que ter no minimo 3 caracteres e no máximo 100 caracteres";
                }

                if (aluno.CPF == null || ValidarCPF.IsValid(aluno.CPF) == true)
                {
                    _repository.Add(aluno);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "🚩 CPF Inválido";
                }
            

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int matricula)
        {

            Aluno aluno = _repository.GetByMatricula(matricula);
            
            return View(aluno);
        }

        [HttpPost]
        public IActionResult Editar(Aluno aluno)
        {

            if (aluno.Nome.Length < 3 || aluno.Nome.Length > 100)
            {
                TempData["MensagemAlerta"] = $"⚠️ Nome do Aluno tem que ter no minimo 3 caracteres e no máximo 100 caracteres";
            }
            else if (aluno.CPF == null || ValidarCPF.IsValid(aluno.CPF) == true)
            {
                _repository.Update(aluno);
                TempData["MensagemSucesso"] = "Aluno alterado com sucesso";
            }
            else
            {
                TempData["MensagemErro"] = "🚩 CPF Inválido";
            }

            return View();

        }

        public IActionResult Delete(int matricula)
        {
            Aluno aluno = _repository.GetByMatricula(matricula);

            _repository.Remove(aluno);
            return RedirectToAction("Index");
        }

    }
}
