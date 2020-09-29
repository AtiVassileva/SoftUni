function sumNumbers(first, second) {

    let firstParsed = Number(first);
    let secondParsed = Number(second);

    let sum = 0;
    for (let i = firstParsed; i <= secondParsed; i++) {
        sum += i;
    }

    console.log(sum);
}
