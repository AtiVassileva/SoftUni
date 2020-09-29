function printNthElementFromArray(inputArray){
    let step = inputArray.pop();

    let result = inputArray.filter((a, i) => i % step == 0);

    console.log(result.join('\r\n'));
}
