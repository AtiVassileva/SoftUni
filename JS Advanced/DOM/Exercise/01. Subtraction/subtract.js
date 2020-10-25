function subtract() {
    let firstNumValue = document.getElementById('firstNumber').value;
    let secondNumValue = document.getElementById('secondNumber').value;

    let resultDiv = document.getElementById('result');
    let substraction = firstNumValue - secondNumValue;
    resultDiv.innerHTML = substraction;
}