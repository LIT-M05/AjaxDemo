$(() => {

    function addPersonToTable(person) {
        $("#people-table").append(`<tr><td>${person.FirstName}</td>
                                           <td>${person.LastName}</td>
                                           <td>${person.Age}</td></tr>`);
    }

    $("#add-person").on('click', function () {
        $.get('/home/getperson', function (person) {
            addPersonToTable(person);
        });
    });

    $("#add-people").on('click', function () {
        $.get('/home/getpeople', function (people) {
            people.forEach(function(person) {
                addPersonToTable(person);
            });
        });
    });
})