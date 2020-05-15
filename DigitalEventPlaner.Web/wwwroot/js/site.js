// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#subimt-button").click(function (event) {
    event.preventDefault();
    $.ajax({
        type: "POST",
        url: $("#username-validation-url").val(),
        data: { UserName: $("#username-input").val() },
        dataType: "json",
        success: function (msg) {
            debugger;
            if (msg == true) {
                if (VerifyPassword()) {
                    $("#user-register-form").submit();
                }
                else {
                    $("#password-validation").text("Password dont match!");
                }
            }
            else {
                $("#unsername-validation").text(msg);
            }
            
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (req, status, error) {
            alert(error);
        }
    });
});

function VerifyPassword() {
    var passwordValue = $("#password-value").val();
    var confirmPasswordValue = $("#confirm-password-value").val();
    if (passwordValue == confirmPasswordValue) {
        return true;
    }
    else {
        return false;
    }
};