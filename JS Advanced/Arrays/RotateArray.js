function rotateArray(inputArray){
    let rotations = inputArray.pop();

    for (let i = 0; i < rotations % inputArray.length; i++) {
        inputArray.unshift(inputArray.pop());
    }

    console.log(inputArray.join(' '));
}

