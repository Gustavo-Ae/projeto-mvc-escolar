// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const modalTitle = exampleModal.querySelector(".modal-title")
const modalBodyInput = exampleModal.querySelector(".modal-title")
const btn_deletar = document.querySelector("a#btn-excluir-permanente")

btn_deletar.setAttribute("href", "Alunos/Delete/" + matricula)

modalTitle.textContent = `New message to ${recipient}`

modalBodyInput.value = recipient