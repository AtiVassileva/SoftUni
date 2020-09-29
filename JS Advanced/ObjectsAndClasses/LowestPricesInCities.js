function solve(input) {

    let result = {};

    input.forEach(line => {
        let [town, product, price] = line.split(' | ');
        price = Number(price);

        if (!result[product]) {
            result[product] = { price, town };
        } else if (result[product].price > price) {
            result[product].price = price;
            result[product].town = town;
        }
    });

    Object.entries(result).
    forEach(([product, obj]) => {
        console.log(`${product} -> ${obj.price} (${obj.town})`);
    })
}

solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);