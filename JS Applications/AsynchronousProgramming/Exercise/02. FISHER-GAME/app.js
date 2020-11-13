function attachEvents() {
    const baseUrl = `https://fisher-game.firebaseio.com/catches.json`;
    const addBtn = document.querySelector('.add');
    const loadBtn = document.querySelector('.load');

    let allCaughtFishesDiv = document.getElementById('catches');

    addBtn.addEventListener('click', () => {
        let angler = document.querySelector('fieldset > input.angler').value;
        let weight = document.querySelector('fieldset > input.weight').value;
        let species = document.querySelector('fieldset > input.species').value;
        let location = document.querySelector('fieldset > input.location').value;
        let bait = document.querySelector('fieldset > input.bait').value;
        let captureTime = document.querySelector('fieldset > input.captureTime').value;

        if (!angler || !weight || !species || !location || !bait || !captureTime) {
            return;
        }

        let fishObj = JSON.stringify({ angler, weight, species, location, bait, captureTime });

        fetch(baseUrl, {
            method: 'POST',
            body: fishObj,
        });

    });

    loadBtn.addEventListener('click', () => {
        fetch(baseUrl)
            .then(response => response.json())
            .then(data => {
                Object.keys(data).map(key => appendFish(key, data));
            });


        function appendFish(key, data) {
            let { angler, weight, species, location, bait, captureTime } = data[key];
            let fishDiv = createElement('div', 'catch', '');
            fishDiv.setAttribute('data-id', key);

            let anglerLabel = createElement('label', '', 'Angler');
            let anglerInput = createElement('input', 'angler', angler, 'text');

            let weightLabel = createElement('label', '', 'Weight');
            let weightInput = createElement('input', 'weight', weight, 'number');

            let speciesLabel = createElement('label', '', 'Species');
            let speciesInput = createElement('input', 'species', species, 'text');

            let locationLabel = createElement('label', '', 'Location');
            let locationInput = createElement('input', 'location', location, 'text');

            let baitLabel = createElement('label', '', 'Bait');
            let baitInput = createElement('input', 'bait', bait, 'text');

            let captureTimeLabel = createElement('label', '', 'Capture time');
            let captureTimeInput = createElement('input', 'captureTime', captureTime, 'number');

            let updateBtn = createElement('button', 'update', 'Update');
            let deleteBtn = createElement('button', 'delete', 'Delete');

            updateBtn.addEventListener('click', (e) => {
                let fishObj = JSON.stringify(
                    {
                        angler: anglerInput.value,
                        weight: weightInput.value,
                        species: speciesInput.value,
                        location: locationInput.value,
                        bait: baitInput.value,
                        captureTime: captureTimeInput.value,
                    });

                const updateUrl = `https://fisher-game.firebaseio.com/catches/${key}.json`;
                fetch(updateUrl, {
                    method: 'PUT',
                    body: fishObj,
                });

            });

            deleteBtn.addEventListener('click', () => {
                const deleteUrl = `https://fisher-game.firebaseio.com/catches/${key}.json`;
                fetch(deleteUrl, { method: 'DELETE' })
                    .then(response => response.json());
            });

            fishDiv.appendChild(anglerLabel);
            fishDiv.appendChild(anglerInput);
            fishDiv.appendChild(document.createElement('hr'));
            fishDiv.appendChild(weightLabel);
            fishDiv.appendChild(weightInput);
            fishDiv.appendChild(document.createElement('hr'));
            fishDiv.appendChild(speciesLabel);
            fishDiv.appendChild(speciesInput);
            fishDiv.appendChild(document.createElement('hr'));
            fishDiv.appendChild(locationLabel);
            fishDiv.appendChild(locationInput);
            fishDiv.appendChild(document.createElement('hr'));
            fishDiv.appendChild(baitLabel);
            fishDiv.appendChild(baitInput);
            fishDiv.appendChild(document.createElement('hr'));
            fishDiv.appendChild(captureTimeLabel);
            fishDiv.appendChild(captureTimeInput);
            fishDiv.appendChild(document.createElement('hr'));
            fishDiv.appendChild(updateBtn);
            fishDiv.appendChild(deleteBtn);

            allCaughtFishesDiv.appendChild(fishDiv);
        }

        function createElement(el, classes, content, type) {
            let element = document.createElement(el);

            if (el === 'input') {
                element.type = type;
                element.value = content;
            } else {
                element.innerHTML = content;
            }

            element.className = classes;
            return element;
        };

    }
    )
}
attachEvents();