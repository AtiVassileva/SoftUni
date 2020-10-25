function attachEventsListeners() {

    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    document.getElementById('daysBtn')
        .addEventListener('click', () => {
            convert(+days.value * 86400)
        });

    document.getElementById('hoursBtn')
        .addEventListener('click', () => {
            convert(+hours.value * 3600)
        });

    document.getElementById('minutesBtn')
        .addEventListener('click', () => {
            convert(+minutes.value * 60)
        });

    document.getElementById('secondsBtn')
        .addEventListener('click', () => {
            convert(+seconds.value)
        });

    function convert(secondsValue = 0) {
        let currDays = secondsValue / 86400;
        let currHours = secondsValue / 3600;
        let currMins = secondsValue / 60;

        days.value = currDays;
        hours.value = currHours;
        minutes.value = currMins;
        seconds.value = secondsValue;
    }
}