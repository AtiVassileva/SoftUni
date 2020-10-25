function attachGradientEvents() {
    let area = document.getElementById('gradient');
    let result = document.getElementById('result');

    area.addEventListener('click', (e) => {
        let clickedPart = e.offsetX;
        let width = e.currentTarget.offsetWidth;

        let percent = (clickedPart / width) * 100;
        result.textContent = `${Math.floor(percent)}%`;
    });
}