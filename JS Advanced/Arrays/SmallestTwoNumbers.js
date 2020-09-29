function findTwoSmallestNumbers(numbers){
    numbers = numbers.sort((a, b) => a - b);

    let firstNum = numbers[0];
    let secondNum = numbers[1];

    console.log(`${firstNum} ${secondNum}`)
}
