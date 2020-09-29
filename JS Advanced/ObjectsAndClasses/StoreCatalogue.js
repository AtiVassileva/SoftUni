function checkCatalogue(input) {
    let result = {};

    input.forEach(line => {
        let [name, price] = line.split(' : ');
        price = Number(price);

        let letter = name[0];

        if (!result[letter]) {
            result[letter] = [];
        }

        let current = { name, price };
        result[letter].push(current);
    });

    let sortedLetters = Object.entries(result).sort
    ((curr, next) => curr[0].localeCompare(next[0]));

    for (let i = 0; i < sortedLetters.length; i++) {
       console.log(sortedLetters[i][0]);
       let sortByName = sortedLetters[i][1]
       .sort((curr, next) => curr.name.localeCompare(next.name));

       sortByName.forEach(product =>{
           console.log(`  ${product.name}: ${product.price}`);
       })
        
    }

}

checkCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);