function attachEvents() {
    const baseUrl = `https://judgetests.firebaseio.com/locations.json`;

    let locationInput = document.getElementById('location');
    let getBtn = document.getElementById('submit');
    let forecastItem = document.getElementById('forecast');
    let currForecast = document.getElementById('current');
    let upcomingForecast = document.getElementById('upcoming');

    let symbols = {
        'Sunny': '&#x2600',
        'Partly sunny': '&#x26C5',
        'Overcast': '&#x2601',
        'Rain': '&#x2614',
        'Degrees': '&#176',
    };

    let degreesSym = symbols['Degrees'];

    getBtn.addEventListener('click', () => {

        fetch(baseUrl).then(response => response.json())
            .then(data => {
                let match = data.find(location => location.name === locationInput.value);
                const currForecastUrl = `https://judgetests.firebaseio.com/forecast/today/${match.code}.json`;
                const threeDaysForecastUl = `https://judgetests.firebaseio.com/forecast/upcoming/${match.code}.json`;

                let current = fetch(currForecastUrl).then(response => response.json());
                let upcoming = fetch(threeDaysForecastUl).then(response => response.json());

                Promise.all([current, upcoming])
                    .then(getForecast);
            })
            .catch(error => {
                clearForecasts();
                currForecast.textContent = 'Error';
            });
    });

    function getForecast([currentData, upcomingData]) {
        clearForecasts();
        getCurrentForecast(currentData);
        getUpcomingForecast(upcomingData);
    }

    function clearForecasts() {
        currForecast.textContent = '';
        upcomingForecast.innerHTML = '';
        locationInput.value = '';
    }
    function getCurrentForecast(currentData) {
        forecastItem.style.display = 'block';

        let currDivForecast = document.createElement('div');
        currDivForecast.classList.add('forecasts');
        currDivForecast.innerHTML += `<span class="condition symbol">${symbols[currentData.forecast.condition]}</span>`;

        let weatherDataSpan = document.createElement('span');
        weatherDataSpan.classList.add('condition');

        weatherDataSpan.innerHTML += `<span class="forecast-data">${currentData.name}</span>`;
        weatherDataSpan.innerHTML += `<span class ="forecast-data">${currentData.forecast.low}${degreesSym}/${currentData.forecast.high}${degreesSym}</span>`;
        weatherDataSpan.innerHTML += `<span class="forecast-data">${currentData.forecast.condition}</span>`;

        currDivForecast.appendChild(weatherDataSpan);
        currForecast.appendChild(currDivForecast);
    }

    function getUpcomingForecast(upcomingData) {
        let upcomingForDiv = document.createElement('div');
        upcomingForDiv.classList.add('forecast-info');

        upcomingData.forecast.map(x => {
            let spanData = document.createElement('span');
            spanData.classList.add('upcoming');
            spanData.innerHTML += `<span class="symbol">${symbols[x.condition]}</span>`;
            spanData.innerHTML += `<span class="forecast-data">${x.low}${degreesSym}/${x.high}${degreesSym}</span>`;
            spanData.innerHTML += `<span class="forecast-data">${x.condition}</span>`;
            upcomingForDiv.appendChild(spanData);
        });
        upcomingForecast.appendChild(upcomingForDiv);
    }
}
attachEvents();