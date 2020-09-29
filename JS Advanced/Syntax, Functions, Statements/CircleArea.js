function CalculateCircleArea(parameter){

    if(typeof(parameter) == 'number'){
    let area = Math.PI * (parameter ** 2); 
console.log(area.toFixed(2));
} else{
console.log(`We can not calculate the circle area, because we receive a ${typeof(parameter)}.`)
}
}
