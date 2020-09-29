function solve(length, count) {
    let result = [1];

    for (let i = 1; i < length; i++) {
        let lastKElements = result.slice(-count);
        let sum = lastKElements.reduce((a, b) => a + b);
        result.push(sum);

    }

    console.log(result.join(' '))
}


