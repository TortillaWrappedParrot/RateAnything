// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ShowRatingPopup() {
    var Popup = document.getElementById("RatingPopup")

    if (Popup.style.display == 'none') {
        Popup.style.display = 'block'
    } else {
        Popup.style.display = 'none'
    }
}