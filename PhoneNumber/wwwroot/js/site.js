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


function PhoneNumberFormSubmited(response) {
    CloseLoading();
    if (response.status === "success") {
        /* swal("Done", "The Operation Has Done Successfully", "success");*/
        Swal.fire(
            'Done',
            'The Operation Has Done Successfully',
            'success'
        )
        $("#PhoneNumberModal").modal("hide");
        $("#PhoneNumberDiv").load(location.href + " #PhoneNumberDiv");
    } else {
        Swal.fire(
            'Error',
            'Some thing went wrong please try again ...',
            'error'
        )
    }
}


function DeletePhone(PhoneNumberId) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/DeletePhone",
                type: "get",
                data: {
                    PhoneNumberId: PhoneNumberId
                },
                beforeSend: function () {
                    StartLoading();
                },
                success: function (response) {
                    CloseLoading();
                    $("#PhoneNumberDiv").load(location.href + " #PhoneNumberDiv");
                    Swal.fire(
                        'Deleted!',
                        'Your file has been deleted.',
                        'success'
                    )                  
                },
                error: function () {
                    CloseLoading();
                }
            });
           
        }
    })
}

