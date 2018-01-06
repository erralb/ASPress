// Write your JavaScript code.

$(function () {
    $('form').submit(function () {
        if ($(this).valid()) {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    // $('#result').html(result);
                    $('#result').html("Votre commentaire a été enregistré, il devra être validé par un administrateur avant d'être affiché.");
                }
            });
        }
        return false;
    });
});