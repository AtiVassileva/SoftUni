function sortNegativeAndPositiveNumbers(params) {
    let result = [];

    for (let i = 0; i < params.length; i++) {
       
        if (params[i] >= 0) {
           result.push(params[i]); 
        } else{
            result.unshift(params[i]);
        }
    }
    
    result.forEach(x => console.log(x));
}
