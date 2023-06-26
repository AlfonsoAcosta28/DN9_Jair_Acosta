

const memberIdInput = document.getElementById('memberId')
const modal = document.querySelector('.modal')
const closeModal = document.querySelector('.modal__close')

// Evento para la tecla Enter
memberIdInput.addEventListener('keydown', function (event) {
    if (event.keyCode === 13) {
        event.preventDefault()
        const memberId = memberIdInput.value
        console.log('Se presionó Enter. Valor del campo memberId:', memberId)
    }
})

//Evento para el boton
var buttonAceptarIdMember = document.getElementById("btnMemberInOut")

buttonAceptarIdMember.addEventListener('click', function (event) {
    event.preventDefault()
    modal.classList.add('modal--show')
    var action;
    if (buttonAceptarIdMember.classList.contains('MemberIn')) {
        action = 'Entrada';
    } else if (buttonAceptarIdMember.classList.contains('MemberOut')) {
        action = 'Salida';
    }
    

    const modalTitle = modal.querySelector('.modal__title')
    const modalContent = modal.querySelector('.modal__paragraph');

    const memberId = memberIdInput.value
    const currentTime = new Date().toLocaleTimeString();

    const message = `registrada para el miembro ${memberId} ${currentTime}`;

    modalTitle.textContent = action; 
    modalContent.textContent = message;

    setTimeout(function () {
        modal.classList.remove('modal--show')
    }, 3000)
})
closeModal.addEventListener('click', function (event) {
    event.preventDefault()
    modal.classList.remove('modal--show')
    console.log("Click")
})