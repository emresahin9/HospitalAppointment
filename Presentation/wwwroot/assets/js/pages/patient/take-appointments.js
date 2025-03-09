$(document).ready(function () {
    GetDoctors($("#MedicalSpecialtyId"));
    let appointments = {};
    // Aşağısı silinecek!
    if (isTransactionCompleted)
        TransactionCompleted();
});

function GetDoctors(e) {
    if ($(e).val() != 0) {
        $.ajax({
            type: "GET",
            url: "GetDoctors",
            contentType: "application/json",
            processData: false,
            data: "medicalSpecialtyId=" + $(e).val(),
            async: null,
            success: function (data) {
                PutDoctors(data);
            },
            error: function () {
                alert("Error");
            }
        });
    }
    else {
        PutDoctors(null);
    }
    function PutDoctors(data) {
        $("#DoctorId").html('');
        $("#DoctorId").append('<option value="0">-Seçiniz-</option>');
        if (data != null) {
            $.each(data, function (k, v) {
                //if (selectedDoctorId == v.id)
                //    $("#DoctorId").append('<option value="' + v.id + '" selected>' + v.doctorName + '</option>');
                //else
                $("#DoctorId").append('<option value="' + v.id + '">' + v.fullName + '</option>');
            })
        }
        $("#DoctorId").change();
    };
}

function GetAppointments(e) {
    if ($(e).val() != 0) {
        $.ajax({
            type: "GET",
            url: "GetAppointments",
            contentType: "application/json",
            processData: false,
            data: "doctorId=" + $(e).val(),
            async: null,
            success: function (data) {
                PutAppointments(data);
            },
            error: function () {
                alert("Error");
            }
        });
    }
    else {
        PutAppointments(null);
    }
    function PutAppointments(data) {
        if (data != null) {
            // Randevu ekleme fonksiyonu
            function addOrUpdateAppointment(appointments, newAppointment) {
                let date = newAppointment.time.split('T')[0];

                // Belirtilen tarih appointments içinde yoksa, yeni bir dizi oluştur
                if (!appointments[date]) {
                    appointments[date] = [];
                }

                // Belirtilen tarihe randevuyu ekle
                appointments[date].push(newAppointment);
            }

            // Yeni randevuları ekle
            data.forEach(appointment => {
                addOrUpdateAppointment(appointments, appointment);
            });

            let currentDate = new Date();
            currentDate.setDate(currentDate.getDate() + 1);

            function formatDate(date) {
                date1 = convertToTimezone(date, 'Europe/Istanbul')
                return date1.toISOString().split('T')[0];
            }
            ////////////////////////////////////////////////
            function convertToTimezone(date, timeZone) {
                // Date nesnesini UTC saat diliminde ISO string olarak al
                const utcDate = new Date(date.toLocaleString('en-US', { timeZone: 'UTC' }));

                // Belirtilen saat dilimine göre Date nesnesi oluştur
                const tzDate = new Date(date.toLocaleString('en-US', { timeZone }));

                // UTC ve saat dilimine göre tarih bileşenleri arasındaki farkı hesapla
                const offset = utcDate.getTime() - tzDate.getTime();

                // Date nesnesine bu farkı ekleyerek belirtilen saat dilimindeki tarihi elde et
                return new Date(date.getTime() - offset);
            }
            /////////////////////////////////////////////////////
            function updateAppointments() {
                // Görünürlüğü aç
                $("#appointmentDateArea").removeClass("invisible");

                let dateStr = formatDate(currentDate);
                $("#selectedDate").text(new Intl.DateTimeFormat('tr-TR', { timeZone: 'Europe/Istanbul', day: '2-digit', month: 'long', year: 'numeric' }).format(currentDate));
                let list = $("#appointmentsList");
                list.empty();
                if (appointments[dateStr]) {
                    appointments[dateStr].forEach(item => {
                        if (!item.isAvailable)
                            list.append(`<div class="col-xl-3 col-lg-4 col-sm-4 col-6 p-2""><button class="btn btn-primary w-75 disabled-day" disabled>${item.time.split('T')[1].split(':')[0]}:${item.time.split('T')[1].split(':')[1]}</button></div>`)
                        else
                            list.append(`<div class="col-xl-3 col-lg-4 col-sm-4 col-6 p-2"><button class="btn btn-primary w-75" onclick="TakeAnAppointment(${item.id})">${item.time.split('T')[1].split(':')[0]}:${item.time.split('T')[1].split(':')[1]}</button></div>`)
                    });
                } else {
                    list.append(`<span class="text-muted">Bu tarihte randevu bulunmamaktadır.</span>`);
                }
            }

            $("#prevDate").click(() => {
                const currentDateNoHours = currentDate;
                currentDateNoHours.setHours(0, 0, 0, 0);
                const dateTimeCurrent = new Date();
                dateTimeCurrent.setHours(0, 0, 0, 0);

                //console.log("currentDateNoHours: ", dateTimeCurrent);
                //console.log("dateTimeCurrent: ", currentDateNoHours);

                if (Math.abs((currentDateNoHours - dateTimeCurrent) / (1000 * 60 * 60 * 24)) === 2) {
                    $("#prevDate").addClass("disabled-day");
                }

                if (currentDate.getTime())
                currentDate.setDate(currentDate.getDate() - 1);
                updateAppointments();
            });

            $("#nextDate").click(() => {
                //console.log(currentDate);
                const currentDateNoHours = currentDate;
                currentDateNoHours.setHours(0, 0, 0, 0);
                const dateTimeCurrent = new Date();
                dateTimeCurrent.setHours(0, 0, 0, 0);
                if (Math.abs((dateTimeCurrent - currentDateNoHours) / (1000 * 60 * 60 * 24)) >= 1) {
                    $("#prevDate").removeClass("disabled-day");
                }


                currentDate.setDate(currentDate.getDate() + 1);
                updateAppointments();
            });

            updateAppointments();
        }
        else {
            // Görünürlüğü kapa
            $("#appointmentDateArea").addClass("invisible");
            $("#appointmentsList").empty();
            appointments = {};
        }
    };
}

function TakeAnAppointment(appointmentId) {
    Swal.fire({
        title: 'Seçtiğiniz randevu alınacak.',
        text: "Randevu alma işlemini onaylıyor musunuz?",
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
                url: "TakeAnAppointment?appointmentId=" + appointmentId,
                success: function (result) {
                    window.location.href = '/Patient/Home/CompleteTransaction?route=TakeAppointment'
                },
                error: function (xhr) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Hata!',
                        text: xhr.responseJSON.message,
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