function addItem() {
    let itemsList = document.getElementById('items');
    let input = document.getElementById('newText');

    let currentElement = document.createElement('li');

    let deleteElement = document.createElement('a');
    deleteElement.href = '#';
    deleteElement.innerText = '[Delete]';
    
    currentElement.innerHTML = input.value + ' ';
    currentElement.appendChild(deleteElement);

    deleteElement.addEventListener('click', function(e) {
        let parentElement = e.target.parentElement;
        parentElement.remove();
    })
    itemsList.appendChild(currentElement);

    input.value = '';
}