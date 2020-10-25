function focus() {
    let inputs = document.querySelectorAll('input[type="text"]');

    Array.from(inputs).forEach(field => {
        field.addEventListener('focus', () => {
            field.parentElement.classList.add('focused');
        });

        field.addEventListener('blur', () => {
            field.parentElement.classList.remove('focused');
        });
    })
}