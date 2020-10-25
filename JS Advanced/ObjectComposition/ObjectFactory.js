function solve(input) {
    let properties = JSON.parse(input);
    let result = properties.reduce((acc, curr) => ({...acc, ...curr}), {});
    return result;
}