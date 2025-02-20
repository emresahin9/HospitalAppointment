$(document).ready(function () {
    if (isTransactionCompleted)
        TransactionCompleted();
});

function DeleteMedicalSpecialty(id) {
    Swal.fire({
        title: 'Silmek istediğinize emin misiniz?',
        text: "Öge silinecektir. Bu işlemi geri alamazsınız.",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: 'Evet Sil',
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
                url: "DeleteMedicalSpecialty?id=" + id,
                success: function (result) {
                    window.location.href = '/Admin/Home/CompleteTransaction?route=MedicalSpecialties';
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