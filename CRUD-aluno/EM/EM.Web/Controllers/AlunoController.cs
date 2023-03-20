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

                if (int.TryParse(texto, out int resultado))
                {
                    TempData["MensagemAlerta"] = $"⚠️ Não pode buscar nome utilizando numeros";
                    return View(_repository.GetAll());
                }

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
            else if (opcaoBusca == "matricula")
            {

                if (!Regex.IsMatch(texto, @"^[0-9]+$"))
                {
                    TempData["MensagemAlerta"] = $"⚠️ Não pode buscar matricula utilizando letras";
                    return View(_repository.GetAll());
                }

                IEnumerable<Aluno> alunos = _repository.Get(x => x.Matricula == int.Parse(texto));

                if (alunos.Count() == 0)
                {
                    TempData["MensagemAlerta"] = $"⚠️ Aluno com a matricula {texto} não foi encontrado!";
                    return View(_repository.GetAll());
                }

                //return View(new List<Aluno> { aluno });
                return View(alunos);
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

                else if (aluno.CPF == null || ValidarCPF.IsValid(aluno.CPF) == true)
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
