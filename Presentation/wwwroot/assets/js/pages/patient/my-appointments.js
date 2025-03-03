$(document).ready(function () {
    if (isTransactionCompleted)
        TransactionCompleted();
});

function CancelAppointment(appointmentId) {
    Swal.fire({
        title: 'İptal etmek istediğinize emin misiniz?',
        text: "Randevu iptel edilecek!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: 'Evet İptal Et',
        cancelButtonText: `Kapat`,
        confirmButtonColor: '#d33',
        customClass: {
            popup: 'rounded-0',
            confirmButton: "btn-flat"
        }
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                async: false,
                url: "CancelAppointment?appointmentId=" + appointmentId,
                success: function (result) {
                    window.location.href = '/Patient/Home/CompleteTransaction?route=MyAppointments'
                },
                error: function (xhr) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Hata!',
                        text: 'xhr.responseJSON.message',
                        confirmButtonText: 'Kapat',
                        confirmButtonColor: '#d33',
                        customClass: {
                            popup: 'rounded-0',
                        }
                    });
                }
            });

        }
    })
}