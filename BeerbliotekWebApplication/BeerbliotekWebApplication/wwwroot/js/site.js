﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function checkAge() {
    var inputDate = document.getElementById("date").value.trim();
    var currentDate = new Date();
    var currentDay = currentDate.getDate();
    var currentMonth = currentDate.getMonth() + 1;
    var nineteenYearsBefore = currentDate.getFullYear() - 20;
    var twentyYearsBefore = currentMonth + '/' + currentDay + '/' + nineteenYearsBefore;
    var comparedDate = new Date(twentyYearsBefore);
    var userDateOfBirth = new Date(inputDate);
    if (userDateOfBirth <= comparedDate) {
        //Placeholder
    }
    else {
        window.location.href="https://bravo.nu/";
    }
}