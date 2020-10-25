function solve() {
    let dropdownList = document.getElementById('dropdown-ul');
    let dropdownBtn = document.getElementById('dropdown');
    let box = document.getElementById('box');

    dropdownBtn.addEventListener('click', () => {
        
        if (dropdownList.style.display == 'block') {
            dropdownList.style.display = 'none';
            box.style.backgroundColor = 'black';
            box.style.color = 'white';
        } else {
            dropdownList.style.display = 'block';
        }

    });

    dropdownList.addEventListener('click', (e) => {
        let color = e.target.textContent;
        box.style.backgroundColor = color;
        box.style.color = 'black';
    });
}