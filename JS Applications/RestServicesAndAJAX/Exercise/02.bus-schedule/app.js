function solve() {
    const url = `https://judgetests.firebaseio.com/schedule/`;
    let currentId = 'depot';
    let currentName = 'depot';

    let infoBox = document.getElementById('info');
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');

    function depart() {
        fetch(url + currentId + '.json')
            .then(response => response.json())
            .then(data => {
                infoBox.textContent = `Next stop ${data.name}`;
                currentId = data.next;
                currentName = data.name;
                console.log(currentId);
            }).catch(() => {
                infoBox.textContent = `Error`;
                departBtn.disabled = true;
                arriveBtn.disabled = true;
            });

        switchBtn();
    }

    function arrive() {
        infoBox.textContent = `Arriving at ${currentName}`;
        switchBtn();
    }

    function switchBtn() {
        const departBtn = document.getElementById('depart');
        const arriveBtn = document.getElementById('arrive');
        if (departBtn.disabled) {
            departBtn.disabled = false;
            arriveBtn.disabled = true;
        } else {
            departBtn.disabled = true;
            arriveBtn.disabled = false;
        }
    }

    return {
        depart,
        arrive,
    };
}

let result = solve();