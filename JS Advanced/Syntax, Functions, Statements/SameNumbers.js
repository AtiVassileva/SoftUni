function CheckForSameNumbers(inputNumber) {

    let sum = 0;
    let result = true;

    let firstNum = inputNumber % 10;

    while (inputNumber) {

        let current = inputNumber % 10;

        if (current % 10 != firstNum) {
            result = false;
        }

        sum += current;
        inputNumber = Math.floor(inputNumber / 10);
    }
    console.log(result);
    console.log(sum);
}

CheckForSameNumbers(1234);