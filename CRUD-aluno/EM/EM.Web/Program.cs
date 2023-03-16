
using EM.Domain.Enums;
using EM.Domain.Model;
using EM.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configurar para ficar igual a extensão Live Server do Visual Studio Code;
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// TESTANDO CONEXÃO:

// UPDATE()

//RepositorioAluno repositorioAluno = new();

//Aluno aluno = new();

//aluno.Matricula = 1;
//aluno.Nome = "Felipe Antônio";
//aluno.CPF = "116.052.215-03";
//aluno.Nascimento = DateTime.Now;
//aluno.Sexo = EnumeradorSexo.Masculino;

//repositorioAluno.Update(aluno);

// ADD(); 

//RepositorioAluno repositorioAluno = new();

//Aluno aluno = new();

//aluno.Matricula = 4;
//aluno.Nome = "Fernando Victor";
//aluno.CPF = "117.052.215-03";
//aluno.Nascimento = DateTime.Now;
//aluno.Sexo = EnumeradorSexo.Masculino;

//repositorioAluno.Add(aluno);


// Remove();

//RepositorioAluno repositorioAluno = new();

//Aluno aluno = new();

//aluno.Matricula = 4;
//aluno.Nome = "Fernando Victor";
//aluno.CPF = "117.052.215-03";
//aluno.Nascimento = DateTime.Now;
//aluno.Sexo = EnumeradorSexo.Masculino;

//repositorioAluno.Remove(aluno);

// GETALL()

//repositorioAluno.Add(aluno);

//IEnumerable<Aluno> alunos = repositorioAluno.GetAll();

//foreach (var aluno in alunos)
//{
//    Console.WriteLine(aluno);   
//}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Aluno}/{action=Index}/{matricula?}");

app.Run();
