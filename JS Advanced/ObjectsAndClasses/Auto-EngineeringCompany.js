function register(input) {

    let result = {};

    input.forEach(line => {
        let [brand, model, count] = line.split(' | ');
        count = Number(count);

        if (!result[brand]) {
            result[brand] = {};
        }

        if (!result[brand][model]) {
            result[brand][model] = 0;
        }

        result[brand][model] += count;
    });

    Object.entries(result)
        .forEach(([brand, model]) => {
            console.log(brand);
            Object.entries(model)
                .forEach(([model, count]) => {
                    console.log(`###${model} -> ${count}`);
                })
        });
}
register(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']);