function deleteByEmail() {
    let tdAll = document.querySelectorAll('tbody > tr > td');
    let emailToRemove = document.getElementsByName('email')[0];
    let outputField = document.getElementById('result');
    let tbody = document.getElementsByTagName('tbody')[0];

    let match = Array.from(tdAll).find(td => td.innerHTML == emailToRemove.value);

    if (match) {
        outputField.textContent = 'Deleted.';
        tbody.removeChild(match.parentNode);
    } else {
        outputField.textContent = 'Not found.';
    }
}