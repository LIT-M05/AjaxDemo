$(() => {
    $("#email").on('blur', function () {
        const userInputEmail = $("#email").val();
        $.get('/home/isavailable', { email: userInputEmail }, function (result) {
            if (result.Available) {
                $("#available").show();
                $("#unavailable").hide();
            } else {
                $("#available").hide();
                $("#unavailable").show();
            }
        });
    });
});

//const obj = {
//    name: 'Avrumi',
//    age: 36,
//    cars: ['Minivan', 'Not minivan']
//}