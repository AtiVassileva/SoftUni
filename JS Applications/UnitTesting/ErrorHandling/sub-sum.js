function solve(array, startIndex, endIndex) {
    if (!(array instanceof Array)) {
        return NaN;
    }

    startIndex < 0 ? startIndex = 0 : startIndex = startIndex;
    endIndex >= array.length ? endIndex = array.length - 1 : endIndex = endIndex;

    let sum = array.slice(startIndex, endIndex + 1).reduce((acc, curr) => acc += Number(curr), 0);
    return sum;
}