$(document).ready(function () {
    if (isTransactionCompleted)
        TransactionCompleted();
});

function OpenTodayForAppointments(datetime) {
    Swal.fire({
        title: 'Seçtiğiniz gün randevuya açılacak.',
        text: "Randevu açma işlemini onaylıyor musunuz?",
        icon: "success",
        showCancelButton: true,
        confirmButtonText: 'Onaylıyorum',
        cancelButtonText: `Kapat`,
        confirmButtonColor: '#8fce00',
        customClass: {
            popup: 'rounded-0',
            confirmButton: "btn-flat"
        }
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                async: false,
                url: "OpenTodayForAppointments?datetime=" + datetime,
                success: function (result) {
                    window.location.href = '/Doctor/Home/CompleteTransaction?route=OpeningAppointments'
                },
                error: function (result) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Hata!',
                        text: 'Sistem Hatası!',
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