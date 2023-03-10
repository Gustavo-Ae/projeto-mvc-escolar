using EM.Domain.Model;
using EM.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EM.Web.Controllers
{
    public class AlunoController : Controller
    {
        private RepositorioAluno _respository = new();

        public IActionResult Index()
        {
            return View(_respository.GetAll());
        }

        public IActionResult Create(Aluno aluno)
        {

            if (ModelState.IsValid)
            {
                _respository.Add(aluno);
                return RedirectToAction("Index");
            }
            else
            {
                return View(aluno);
            }
        }

        public IActionResult Delete(int matricula)
        {
            //_respository.Remove(matricula);
            return View();
        }

    }
}
