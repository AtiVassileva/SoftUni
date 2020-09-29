function checkForMagicMatrix(matrix) {
    let wantedSum = matrix[0].reduce((a, b) => a + b);
    let isMagic = true;

    for (let i = 0; i < matrix.length; i++) {
        let sumRows = matrix[i].reduce((a, b) => a + b);
        let sumCols = matrix.map(x => x[i]).reduce((a, b) => a + b);

        if (sumRows !== wantedSum || sumCols !== wantedSum) {
            isMagic = false;
            break;
        }

    }
    console.log(isMagic);
}