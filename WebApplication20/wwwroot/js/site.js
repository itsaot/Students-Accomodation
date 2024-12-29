// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Function to get current time
function getCurrentTime() {
    var currentTime = new Date();
    var hours = currentTime.getHours();
    var minutes = currentTime.getMinutes();
    var seconds = currentTime.getSeconds();
    // Pad single digit minutes and seconds with a leading zero
    minutes = minutes < 10 ? '0' + minutes : minutes;
    seconds = seconds < 10 ? '0' + seconds : seconds;
    return hours + ":" + minutes + ":" + seconds;
}

// Function to display current time
function showCurrentTime() {
    var currentTime = getCurrentTime();
    document.getElementById("current-time").textContent = currentTime;
    document.getElementById("current-time-container").style.display = "block";
}

//function for subscribe box
function subscribe() {
    var emailInput = document.getElementById("emailInput");
    if (emailInput.value.trim() === "") {
        alert("Please insert your email address.");
        emailInput.focus();
    } else if (!emailInput.value.trim().endsWith("gmail.com" || "dut4life.ac.za")) {
        alert("Please insert a valid email address.");
        emailInput.focus();
        emailInput.value = "";
    } else {
        alert("Thank you for subscribing with email: " + emailInput.value);
        emailInput.value = "";
    }
}