function solve() {
    let selectMenu = document.getElementById('selectMenuTo');

    let binaryOption = document.createElement('option');
    binaryOption.value = 'binary';
    binaryOption.textContent = 'Binary';

    let hexadecimalOption = document.createElement('option');
    hexadecimalOption.value = 'hexadecimal';
    hexadecimalOption.textContent = 'Hexadecimal';

    selectMenu.appendChild(binaryOption);
    selectMenu.appendChild(hexadecimalOption);

    let button = document.getElementById('container').lastElementChild;

    button.addEventListener('click', () => {
        let input = document.getElementById('input');
        let result = document.getElementById('result');

        let number = parseInt(input.value);

        if (selectMenu.value == 'binary') {
            result.value = number.toString(2);
        } else {
            result.value = number.toString(16).toUpperCase();
        }
    })
}