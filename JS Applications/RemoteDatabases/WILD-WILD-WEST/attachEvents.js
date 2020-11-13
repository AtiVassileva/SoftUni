const htmlSelectors = {
    'saveBtn': () => document.getElementById('save'),
    'reloadBtn': () => document.getElementById('reload'),
    'addPlayerBtn': () => document.getElementById('addPlayer'),
    'playersDiv': () => document.getElementById('players'),
    'playerInput': () => document.getElementById('addName'),
    'canvas': () => document.getElementById('canvas'),
}

//REFRESH AFTER SAVING A PROGRESS AND RELOADING! :)
// HAVE TO BE REFACTORED SOON - IF YOU HAVE ANY IDEAS - I WILL BE HAPPY TO HEAR THEM, THANK YOU!
function attachEvents() {

    const baseUrl = `https://wild-wild-west-cb0a9.firebaseio.com/`;

    fetch(baseUrl + 'players.json')
        .then(response => response.json())
        .then(data => {
            Object.keys(data).map(pl => {
                let playerDiv = visualisePlayer(data[pl].name, data[pl].money, data[pl].bullets);
                let playBtn = playerDiv.querySelector('button');
                let deleteBtn = playerDiv.querySelectorAll('button')[1];

                playBtn.addEventListener('click', play);
                deleteBtn.addEventListener('click', deletePlayer);

                function play(e) {
                    e.preventDefault();
                    htmlSelectors['saveBtn']().style.display = 'block';
                    htmlSelectors['reloadBtn']().style.display = 'block';
                    htmlSelectors['canvas']().style.display = 'block';

                    htmlSelectors['saveBtn']().addEventListener('click', saveProgress);

                    loadCanvas(data[pl]);

                    htmlSelectors['reloadBtn']().addEventListener('click', reloadBulletsAndMoney);
                }

                function saveProgress() {                    
                    fetch(baseUrl + `players/${pl}.json`, {
                        method: 'PATCH',
                        body: JSON.stringify({ name: data[pl].name, money: data[pl].money, bullets: data[pl].bullets })
                    })
                    htmlSelectors['saveBtn']().style.display = 'none';
                    htmlSelectors['reloadBtn']().style.display = 'none';
                    htmlSelectors['canvas']().style.display = 'none';
                    clearInterval(htmlSelectors['canvas']().intervarId);
                }

                function reloadBulletsAndMoney() {
                    const patchedDetails = {
                        money: data[pl].money - 60,
                        bullets: 6,
                    }

                    fetch(baseUrl + `players/${pl}.json`,
                        {
                            method: 'PATCH',
                            body: JSON.stringify(patchedDetails)
                        })
                }

                function deletePlayer(e) {
                    e.preventDefault();
                    e.target.parentElement.remove();
                    fetch(baseUrl + `players/${pl}.json`, {
                        method: 'DELETE',
                    })
                }
            })
        })


    htmlSelectors['addPlayerBtn']().addEventListener('click', addPlayer);

    function addPlayer(e) {
        e.preventDefault();
        if (!htmlSelectors['playerInput']().value) {
            return;
        }
        const playerObj = {
            name: htmlSelectors['playerInput']().value,
            money: 500,
            bullets: 6
        };

        fetch(baseUrl + 'players.json', {
            method: 'POST',
            body: JSON.stringify(playerObj)
        })

        visualisePlayer(playerObj.name, playerObj.money, playerObj.bullets);
        htmlSelectors['playerInput']().value = '';
    }

    function visualisePlayer(name, money, bullets) {

        let playerDiv = document.createElement('div');
        let nameLi = document.createElement('div');
        nameLi.textContent = `Name: ${name}`;
        let moneyLi = document.createElement('div');
        moneyLi.textContent = `Money: ${money}`;
        let bulletsLi = document.createElement('div');
        bulletsLi.textContent = `Bullets: ${bullets}`;
        let playBtn = document.createElement('button');
        playBtn.textContent = 'Play';
        let deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';

        playBtn.setAttribute('class', 'play');
        deleteBtn.setAttribute('class', 'delete');

        playerDiv.setAttribute('class', 'player');
        playerDiv.appendChild(nameLi);
        playerDiv.appendChild(moneyLi);
        playerDiv.appendChild(bulletsLi);
        playerDiv.appendChild(playBtn);
        playerDiv.appendChild(deleteBtn);

        htmlSelectors['playersDiv']().appendChild(playerDiv);

        return playerDiv;
    }
}

window.canvas = htmlSelectors['canvas']();