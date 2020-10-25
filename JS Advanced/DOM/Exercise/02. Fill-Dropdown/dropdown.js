function addItem() {
    let itemText = document.getElementById('newItemText');
    let itemValue = document.getElementById('newItemValue');

    let select = document.getElementById('menu');
    let option = `<option value=${itemValue.value}>${itemText.value}</option>`;
    select.innerHTML += option;
    
    itemText.value = '';
    itemValue.value = '';
}