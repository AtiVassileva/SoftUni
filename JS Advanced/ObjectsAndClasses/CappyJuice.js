function bottleJuice(input) {

    let result = {};
    let readyJuices = {};

    input.forEach(line => {
        let [name, quantity] = line.split(' => ');

        if (!result[name]) {
            result[name] = Number(quantity);
        } else {
            result[name] += Number(quantity);
        }

        if (result[name] >= 1000) {
            readyJuices[name] = 0;
        }
    });


    Object.keys(result).forEach(key => {
        if (readyJuices[key] !== undefined) {
            let bottles = Math.floor(result[key] / 1000);
            readyJuices[key] += bottles;
        }
    })

    Object.keys(readyJuices).forEach(j => console.log(`${j} => ${readyJuices[j]}`))
}
