function findBiggestElement(matrix){

    let maxNumber = Number.MIN_SAFE_INTEGER;

    matrix.forEach(row => {
        let currentMax = Math.max(...row);

        if (currentMax > maxNumber) {
            maxNumber = currentMax;
        }
    });

    console.log(maxNumber);
}
