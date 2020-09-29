function solve(arr1, arr2, arr3) {

    let firstLength = arr1.length;
    let secondLength = arr2.length;
    let thirdLength = arr3.length;

    let sumLength = firstLength + secondLength + thirdLength;
    let averageLength = Math.floor(sumLength / 3);

    console.log(sumLength);
    console.log(averageLength);
}

