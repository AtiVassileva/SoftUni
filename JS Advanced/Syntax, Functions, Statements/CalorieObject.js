function CalculateCalories(params) {

    let output = '{'
    for (let i = 0; i < params.length; i+= 2) {
        
        if(i + 2 == params.length){
            output += ` ${params[i]}: ${params[i + 1]}`;
        } else{
            output += ` ${params[i]}: ${params[i + 1]},`;
        }
        
    }

    output += ' }';
    console.log(output);
}


