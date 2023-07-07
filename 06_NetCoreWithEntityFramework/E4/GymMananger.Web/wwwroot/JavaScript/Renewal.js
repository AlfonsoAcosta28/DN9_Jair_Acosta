
//kk
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

var buttonAceptarIdMember = document.getElementById("MemberSearch")

buttonAceptarIdMember.addEventListener('click', function (event) {
    event.preventDefault()
    buscarMiembro();

})
closeModal.addEventListener('click', function (event) {
    event.preventDefault()
    modal.classList.remove('modal--show')
    console.log("Click")
})

function buscarMiembro() {
    var memberId = $("#memberId").val();

    $.ajax({
        url: "/api/" + memberId,
        method: "GET",
        success: function (response) {
            var datosMiembro = response;
            console.log(datosMiembro)

            if (datosMiembro) {
                modal.classList.add('modal--show')

                const modalTitle = modal.querySelector('.modal__title');
                const modalContent = modal.querySelector('.modal__paragraph');

                const memberId = datosMiembro.id;
                const name = datosMiembro.name;
                const last = datosMiembro.lastName;
                const email = datosMiembro.email;

                const message = `<p><strong>ID:</strong> ${memberId}</p>
                        <p><strong>Nombre:</strong> ${name} ${last}</p>
                        <p><strong>Email:</strong> ${email}</p>`;

                modalTitle.textContent = "MEMBER";
                modalContent.innerHTML = message;

                setTimeout(function () {
                    modal.classList.remove('modal--show')
                }, 5000)
            } else {
                console.log("Miembro no encontrado");
                $("#miembroNoEncontrado").text("Miembro no encontrado");
            }
        },
        error: function (error) {
            console.log(error);
            $("#miembroNoEncontrado").text("Error en la búsqueda");
        }
    });
}

$.ajax({
    url: "/api/GetMembershipTypes",
    method: "GET",
    success: function (response) {
        var membershipTypes = response;

        var selectElement = document.getElementById("membershipTypeSelect");

        membershipTypes.forEach(function (membershipType) {
            var option = document.createElement("option");
            option.value = membershipType.id;
            option.text = membershipType.name;
            selectElement.appendChild(option);
        });
    },
    error: function (error) {
        console.log(error);
    }
});
