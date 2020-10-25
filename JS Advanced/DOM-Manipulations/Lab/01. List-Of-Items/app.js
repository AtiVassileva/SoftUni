function addItem() {
    let itemsList = document.getElementById('items');
    let input = document.getElementById('newItemText');

    let currentElement = document.createElement('li');
    currentElement.innerHTML = input.value;

    itemsList.appendChild(currentElement);

    input.value = '';
}