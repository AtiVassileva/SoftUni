function processOddNumbers(numbers) {

    let result = numbers
        .filter((x, i) => i % 2 !== 0)
        .map(x => x * 2)
        .reverse()
        .join(' ');

    console.log(result);

}
