var firebaseConfig = {
    apiKey: "AIzaSyDbCwbb-9ZhVO-WVrt-nvRScUYw-5_Wsdc",
    authDomain: "authentication-demo-ecb2b.firebaseapp.com",
    databaseURL: "https://authentication-demo-ecb2b.firebaseio.com",
    projectId: "authentication-demo-ecb2b",
    storageBucket: "authentication-demo-ecb2b.appspot.com",
    messagingSenderId: "617150808714",
    appId: "1:617150808714:web:fcbeb5ff13556ea75da373"
};
// Initialize Firebase
firebase.initializeApp(firebaseConfig);
const auth = firebase.auth();

let loginForm = document.getElementById('login-form');
let loginInputs = document.querySelectorAll('#login-form input');
let loginBtn = document.querySelector('#login-form button');
let resultDiv = document.getElementById('result');

let registerLink = document.querySelector('a');
let registerForm = document.getElementById('register-form');
let signUpInputs = document.querySelectorAll('#register-form input');
let signUpBtn = document.querySelector('#register-form button');

let logOutForm = document.getElementById('logout-form');
let logOutBtn = document.querySelector('#logout-form button');

loginBtn.addEventListener('click', (e) => {
    e.preventDefault();
    let email = loginInputs[0].value;
    let password = loginInputs[1].value;

    auth.signInWithEmailAndPassword(email, password)
        .then(res => {
            resultDiv.style.display = 'block';
            resultDiv.textContent = 'Successfully logged in!';
            resultDiv.style.backgroundColor = 'green';

            setInterval(() => {
                resultDiv.style.display = 'none';
            }, 3000);

            loginInputs[0].value = '';
            loginInputs[1].value = '';
            loginForm.style.display = 'none';
            logOutForm.style.display = 'block';

        }).catch(err => displayError(err));
});

registerLink.addEventListener('click', () => {
    loginForm.style.display = 'none';
    registerForm.style.display = 'block';

    signUpBtn.addEventListener('click', (e) => {
        e.preventDefault();
        let regEmail = signUpInputs[0].value;
        let regPassword = signUpInputs[1].value;

        auth.createUserWithEmailAndPassword(regEmail, regPassword)
            .then(res => {
                resultDiv.style.display = 'block';
                resultDiv.textContent = 'Successfully registered!';
                resultDiv.style.backgroundColor = 'green';

                setInterval(() => {
                    resultDiv.style.display = 'none';
                }, 3000);

                signUpInputs[0].value = '';
                signUpInputs[1].value = '';
                registerForm.style.display = 'none';
                logOutForm.style.display = 'block';

            }).catch(err => displayError(err));
    });
});

logOutBtn.addEventListener('click', (e) => {
    e.preventDefault();
    auth.signOut().then(r => {
        loginForm.style.display = 'block';
        logOutForm.style.display = 'none';
        resultDiv.style.display = 'block';
        resultDiv.textContent = 'You just logged out!';
        resultDiv.style.backgroundColor = 'orange';

        setInterval(() => {
            resultDiv.style.display = 'none';
        }, 1000);

    }).catch(err => displayError(err));
});

function displayError(error) {
    resultDiv.style.display = 'block';
        resultDiv.textContent = error.message;
        resultDiv.style.backgroundColor = 'red';

        setInterval(() => {
            resultDiv.style.display = 'none';
        }, 3000);
}