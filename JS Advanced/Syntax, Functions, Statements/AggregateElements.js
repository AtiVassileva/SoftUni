function AggregateElements(params){
    let totalSum = 0;
    let aggregateSum = 0;
    let concatString = '';

    for (let i = 0; i < params.length; i++) {
        totalSum += params[i];
        aggregateSum += 1 / params[i];
        concatString += params[i];
        
    }

    console.log(totalSum);
    console.log(aggregateSum);
    console.log(concatString);
}
