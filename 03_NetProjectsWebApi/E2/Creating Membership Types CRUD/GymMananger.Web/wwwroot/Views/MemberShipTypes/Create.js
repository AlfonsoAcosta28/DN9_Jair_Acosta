window.addEventListener('DOMContentLoaded', function () {
    var createdOnField = document.getElementById('createdOn');
    var currentDate = new Date().toISOString().split('T')[0];
    var currentTime = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
    var currentDateTime = currentDate + ' ' + currentTime;
    createdOnField.value = currentDateTime;
});