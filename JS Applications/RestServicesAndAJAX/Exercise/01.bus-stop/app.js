function getInfo() {
    let validBusesId = [1287, 1308, 1327, 2334];

    let busId = document.getElementById('stopId');
    let stopName = document.getElementById('stopName');
    let bussesUl = document.getElementById('buses');

    if (!validBusesId.includes(Number(busId.value))) {
        stopName.textContent = 'Error';
        clear();
        return;
    }

    const url = `https://judgetests.firebaseio.com/businfo/${Number(busId.value)}.json`;
    fetch(url).
        then(response => response.json()).
        then(busData => {
            stopName.textContent = busData.name;
            let buses = busData.buses;

            Object.keys(buses).forEach((key => {
                let currentLi = document.createElement('li');
                currentLi.innerHTML = `Bus ${key} arrives in ${buses[key]} minutes`;
                bussesUl.appendChild(currentLi);
            }));
        });

    clear();

    function clear() {
        bussesUl.textContent = '';
        busId.value = '';
    }
}