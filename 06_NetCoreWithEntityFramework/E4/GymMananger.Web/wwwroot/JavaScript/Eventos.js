

const memberIdInput = document.querySelector('.memberId')
const modal = document.querySelector('.modal')
const closeModal = document.querySelector('.modal__close')
const alerta = document.getElementById('alerta')

// Evento para la tecla Enter
memberIdInput.addEventListener('keydown', function (event) {
    if (event.keyCode === 13) {
        event.preventDefault()
        const memberId = memberIdInput.value
    }
})

//Evento para el boton
var buttonAceptarIdMember = document.getElementById("btnMemberInOut")

buttonAceptarIdMember.addEventListener('click',  function (event) {

    event.preventDefault();
    const memberId = memberIdInput.value;

    if (memberId.trim() === '') {
        alerta.hidden = false;
        return;
    }
    axios.get(`/api/Querys/GetMemberById/${memberId}`).then(response => {
        const member = response.data;
        var attendanceData;
        var apiDirection = "";

        console.log(member)

        if (!member || Object.keys(member).length === 0) {
            alert('El miembro no existe en la base de datos.');
            return;
        }

        alerta.hidden = true;
        var action;

        if (buttonAceptarIdMember.classList.contains('MemberIn')) {
            action = 'Entrada';
            attendanceData = {
                "members": memberId
            };
            apiDirection = "MemberIn";
        } else if (buttonAceptarIdMember.classList.contains('MemberOut')) {
            action = 'Salida';

            attendanceData = {
                "checkIn": null,
                "checkOut": null,
                "members": memberId
            };
            apiDirection = "MemberOut";
        }

        const modalTitle = modal.querySelector('.modal__title');
        const modalContent = modal.querySelector('.modal__paragraph');
        const currentTime = new Date().toLocaleTimeString();
        const message = `Registrada para el miembro ${memberId} ${currentTime}`;

        modalTitle.textContent = action;
        modalContent.textContent = message;

        const url = `/api/Querys/${apiDirection}`;
        console.log(url)
        //const url = "/Attendance/MemberIn";

        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(attendanceData), 
        };

        fetch(url, options).then(response => response.json()).then(data => {
            console.log(data);
        }).catch(error => {
            console.error('Error al enviar los datos al servidor:', error);
        });

        modal.classList.add('modal--show');
        setTimeout(function () {
            modal.classList.remove('modal--show');
        }, 3000);
    }).catch(error => {
        console.error('Error al realizar la solicitud HTTP:', error);
        alert('Hubo un error al obtener el miembro desde el servidor.');
    });
    
});

closeModal.addEventListener('click', function (event) {
    event.preventDefault()
    modal.classList.remove('modal--show')
})