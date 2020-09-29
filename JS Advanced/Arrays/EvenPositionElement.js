function sumEvenPositionNumbers(params){
    let result = [];
    for (let i = 0; i < params.length; i+= 2) {
        
        result.push(params[i]);
    }

    console.log(result.join(' '));
}
