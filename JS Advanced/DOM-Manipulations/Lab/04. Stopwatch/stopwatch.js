function stopwatch() {
    let timer = document.getElementById('time');
    let startBtn = document.getElementById('startBtn');
    let stopBtn = document.getElementById('stopBtn');
    let interval;

    startBtn.addEventListener('click', () => {
        startBtn.disabled = true;
        stopBtn.disabled = false;

        timer.textContent = '00:00';

        interval = setInterval(() => {
            let currTime = timer.textContent.split(':');
            let minutes = Number(currTime[0]);
            let seconds = Number(currTime[1]);

            seconds++;

            if (seconds > 59) {
                minutes++;
                seconds = 0;
            }

            timer.textContent = `${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`
        }, 1000);
    });

    stopBtn.addEventListener('click', () => {
        stopBtn.disabled = true;
        startBtn.disabled = false;

        clearInterval(interval);
    });
}