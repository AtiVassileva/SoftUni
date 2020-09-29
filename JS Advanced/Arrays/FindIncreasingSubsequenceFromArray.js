function findIncreasingSubsequence(inputArray){
let max = Number.MIN_SAFE_INTEGER;

let output = inputArray.reduce((acc, curr) => {
    if (curr >= max) {
        max = curr;
        acc.push(max);
    }

    return acc;
}, [])
 
console.log(output.join('\r\n'));
}
