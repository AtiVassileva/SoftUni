function calculate(input){
    let result = {};

    input.forEach(line => {
        let [name, population] = line.split(' <-> ');
        population = Number(population);

        if (!result[name]) {
            result[name] = 0;
        }  
        result[name] += population;
    });

    Object.entries(result).
    forEach(([name, population]) => console.log(`${name} : ${population}`));
}