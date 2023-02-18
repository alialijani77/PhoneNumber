function StartLoading(element = 'body') {
    $(element).waitMe({
        effect: 'bounce',
        text: 'Please Wait ...',
        bg: 'rgba(255, 255, 255, 0.7)',
        color: '#000'
    });
}

function CloseLoading(element = 'body') {
    $(element).waitMe('hide');
}


function LoadPhoneNumberModalBody(PhoneNumberId) {
    $.ajax({
        url: "/load-PhoneNumberId-modal-body",
        type: "get",
        data: {
            PhoneNumberId: PhoneNumberId
        },
        beforeSend: function () {
            StartLoading();
        },
        success: function (response) {
            CloseLoading();
            $("#PhoneNumberModalContent").html(response);

            $('#PhoneNumberForm').data('validator', null);
            $.validator.unobtrusive.parse('#PhoneNumberForm');

            $("#PhoneNumberModal").modal("show");
        },
        error: function () {
            CloseLoading();
        }
    });
}

function hiddenPhoneNumberModalBody() {
    $("#PhoneNumberModal").modal("hide");
}
