function toggle() {
    let div = document.getElementById('extra');
    let button = document.querySelector('span');
 
    button.textContent = button.textContent.toLowerCase() === 'more' ? 'Less' : 'More';
    div.style.display = button.textContent.toLowerCase() === 'less' ? 'block' : 'none';
}