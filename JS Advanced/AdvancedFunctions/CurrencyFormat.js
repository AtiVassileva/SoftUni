function solve(currencyFormatter) {
    const separator = ',';
    const symbol = '$';
    const symbolFirst = true;

    let dollarFormatter = currencyFormatter.bind(null, separator, symbol, symbolFirst);

    return dollarFormatter;
}

function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2, 2);
    if (symbolFirst) {
        return symbol + ' ' + result
    }

    return result + ' ' + symbol;
}

let dollarFormatter = solve(currencyFormatter);
console.log(dollarFormatter(5345));   // $ 5345,00
console.log(dollarFormatter(3.1429)); // $ 3,14
console.log(dollarFormatter(2.709));  // $ 2,71