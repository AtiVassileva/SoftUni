function validate() {
    let input = document.getElementById('email');

    input.addEventListener('change', (e) => {
        let currentTarget = e.currentTarget.value;
        let regex = /[a-z]+@[a-z]+.[a-z]+/;
        
        if (!regex.test(currentTarget)) {
            e.currentTarget.classList.add('error');
        } else{
            e.currentTarget.classList.remove('error');
        }
    });
}