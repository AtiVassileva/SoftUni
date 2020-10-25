function printDiagonalAttack(matrix) {
    matrix = matrix
        .map(row => row.split(' ').map(Number));

    let mainDiagonalSum = matrix.map((row, rowIndex) =>
        row.filter((colIndex) => rowIndex === colIndex))
        .reduce((a, b) => Number(a) + Number(b))

    let secondaryDiagonalSum = matrix
        .map((row, rowIndex) => row.filter((colIndex) => colIndex === row.length - 1 - rowIndex))
        .reduce((a, b) => Number(a) + Number(b));

    let isDiagonal = (row, col) => row === col || col === matrix[row].length - 1 - row;

    mainDiagonalSum !== secondaryDiagonalSum
        ? console.log(matrix.map(row => row.join(' ')).join('\n'))
        : console.log(matrix.map((row, rowIndex) => row
            .map((e, colIndex) => isDiagonal(rowIndex, colIndex)
                ? e: mainDiagonalSum).join(' ')).join('\n'));
}