// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const abrirModal = document.getElementById('modal-excluir')

const matricula = document.getElementById("modal-matricula")

abrirModal.addEventListener('show.bs.modal', event => {
    // Button that triggered the modal
    const button = event.relatedTarget

    const informacoesAluno = button.getAttribute('data-bs-whatever').split(",")

    const nome = document.getElementById("modal-nome")

    const CPF = document.getElementById("modal-cpf")

    const nascimento = document.getElementById("modal-nascimento")

    const sexo = document.getElementById("modal-sexo")

    matricula.textContent = informacoesAluno[0]

    nome.textContent = informacoesAluno[1]

    CPF.textContent = informacoesAluno[2]

    nascimento.textContent = informacoesAluno[3]

    sexo.textContent = informacoesAluno[4]

})

const botaoExcluirNoModal = document.querySelector("#btn-modalExcluir")

botaoExcluirNoModal.addEventListener("click", function () {
    botaoExcluirNoModal.setAttribute("href", "/Aluno/Delete/" + matricula.innerHTML)
})


function mascaraCPF(i) {

    var v = i.value;

    if (isNaN(v[v.length - 1])) { // impede entrar outro caractere que não seja número
        i.value = v.substring(0, v.length - 1);
        return;
    }

    i.setAttribute("maxlength", "14");
    if (v.length == 3 || v.length == 7) i.value += ".";
    if (v.length == 11) i.value += "-";

}

//const botaoBuscar = document.getElementById("btn-busca")

//botaoBuscar.addEventListener("click", function (e) {
//     e.preventDefault();

//    var radios = document.getElementsByName("opcoesBusca")

//    const valorBusca = document.getElementById("input-busca")

//    for (var i = 0; i < radios.length; i++) {
//        if (radios[i].checked) {

//            console.log(radios[i].value)

//            //botaoBuscar.setAttribute("href", "/Aluno/Pesquisa/" + radios[i].value)
//            window.history.pushState(“object or string”, “Title”, “/Aluno/Pesquisa/”+radios[i].value);
//        }
//    }

//    console.log("ok")
//})