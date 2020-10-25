function solve() {
    let expression = document.getElementById('expressionOutput');
    let resultOutput = document.getElementById('resultOutput');

    document.querySelector('.keys').addEventListener('click', symbolClick);

    document.querySelector('.clear').addEventListener('click', clear);


    function clear() {
        expression.textContent = '';
        resultOutput.textContent = '';
    }
    function symbolClick(event) {

        let pressedButton = event.target.value;

        switch (pressedButton) {
            case '/':
            case '*':
            case '+':
            case '-':
                expression.textContent += ` ${pressedButton} `;
                break;
            case '=':
                let [leftOperand, operator, rightOperand]
                    = expression.textContent.split(' ');

                if (!rightOperand || !operator) {
                    resultOutput.textContent = 'NaN';
                } else {
                    let result = '';
                    leftOperand = Number(leftOperand);
                    rightOperand = Number(rightOperand);

                    switch (operator) {
                        case '*':
                            result = leftOperand * rightOperand;
                            break;
                        case '/':
                            result = leftOperand / rightOperand;
                            break;
                        case '+':
                            result = leftOperand + rightOperand;
                            break;
                        case '-':
                            result = leftOperand * rightOperand;
                            break;
                    }

                    resultOutput.textContent = result;
                }
                break;
            default:
                expression.textContent += pressedButton;

        }
    }
}