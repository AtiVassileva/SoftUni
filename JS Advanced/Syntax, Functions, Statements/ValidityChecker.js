function CheckForValidity([x1, y1, x2, y2]) {
    let firstResult = 'invalid';
    let secondResult = 'invalid';
    let thirdResult = 'invalid';

    if (IsValid(x1, y1, 0, 0)) {
        firstResult = 'valid';
    }

    if (IsValid(x2, y2, 0, 0)) {
        secondResult = 'valid';
    }

    if (IsValid(x1, y1, x2, y2)) {
        thirdResult = 'valid';
    }
    console.log(`{${x1}, ${y1}} to {0, 0} is ${firstResult}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${secondResult}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${thirdResult}`);

    function IsValid(x1, y1, x2, y2){
        let value = Math.sqrt((x2 - x1) ** 2 +  (y2 - y1) ** 2);
    
        return Number.isInteger(value);
    }
}

