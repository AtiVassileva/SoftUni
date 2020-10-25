function lockedProfile() {

    Array.from(document.getElementsByClassName('profile'))
        .forEach(parent => {
            let btn = parent.querySelectorAll('button')[0];

            btn.addEventListener('click', () => {
                let unlocked = parent.querySelectorAll('input')[1].checked;
                let hiddenDiv = parent.querySelectorAll('div')[0];

                if (unlocked) {
                    if (btn.textContent == 'Show more') {
                        hiddenDiv.style.display = 'block';
                        btn.textContent = 'Hide it';
                    } else if (btn.textContent == 'Hide it') {
                        hiddenDiv.style.display = 'none';
                        btn.textContent = 'Show more';
                    }
                }
            })
        });
}