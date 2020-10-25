function solve() {
    let input = document.getElementsByTagName('input')[0];
    let button = document.getElementsByTagName('button')[0];

    let database = {};
    let index = 0;

    for (let symbol = 65; symbol <= 90; symbol++) {
        let letter = String.fromCharCode(symbol);
        database[letter] = index++;
    }

    button.addEventListener('click', () => {
        let array = document.getElementsByTagName('ol')[0].children;

        let currentName = input.value.toString()[0].toUpperCase() + 
        input.value.toString().slice(1).toLowerCase();

        let capitalLetter = currentName[0];

        if (database[capitalLetter] != undefined) {
        let currIndex = database[capitalLetter];
        let currentElement = array[currIndex];

        if (currentElement.textContent != '') {
            currentElement.textContent += ', ';
        }
        
        currentElement.textContent += currentName;
        }

        input.value = '';
    });
}