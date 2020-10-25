function orbit(input) {
    let rows = input[0];
    let cols = input[1];
    let startRow = input[2];
    let startCol = input[3];

    let matrix = [];

    for (let i = 0; i < rows; i++) {
        matrix.push([]);
    }

    for (let row = 0; row < rows; row++) {
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = Math.max(Math.abs(row - startRow), Math.abs(col - startCol)) + 1;
        }
    }

    console.log(matrix.map(row => row.join(" ")).join("\n"));
}