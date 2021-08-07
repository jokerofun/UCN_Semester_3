/*
    Created: December 6, 2019, updated November 15, 2020
    Author: Lars Landberg Toftegaard
    Purpose: 
*/


// When seat is clicked - get values and update reserved seats string accordingly
function seatchange(seatId) {
    var seatNoStr = "" + seatId;
    var currentSeat = document.getElementById(seatId);
    var foundReservationValue = currentSeat.value;
    alert("Clicked on:" + seatId + ", value was:" + foundReservationValue);
    if (foundReservationValue === '0') {
        SetReservedSeats(seatId, true);
        currentSeat.value = 1;
    } else {
        SetReservedSeats(seatId, false);
        currentSeat.value = 0;
    }
}

// Update reserved seats string
// Todo: remove alerts
function SetReservedSeats(seatId, doAdd) {
    var actualReservedSeats = document.getElementById("reservedSeats");
    var seatsStr = actualReservedSeats.value;
    var newSeatsStr = '';
    if (doAdd) {
        newSeatsStr = seatsStr.concat(":" + seatId);
    } else {
        newSeatsStr = seatsStr.replace(":" + seatId, '');
    }
    actualReservedSeats.value = newSeatsStr;
    displaySelected();
    //alert("reservedSeats string: " + getReservedSeatsValue());
}

function displaySelected() {
    var actualReservedSeats = document.getElementById("reservedSeats");
    var displaySelected = document.getElementById("seatSelection");
    displaySelected.innerText = actualReservedSeats.value;
}

// Just for test
function getReservedSeatsValue() {
    var actualReservedSeats = document.getElementById("reservedSeats");
    var seatsStr = actualReservedSeats.value;
    return seatsStr;
}