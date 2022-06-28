function updatingClock(selector, type) {
    function currentDate() {
        var currentDate = new Date;
        var Day = currentDate.getDate();
        if (Day < 10) {
            Day = '0' + Day;
        } //end if
        var Month = currentDate.getMonth() + 1;
        if (Month < 10) {
            Month = '0' + Month;
        } //end if
        var Year = currentDate.getFullYear();
        var fullDate = Day + '/' + Month + '/' + Year;
        return fullDate;
    } //end current date function

    function currentTime() {
        var currentTime = new Date;
        var Minutes = currentTime.getMinutes();
        if (Minutes < 10) {
            Minutes = '0' + Minutes;
        }
        var Hour = currentTime.getHours();
        if (Hour > 12) {
            Hour -= 12;
        } //end if
        var Time = Hour + ':' + Minutes;
        if (currentTime.getHours() <= 12) {
            Time += ' AM';
        } //end if
        if (currentTime.getHours() > 12) {
            Time += ' PM';
        } //end if
        return Time;
    } // end current time function


    function updateOutput() {
        var output;
        if (type == 'time') {
            output = currentTime();
            if ($(selector).text() != output) {
                $(selector).text(output);
            } //end if
        } //end if
        if (type == 'date') {
            output = currentDate();
            if ($(selector).text() != output) {
                $(selector).text(output);
            } //end if
        } //end if
        if (type == 'both') {
            output = currentDate() + ' at ' + currentTime();
            if ($(selector).text() != output) {
                $(selector).text(output);
            } //end if
        } //end if
    }//end update output function
    updateOutput();
    window.setInterval(function () {
        updateOutput();
    }, 1000); //run update every 1 second
} // end updating clock function
updatingClock('#date', 'date');
updatingClock('#time', 'time');