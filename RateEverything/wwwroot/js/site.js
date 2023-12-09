// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showRatingPopup() {
    var Popup = document.getElementById("RatingPopup")

    if (Popup.style.display == 'none') {
        Popup.style.display = 'block'
    } else {
        Popup.style.display = 'none'
    }
}

function displayModal(message, displayTime) {
    var modal = document.getElementById("modalDialog")

    if (modal != null) {
        modal.style.display = 'block'
        setTimeout(function () {
            modal.style.display = 'none'
        }, displayTime * 1000)
    } 
}

function postRating(itemID) {
    var postData = {
        "rating": parseInt(document.getElementById("rating").value),
        "ID": itemID
    }

    //Debug
    //alert(postData);
    //console.log(postData);

    $.ajax({
        url: '/Items/Details',
        type: "POST",
        data: postData,
        dataType: "json"
    }).fail(function (data) {
        var messageString = "Ajax request failed, returned data: " + data
        displayModal(messageString, 3);
        console.log(messageString);
    }).done(function (data) {
        var messageString = "Ajax request success, returned data: " + data
        displayModal(messageString, 3);
        console.log(messageString);
    })
}