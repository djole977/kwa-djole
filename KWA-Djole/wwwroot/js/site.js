// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    if (localStorage.getItem('success') === 'true') {
        if (localStorage.getItem('message') !== null) {
            SuccessToast('Uspešno', localStorage.getItem('message'));
        }
        else {
            SuccessToast('Uspešno', 'Akcija uspešno izvršena.');
        }
        localStorage.setItem('success', null);
        localStorage.setItem('message', null);
    }
    else if (localStorage.getItem('success') === 'false') {
        if (localStorage.getItem('message') !== null) {
            ErrorToast('Greška', localStorage.getItem('message'));
        }
        else {
            ErrorToast('Greška', 'Došlo je do greške prilikom izvršavanja akcije.');
        }
        localStorage.setItem('success', null);
        localStorage.setItem('message', null);
    }
    //Bootstrap code - initialize all tooltips on the page
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    })
})
function GoToLogin() {
    window.location.href = "/Home/Login";
}
function AlertSucccess(title, message, nextFunction) {
    if (title === undefined) {
        title = 'Uspešno';
    }
    if (message === undefined) {
        message = 'Akcija uspešno izvršena.';
    }
    $.confirm({
        type: 'green',
        title: 'Uspešno',
        content: message,
        buttons: {
            Ok: {
                btnClass: 'btn-green',
                action: nextFunction
            }
        }
    })
}

function SuccessToast(title, text) {
    if (title === undefined) {
        title = 'Obaveštenje'
    }
    if (text === undefined) {
        text = 'Akcija uspešno izvršena'
    }
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "4000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    toastr["success"](text, title)
}

function ErrorToast(title, text) {
    if (title === undefined) {
        title = 'Obaveštenje'
    }
    if (text === undefined) {
        text = 'Došlo je do greške'
    }

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "4000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    toastr["error"](text, title)
}

function Logout() {
    $.ajax({
        url: '/User/Logout',
        type: 'POST',
        success: function (data) {
            localStorage.setItem('success', data.success);
            localStorage.setItem('message', data.message);
            window.location.href = '/Home/Index';
        },
        error: function (data) {
            localStorage.setItem('success', false);
            localStorage.setItem('message', data.message);
        }
    })
}

function AddProductToCart(productId) {
    $.ajax({
        url: "/User/AddProductToCart",
        type: "POST",
        data: { productId: productId },
        success: function (data) {
            if (data.success) {
                localStorage.setItem('success', 'true')
                localStorage.setItem('message', 'Proizvod je dodat u korpu')
                window.location.reload();
            }
            else {
                ErrorToast('Greška', data.message);
            }
        }
    });
}
function formatDateToDDMMYYYY(date) {
    let day = date.getDate().toString().padStart(2, '0');
    let month = (date.getMonth() + 1).toString().padStart(2, '0');
    let year = date.getFullYear();

    // Return formatted date string
    return `${day}.${month}.${year}`;
}
function formatNumber(number) {
    return number.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}