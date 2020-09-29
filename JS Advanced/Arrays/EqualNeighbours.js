function findEqualNeighbours(matrix) {

    let count = 0;

    matrix.forEach((row, i) => {
        row.forEach((el, j) => {
            if (el === row[j + 1]) {
                count++;
            }

            if (matrix[i + 1] && el === matrix[i + 1][j]) {
                count++;
            }
        })
    });

    console.log(count);
}

findEqualNeighbours([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
);