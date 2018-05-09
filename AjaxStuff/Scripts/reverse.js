$(() => {
    $("#reverse-text").on('click', function () {
        $.post('/home/reversetext', { text: $("#original").val() }, function (result) {
            $("#reversed").val(result.ReversedText);
        });
    });
})